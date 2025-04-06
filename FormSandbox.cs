using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace RapChessGui
{
    public partial class FormSandbox: Form
    {
        CProcess process = null;
        public static FormSandbox This;

        public FormSandbox()
        {
            This = this;
            InitializeComponent();
            richTextBox1.AddContextMenu();
            process = new CProcess(OnDataReceived);
            FormOptions.SetFontSize(this);
        }


        delegate void DeleMessage(string message);

        readonly DeleMessage deleMessage = new DeleMessage(NewMessage);

        private void OnDataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.Data))
                {
                    Invoke(deleMessage, new object[] { e.Data.Trim() });
                }
            }
            catch { }
        }

        static void NewMessage(string msg)
        {
            This.AppendText($"{msg}\n", Color.Black);
        }

        void AppendText(string txt, Color col)
        {
                richTextBox1.SelectionColor = col;
                richTextBox1.SelectedText = txt;
        }

        private void FormSandbox_FormClosing(object sender, FormClosingEventArgs e)
        {
            process.Terminate();
            if (e.CloseReason != CloseReason.FormOwnerClosing)
            {
                Hide();
                e.Cancel = true;
            }
        }

        private void FormSandbox_Shown(object sender, EventArgs e)
        {
            cbEngineList.Items.Clear();
            foreach (CEngine eng in FormChess.engineList)
                cbEngineList.Items.Add(eng.name);
        }

        private void cbEngineList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CEngine engine = FormChess.engineList.GetEngineByName(cbEngineList.Text);
            if (engine != null)
            {
                process.SetProgram(engine.GetPath(), engine.arguments);
                richTextBox1.Clear();
            }
        }

        private void butSend_Click(object sender, EventArgs e)
        {   
            richTextBox1.Clear();
            foreach (string c in rtbCommand.Lines)
                process.WriteLine(c);
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Quit();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Restart();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Stop();
        }

        private void terminateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            process.Terminate();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fn = $@"Saves\Sandbox {DateTime.Now:yyyy-MM-dd hh-mm-ss}.rtf";
            richTextBox1.SaveFile(fn);
            MessageBox.Show($"File {fn} has been saved");
        }

        private void butRestart_Click(object sender, EventArgs e)
        {
            process.Restart();
        }
    }
}
