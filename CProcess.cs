using System;
using System.IO;
using System.Diagnostics;

namespace RapChessGui
{

    public class CProcess
    {
        private readonly DataReceivedEventHandler dataR = null;
        public Process process = null;// new Process();

        public CProcess(DataReceivedEventHandler drh)
        {
            dataR = new DataReceivedEventHandler(drh);
        }

        public int GetPid()
        {
            return process?.Id ?? 0;
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
                process.EnableRaisingEvents = true;
                process.StartInfo.FileName = path;
                process.StartInfo.Arguments = param;
                process.StartInfo.WorkingDirectory = Path.GetDirectoryName(path);
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.UseShellExecute = false;
                process.OutputDataReceived += dataR;
                process.ErrorDataReceived += new DataReceivedEventHandler(OnErrorReceived);
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
            if (process != null)
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

        public void Close()
        {
            if (process != null)
            {
                process.OutputDataReceived -= dataR;
                Quit();
                process = null;
            }
        }

        public void Terminate()
        {
            try
            {
                if (process != null)
                {
                    process.OutputDataReceived -= dataR;
                    process.Kill();
                    process = null;
                }
            }
            catch { }
        }

        public void WriteLine(string c, int sleep = 0)
        {
            process?.StandardInput?.WriteLine(c);
            System.Threading.Thread.Sleep(sleep);
        }

    }
}
