using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAMP
{
    public partial class Logs : Form
    {
        private string logFilePath = "C:\\myamp\\apache\\Apache24\\logs\\error.log"; // Chemin vers le fichier de logs
        private FileSystemWatcher fileWatcher;

        public Logs()
        {
            InitializeComponent();
            logsHistoric.Multiline = true;
            logsHistoric.ScrollBars = ScrollBars.Vertical;
            logsHistoric.ReadOnly = true;
            logsHistoric.WordWrap = true;

            Load += Logs_Load; // Abonnez-vous à l'événement Load pour démarrer la surveillance des logs
        }

        private void Logs_Load(object sender, EventArgs e)
        {
            StartLogMonitoring();
        }

        private void StartLogMonitoring()
        {
            if (!File.Exists(logFilePath))
            {
                ShowErrorMessage("Log file not found. Please check the path.");
                return;
            }

            fileWatcher = new FileSystemWatcher
            {
                Path = Path.GetDirectoryName(logFilePath),
                Filter = Path.GetFileName(logFilePath),
                NotifyFilter = NotifyFilters.LastWrite
            };

            fileWatcher.Changed += OnLogFileChanged;
            fileWatcher.EnableRaisingEvents = true;

            Task.Run(() => ReadExistingLogs());
        }

        private void ReadExistingLogs()
        {
            try
            {
                using (StreamReader sr = new StreamReader(logFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        bool isError = line.ToLower().Contains("error");
                        AddLog(line, isError);
                    }
                }
            }
            catch (IOException ex)
            {
                ShowErrorMessage("Unable to access log file.\n Please ensure that Apache is stopped.");
            }
        }

        private void OnLogFileChanged(object sender, FileSystemEventArgs e)
        {
            try
            {
                if (File.Exists(logFilePath))
                {
                    using (FileStream fs = new FileStream(logFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader sr = new StreamReader(fs))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                bool isError = line.ToLower().Contains("error");
                                AddLog(line, isError);
                            }
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                ShowErrorMessage("Unable to access log file.\n Please ensure that Apache is stopped.");
            }
        }

        public void AddLog(string message, bool isError = false)
        {
            if (logsHistoric.IsHandleCreated)
            {
                logsHistoric.BeginInvoke((MethodInvoker)delegate
                {
                    logsHistoric.AppendText(message + Environment.NewLine);
                    int start = logsHistoric.Text.Length - message.Length - 1;
                    logsHistoric.Select(start, message.Length);
                    logsHistoric.ForeColor = isError ? Color.FromArgb(255, 30, 70) : Color.White;
                    logsHistoric.SelectionStart = logsHistoric.Text.Length;
                    logsHistoric.ScrollToCaret();
                });
            }
        }

        private void saveLogs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.Title = "Save Logs";
                saveFileDialog.FileName = "logs.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    CustomMessageBox customMessageBox = new CustomMessageBox("Logs saved successfully.");
                    customMessageBox.ShowDialog();
                }
            }
        }

        private void ShowErrorMessage(string message)
        {
            CustomMessageBox customMessageBox = new CustomMessageBox(message);
            customMessageBox.ShowDialog();
        }
    }
}