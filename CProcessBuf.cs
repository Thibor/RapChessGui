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
        private readonly List<string> listMsg = new List<string>();

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
                listMsg.Add(msg);
            }
        }

        public List<string> GetMessages()
        {
            List<string> list = new List<string>();
            lock (locker)
            {
                list.AddRange(listMsg);
                listMsg.Clear();
            }
            return list;
        }

        public void Clear()
        {
            lock (locker)
            {
                listMsg.Clear();
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
                process.OutputDataReceived += new DataReceivedEventHandler(OnDataReceived);
                process.Start();
                process.BeginOutputReadLine();
                process.PriorityClass = FormOptions.priority;
                process.StandardInput.AutoFlush = true;
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

        public void Close()
        {
            try
            {
                if (process != null)
                {
                    process.OutputDataReceived -= OnDataReceived;
                    Clear();
                    Quit();
                    process.WaitForExit(100);
                    if (!process.HasExited)
                        process.Kill();
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
