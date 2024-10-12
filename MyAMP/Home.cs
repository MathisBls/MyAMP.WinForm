using System;
using System.IO;
using System.ServiceProcess; // Pour utiliser ServiceController
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks; // Pour utiliser Task
using Salaros.Configuration;

namespace MyAMP
{
    public partial class Home : Form
    {
        private readonly string iniFilePath = "myamp.ini";
        private ConfigParser config;
        private readonly string hostsFilePath = @"C:\Windows\System32\drivers\etc\hosts";
        private readonly string httpdConfFilePath = @"C:\myamp\apache\Apache24\conf\httpd.conf";
        private System.Windows.Forms.Timer loaderTimer;
        private string currentLoaderState = "";
        private bool isLoaderIncreasing = true;
        private Button activeLoaderButton = null;
        private Panel statusSQLCircle;
        private Panel statusApacheCircle;

        public Home()
        {
            InitializeComponent();

            #region StatusCircle
            statusSQLCircle = new Panel();
            statusSQLCircle.Size = new Size(10, 10);
            statusSQLCircle.BackColor = Color.Red;
            statusSQLCircle.Location = new Point(250, 380);

            statusApacheCircle = new Panel();
            statusApacheCircle.Size = new Size(10, 10);
            statusApacheCircle.BackColor = Color.Red;
            statusApacheCircle.Location = new Point(520, 380);

            statusSQLCircle.Paint += (sender, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath();
                circlePath.AddEllipse(0, 0, statusSQLCircle.Width, statusSQLCircle.Height);
                statusSQLCircle.Region = new Region(circlePath);
            };

            statusApacheCircle.Paint += (sender, e) =>
            {
                System.Drawing.Drawing2D.GraphicsPath circlePath = new System.Drawing.Drawing2D.GraphicsPath();
                circlePath.AddEllipse(0, 0, statusApacheCircle.Width, statusApacheCircle.Height);
                statusApacheCircle.Region = new Region(circlePath);
            };

            this.Controls.Add(statusSQLCircle);
            this.Controls.Add(statusApacheCircle);

            #endregion

            DocumentRoot.ReadOnly = true;
            LoadSettings();
            UpdateServiceButtons();
            InitializeLoaderTimer();
            startMySQL.Cursor = Cursors.Hand;
            startApache.Cursor = Cursors.Hand;
        }

        private void LoadSettings()
        {
            if (File.Exists(iniFilePath))
            {
                config = new ConfigParser(iniFilePath);
                DocumentRoot.Text = config.GetValue("Paths", "DocumentRoot", "C:/<myamp>/<www>");
                ServerName.Text = config.GetValue("Server", "ServerName", "localhost");
            }
            else
            {
                CreateDefaultIniFile();
            }
        }

        private void CreateDefaultIniFile()
        {
            config = new ConfigParser();
            config.SetValue("Paths", "DocumentRoot", "C:/<myamp>/<www>");
            config.SetValue("Server", "ServerName", "localhost");
            config.Save(iniFilePath);
        }

        private void SaveSettings()
        {
            if (config == null)
            {
                config = new ConfigParser(iniFilePath);
            }

            config.SetValue("Paths", "DocumentRoot", DocumentRoot.Text);
            config.SetValue("Server", "ServerName", ServerName.Text);
            config.Save(iniFilePath);
        }

