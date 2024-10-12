using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using BCrypt.Net; // Assure-toi d'avoir ajouté la référence BCrypt.Net

namespace MyAMP
{
    public partial class Register : Form
    {
        private readonly DatabaseConnection dbConnection;

        public Register()
        {
            InitializeComponent();
            dbConnection = new DatabaseConnection();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;
            string confirmPassword = textBoxConfirmPassword.Text;
            DateTime subscriptionStart = DateTime.Now;
            DateTime subscriptionEnd = subscriptionStart.AddMonths(1);
            int subscriptionId = 1;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Le mot de passe doit contenir au moins 8 caractères, une majuscule, une minuscule et un chiffre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                dbConnection.OpenConnection();

                string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @Email OR username = @Username";
                MySqlCommand checkCmd = new MySqlCommand(checkQuery, dbConnection.GetConnection());
                checkCmd.Parameters.AddWithValue("@Email", email);
                checkCmd.Parameters.AddWithValue("@Username", username);

                int userExists = Convert.ToInt32(checkCmd.ExecuteScalar());
                if (userExists > 0)
                {
                    MessageBox.Show("L'utilisateur ou l'email existe déjà.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

                string insertQuery = @"INSERT INTO users (username, email, password, subscription_start, subscription_end, subscription_id)
                                       VALUES (@Username, @Email, @Password, @SubscriptionStart, @SubscriptionEnd, @SubscriptionId)";

                MySqlCommand insertCmd = new MySqlCommand(insertQuery, dbConnection.GetConnection());
                insertCmd.Parameters.AddWithValue("@Username", username);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@Password", hashedPassword);
                insertCmd.Parameters.AddWithValue("@SubscriptionStart", subscriptionStart);
                insertCmd.Parameters.AddWithValue("@SubscriptionEnd", subscriptionEnd);
                insertCmd.Parameters.AddWithValue("@SubscriptionId", subscriptionId);

                insertCmd.ExecuteNonQuery();

                int userId = (int)insertCmd.LastInsertedId;

                CreateSession(userId);

                MessageBox.Show("Inscription réussie! Connexion en cours...", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                Form1 mainForm = new Form1();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'inscription : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private bool IsValidPassword(string password)
        {
            if (password.Length < 8) return false;
            bool hasUpperCase = false, hasLowerCase = false, hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
            }

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        private void CreateSession(int userId)
        {

            Session.UserId = userId;
        }
    }

    public static class Session
    {
        public static int UserId { get; set; }
    }
}
