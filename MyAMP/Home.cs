using System;
using System.IO;
using System.Windows.Forms;
using Salaros.Configuration;

namespace MyAMP
{
    public partial class Home : Form
    {
        private readonly string iniFilePath = "myamp.ini";
        private ConfigParser config;

        public Home()
        {
            InitializeComponent();
            DocumentRoot.ReadOnly = true; // On rend le champ DocumentRoot non modifiable manuellement
            LoadSettings(); // Chargement initial des paramètres depuis le fichier INI
        }

        private void LoadSettings()
        {
            if (File.Exists(iniFilePath))
            {
                config = new ConfigParser(iniFilePath);
                DocumentRoot.Text = config.GetValue("Paths", "DocumentRoot", "C:/<tools>/<www>");
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
            config.SetValue("Paths", "DocumentRoot", "C:/<tools>/<www>");
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
            }
        }

        private void UpdateDocumentRootTextBox(string path)
        {
            string formattedPath = path.Replace("\\", " < ");
            DocumentRoot.Clear();

            foreach (string part in formattedPath.Split(' '))
            {
                if (part.Contains("< "))
                {
                    DocumentRoot.AppendText(part.Substring(0, part.IndexOf("<")));
                    DocumentRoot.SelectionStart = DocumentRoot.Text.Length;
                    DocumentRoot.SelectionLength = 0;
                    DocumentRoot.AppendText("<");
                }
                else
                {
                    DocumentRoot.AppendText(part + " ");
                }
            }
        }

        private void ServerName_TextChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            CustomMessageBox customMessageBox = new CustomMessageBox("Settings updated successfully!");
            customMessageBox.ShowDialog();

        }
    }
}