        private void browse_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.Description = "Select folder for Document Root";
            folderBrowserDialog1.ShowNewFolderButton = false;

            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = folderBrowserDialog1.SelectedPath;
                UpdateDocumentRootTextBox(selectedPath);
                SaveSettings();
                UpdateHttpdConf();
                RestartApacheService();
            }
        }

        private void UpdateDocumentRootTextBox(string path)
        {
            string formattedPath = path.Replace("\\", "/"); // Remplacer les barres obliques inversées par des barres obliques
            DocumentRoot.Clear(); // Effacer le contenu précédent
            DocumentRoot.AppendText(formattedPath); // Remplir le champ avec le chemin formaté
        }


        private void ServerName_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
            UpdateHostsFile();
            UpdateHttpdConf();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            UpdateHostsFile();
            UpdateHttpdConf();
            CustomMessageBox customMessageBox = new CustomMessageBox("Settings updated successfully!");
            customMessageBox.ShowDialog();
        }

        private void UpdateHostsFile()
        {
            string serverName = ServerName.Text;
            bool replaced = false;

            if (File.Exists(hostsFilePath))
            {
                var lines = File.ReadAllLines(hostsFilePath);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("# Localhost"))
                    {
                        lines[i] = $"127.0.0.1   {serverName}   # Localhost";
                        replaced = true;
                    }
                }

                if (!replaced)
                {
                    using (StreamWriter sw = File.AppendText(hostsFilePath))
                    {
                        sw.WriteLine($"127.0.0.1   {serverName}   # Localhost");
                    }
                }
                else
                {
                    File.WriteAllLines(hostsFilePath, lines);
                }
            }
        }

        private void UpdateHttpdConf()
        {
            string serverName = ServerName.Text.Trim();
            string documentRoot = DocumentRoot.Text.Trim(); 

            if (File.Exists(httpdConfFilePath))
            {
                var lines = File.ReadAllLines(httpdConfFilePath);
                bool documentRootUpdated = false; 
                string defineDocumentRoot = $"Define DOCROOT \"{documentRoot}\""; 

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("ServerName"))
                    {
                        lines[i] = $"ServerName {serverName}:80";
                    }

                    if (lines[i].StartsWith("Define DOCROOT"))
                    {
                        lines[i] = defineDocumentRoot; 
                    }

                    if (lines[i].StartsWith("DocumentRoot"))
                    {
                        lines[i] = $"DocumentRoot \"${{DOCROOT}}\"";
                    }

                    if (lines[i].Trim().StartsWith("<Directory"))
                    {
                        if (lines[i].Contains("C:/myamp/www"))
                        {
                            lines[i] = $"<Directory \"${{DOCROOT}}\">"; 
                        }
                    }
                }

                if (documentRootUpdated || lines.Any(line => line.StartsWith("Define DOCROOT")))
                {
                    File.WriteAllLines(httpdConfFilePath, lines);
                }
            }
        }
        private void RestartApacheService()
        {
            var restartProcess = new System.Diagnostics.Process();
            restartProcess.StartInfo.FileName = "cmd.exe";
            restartProcess.StartInfo.Arguments = "/C net stop Apache2.4 && net start Apache2.4";
            restartProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            restartProcess.Start();
            restartProcess.WaitForExit();
        }


        public void UpdateServiceButtons()
        {
            if (IsServiceRunning("Apache2.4"))
            {
                startApache.Text = "Stop Apache";
                startApache.ForeColor = System.Drawing.Color.FromArgb(255, 30, 70);
                statusApacheCircle.BackColor = Color.Green;
            }
            else
            {
                startApache.Text = "Start Apache";
                startApache.ForeColor = System.Drawing.Color.White;
                statusApacheCircle.BackColor = Color.Red;
            }

            if (IsServiceRunning("MySQL"))
            {
                startMySQL.Text = "Stop MySQL";
                startMySQL.ForeColor = System.Drawing.Color.FromArgb(255, 30, 70);
                statusSQLCircle.BackColor = Color.Green;
            }
            else
            {
                startMySQL.Text = "Start MySQL";
                startMySQL.ForeColor = System.Drawing.Color.White;
                statusSQLCircle.BackColor = Color.Red;
            }
        }


        private bool IsServiceRunning(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    return service.Status == ServiceControllerStatus.Running;
                }
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        private void startApache_Click(object sender, EventArgs e)
        {
            activeLoaderButton = startApache;
            StartLoader();

            string apacheServiceName = "Apache2.4";
            try
            {
                if (IsServiceRunning(apacheServiceName))
                {
                    StopService(apacheServiceName);
                    startApache.Text = "Start Apache";
                }
                else
                {
                    StartService(apacheServiceName);
                    startApache.Text = "Stop Apache";
                }
                UpdateServiceButtons();
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox($"Failed to control Apache service:\n {ex.Message}");
                customMessageBox.ShowDialog();
            }
            StopLoader();
        }

        private void startMySQL_Click(object sender, EventArgs e)
        {
            activeLoaderButton = startMySQL;
            StartLoader();

            string mysqlServiceName = "MySQL";
            try
            {
                if (IsServiceRunning(mysqlServiceName))
                {
                    StopService(mysqlServiceName);
                    startMySQL.Text = "Start MySQL";
                }
                else
                {
                    StartService(mysqlServiceName);
                    startMySQL.Text = "Stop MySQL";
                }
                UpdateServiceButtons();
            }
            catch (Exception ex)
            {
                CustomMessageBox customMessageBox = new CustomMessageBox($"Failed to control MySQL service:\n {ex.Message}");
                customMessageBox.ShowDialog();
            }
            StopLoader();
        }


        public void StartService(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10)); // Attend 10 secondes que le service démarre
                }

                CustomMessageBox customMessageBox = new CustomMessageBox($"{serviceName} started successfully.");
                customMessageBox.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start {serviceName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateServiceButtons();
            }
        }

        public void StopService(string serviceName)
        {
            try
            {
                using (ServiceController service = new ServiceController(serviceName))
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(10)); // Attend 10 secondes que le service s'arrête
                }

                CustomMessageBox customMessageBox = new CustomMessageBox($"{serviceName} stopped successfully.");
                customMessageBox.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to stop {serviceName}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                UpdateServiceButtons();
            }
        }

      
        private void InitializeLoaderTimer()
        {
            loaderTimer = new System.Windows.Forms.Timer();
            loaderTimer.Interval = 500;
            loaderTimer.Tick += LoaderTimer_Tick;
        }

        private void StartLoader()
        {
            currentLoaderState = "";
            isLoaderIncreasing = true;
            loaderTimer.Start();
        }

        private void StopLoader()
        {
            activeLoaderButton = null;
            loaderTimer.Stop();
        }


        private void LoaderTimer_Tick(object sender, EventArgs e)
        {
            if (activeLoaderButton == null) return;

            if (isLoaderIncreasing)
            {
                if (currentLoaderState.Length < 3)
                {
                    currentLoaderState += ".";
                }
                else
                {
                    isLoaderIncreasing = false;
                }
            }
            else
            {
                if (currentLoaderState.Length > 0)
                {
                    currentLoaderState = currentLoaderState.Substring(0, currentLoaderState.Length - 1);
                }
                else
                {
                    isLoaderIncreasing = true;
                }
            }

            activeLoaderButton.Text = (activeLoaderButton == startApache)
                ? (IsServiceRunning("Apache2.4") ? "Stop Apache" : "Start Apache")
                : (IsServiceRunning("MySQL") ? "Stop MySQL" : "Start MySQL");

            activeLoaderButton.Text += currentLoaderState;
        }

        private void DocumentRoot_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
