using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcessBuf
	{
		protected Process process = null;
		readonly private object locker = new object();
		private readonly List<string> listSou = new List<string>();
		private readonly List<string> listDes = new List<string>();

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
				listSou.Add(msg);
			}
		}

		void CopyList(out bool stop)
		{
			stop = false;
			lock (locker)
			{
				foreach(string m in listSou)
					if (m.Contains("bestmove"))
					{
						stop=true;
						break;
					}
                listDes.AddRange(listSou);
				listSou.Clear();
			}
		}

		public string GetMessage(out bool stop,out bool last)
		{
            stop = false;
			if(listDes.Count == 0)
				CopyList(out stop);
            last = listDes.Count<2;
            return GetMsg(out last);
		}



		public string GetMessage()
		{
			if (listDes.Count == 0)
				CopyList(out _);
			return GetMsg(out _);
		}

        string GetMsg(out bool last)
		{
			last = true;
			string msg = String.Empty;
			if (listDes.Count == 0)
				return msg;
			msg = listDes[0];
			listDes.RemoveAt(0);
			last = listDes.Count == 0;
			return msg;
		}

		public void Clear()
		{
			lock (locker)
			{
				listSou.Clear();
				listDes.Clear();
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

		public bool SetProgram(string path, string param = "")
		{
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
