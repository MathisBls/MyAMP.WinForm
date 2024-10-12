using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyAMP
{
    public partial class Login : Form
    {
        private readonly DatabaseConnection dbConnection;
        private Form1 mainForm;

        public Login(Form1 form)
        {
            InitializeComponent();
            mainForm = form;
            dbConnection = new DatabaseConnection();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            if (ValidateLogin(username, password))
            {
                Session.UserId = GetUserId(username);
                // Ouvrir le formulaire Profile avec la référence à Form1
                Profile profileForm = new Profile(Session.UserId);
                mainForm.openChildForm(profileForm);

                this.Hide(); // Cacher le formulaire de connexion
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateLogin(string username, string password)
        {
            // Implémentez votre logique de validation ici
            // Par exemple, vérifiez les informations d'identification dans la base de données
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT password FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@username", username);
                string storedPassword = cmd.ExecuteScalar()?.ToString(); // Récupérer le mot de passe stocké

                // Vérifier si le mot de passe est correct
                if (storedPassword != null)
                {
                    return BCrypt.Net.BCrypt.Verify(password, storedPassword); // Vérification du mot de passe
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la connexion: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return false;
        }

        private int GetUserId(string username)
        {
            // Récupérer l'ID de l'utilisateur
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT id FROM users WHERE username = @username";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@username", username);
                return Convert.ToInt32(cmd.ExecuteScalar()); // Convertir l'ID en entier
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération de l'ID utilisateur: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }

            return -1; // Retourner une valeur par défaut si une erreur se produit
        }
    }
}
