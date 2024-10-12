using System;
using System.IO;
using System.Windows.Forms;

namespace MyAMP
{
    public partial class PrefGeneral : Form
    {
        private readonly string apacheConfigPath = @"C:\myamp\apache\Apache24\conf\httpd.conf";
        private readonly string mysqlConfigPath = @"C:\myamp\mysql\current\my.ini";

        public PrefGeneral()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            apachePortInput.Value = GetApachePortFromConfig();
            mysqlPortInput.Value = GetMySQLPortFromConfig();

            autoStartApacheCheckBox.Checked = Properties.Settings.Default.AutoStartApache;
            autoStopApacheCheckBox.Checked = Properties.Settings.Default.AutoStopApache;
            autoStartMySQLCheckBox.Checked = Properties.Settings.Default.AutoStartMySQL;
            autoStopMySQLCheckBox.Checked = Properties.Settings.Default.AutoStopMySQL;
        }

        private int GetApachePortFromConfig()
        {
            string[] lines = File.ReadAllLines(apacheConfigPath);
            foreach (string line in lines)
            {
                if (line.Contains("Define PORTLOCAL"))
                {
                    string portStr = line.Split('"')[1];
                    return int.Parse(portStr);
                }
            }
            return 80;
        }

        private int GetMySQLPortFromConfig()
        {
            string[] lines = File.ReadAllLines(mysqlConfigPath);
            foreach (string line in lines)
            {
                if (line.StartsWith("port"))
                {
                    string portStr = line.Split('=')[1].Trim();
                    return int.Parse(portStr);
                }
            }
            return 3306;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SetApachePortInConfig((int)apachePortInput.Value);
            SetMySQLPortInConfig((int)mysqlPortInput.Value);

            Properties.Settings.Default.AutoStartApache = autoStartApacheCheckBox.Checked;
            Properties.Settings.Default.AutoStopApache = autoStopApacheCheckBox.Checked;
            Properties.Settings.Default.AutoStartMySQL = autoStartMySQLCheckBox.Checked;
            Properties.Settings.Default.AutoStopMySQL = autoStopMySQLCheckBox.Checked;
            Properties.Settings.Default.Save();

            MessageBox.Show("Settings saved successfully.");
        }

        private void SetApachePortInConfig(int port)
        {
            string[] lines = File.ReadAllLines(apacheConfigPath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains("Define PORTLOCAL"))
                {
                    lines[i] = $"Define PORTLOCAL \"{port}\"";
                }
            }
            File.WriteAllLines(apacheConfigPath, lines);
        }

        private void SetMySQLPortInConfig(int port)
        {
            string[] lines = File.ReadAllLines(mysqlConfigPath);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].StartsWith("port"))
                {
                    lines[i] = $"port = {port}";
                }
            }
            File.WriteAllLines(mysqlConfigPath, lines);
        }

       
    }
}
