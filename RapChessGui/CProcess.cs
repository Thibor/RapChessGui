using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

	public class CProcess
	{
		private readonly DataReceivedEventHandler dataR = null;
		public Process process = new Process();

		public CProcess(DataReceivedEventHandler drh)
		{
			dataR = drh;
		}

		public int GetPid()
		{
			if (process.StartInfo.FileName == String.Empty)
				return 0;
			return process.Id;
		}

		private void OnErrorReceived(object sender, DataReceivedEventArgs e)
		{
			try
			{
				if (!String.IsNullOrEmpty(e.Data))
					FormChess.log.Add(e.Data);
			}
			catch { }
		}

		public int SetProgram(string path, string param = "")
		{
			Terminate();
			if (File.Exists(path))
			{
				process = new Process();
				process.StartInfo.FileName = path;
				process.StartInfo.Arguments = param;
				process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
				process.StartInfo.CreateNoWindow = true;
				process.EnableRaisingEvents = true;
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.UseShellExecute = false;
				process.OutputDataReceived += dataR;
				process.ErrorDataReceived += OnErrorReceived;
				process.Start();
				process.BeginOutputReadLine();
				process.BeginErrorReadLine();
				process.PriorityClass = FormOptions.priority;
				process.StandardInput.AutoFlush = true;
				return process.Id;
			}
			return 0;
		}

		public void Restart()
		{
			SetProgram(process.StartInfo.FileName, process.StartInfo.Arguments);
		}

		public void Stop()
		{
			WriteLines("stop");
		}

		public void Quit()
		{
			WriteLines("quit");
		}

		public void Close()
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				Quit();
				process.OutputDataReceived -= dataR;
				process.StartInfo.FileName = String.Empty;
			}
		}

		public void Terminate()
		{
			try
			{
				if (process.StartInfo.FileName != String.Empty)
				{
					process.OutputDataReceived -= dataR;
					process.Kill();
					process.StartInfo.FileName = String.Empty;
				}
			}
			catch { }
		}

		public void WriteLines(string c,bool sleep=false)
		{
			if (process.StartInfo.FileName != String.Empty)
			{
				process.StandardInput.WriteLine(c);
				if(sleep)
				System.Threading.Thread.Sleep(8);
			}
		}

	}
}
