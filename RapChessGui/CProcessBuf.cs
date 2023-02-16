using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcessBuf
	{
		bool spamOff = false;
		protected Process process = null;
		readonly private object locker = new object();
		private readonly List<string> list = new List<string>();

		/// <summary>
		/// Get memory usage
		/// </summary>
		public string GetMemory()
		{
			if (process == null)
				return "Memory";
			process.Refresh();
			if (process.HasExited)
				return "Memory";
			return process.PrivateMemorySize64.ToString("N0");
		}

		void SetMessage(string msg)
		{
			lock (locker)
			{
				list.Add(msg);
			}
		}

		public string GetMessage(out bool stop)
		{
			stop = false;
			string msg = String.Empty;
			lock (locker)
			{
				foreach (string m in list)
					if (m.Contains("bestmove"))
					{
						stop = true;
						if (spamOff)
						{
							list.Clear();
							return m;
						}
					}
				if (list.Count > 0)
				{

					msg = list[0];
					list.RemoveAt(0);
				}
			}
			return msg;
		}

		public void Clear()
		{
			lock (locker)
			{
				list.Clear();
			}
		}

		private void OnDataReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
				{
					string msg = e.Data.Trim();
					SetMessage(msg);
				}
			}
			catch { }
		}

		public bool SetProgram(string path, string param = "",bool spamOff = false)
		{
			this.spamOff = spamOff;
			Terminate();
			if (File.Exists(path))
			{
				process = new Process();
				process.StartInfo.FileName = path;
				process.StartInfo.Arguments = param;
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.UseShellExecute = false;
				process.OutputDataReceived += OnDataReceived;
				process.Start();
				process.BeginOutputReadLine();
				process.PriorityClass = FormOptions.priority;
				return true;
			}
			return false;
		}

		public void Restart()
		{
			SetProgram(process.StartInfo.FileName, process.StartInfo.Arguments);
		}

		public void Stop()
		{
			WriteLine("stop");
		}

		public void Quit()
		{
			WriteLine("quit");
		}

		public void Close(bool wait)
		{
			try
			{
				if (process != null)
				{
					process.OutputDataReceived -= OnDataReceived;
					Clear();
					Quit();
					if (wait)
					{
						process.WaitForExit(100);
						if (!process.HasExited)
							process.Kill();
					}
					process = null;
				}
			}
			catch
			{
			}
		}

		public void Terminate()
		{
			try
			{
				if (process != null)
				{
					process.OutputDataReceived -= OnDataReceived;
					Clear();
					process.Kill();
					process = null;
				}
			}
			catch
			{
			}
		}

		public void WriteLine(string c)
		{
			process?.StandardInput.WriteLine(c);
		}

	}
}
