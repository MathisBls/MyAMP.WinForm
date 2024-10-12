using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MyAMP
{
    public partial class Profile : Form
    {
        private readonly DatabaseConnection dbConnection;
        private int userId;

        public Profile(int userId)
        {
            InitializeComponent();
            this.userId = userId; // Stocke l'ID de l'utilisateur
            dbConnection = new DatabaseConnection();
            LoadUserProfile();
        }

        private void LoadUserProfile()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "SELECT username, email, subscription_id FROM users WHERE id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());
                cmd.Parameters.AddWithValue("@userId", userId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Remplacer les labels par des textbox et pré-remplir les informations de l'utilisateur
                        textBoxUsername.Text = reader.GetString("username");
                        textBoxEmail.Text = reader.GetString("email");
                        textBoxSubscriptionType.Text = reader.GetInt32("subscription_id") == 1 ? "Basic" : "Premium";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement du profil: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void UpdateUserProfile()
        {
            try
            {
                dbConnection.OpenConnection();
                string query = "UPDATE users SET username = @username, email = @Email WHERE id = @userId";
                MySqlCommand cmd = new MySqlCommand(query, dbConnection.GetConnection());

                // Ajout des paramètres
                cmd.Parameters.AddWithValue("@username", textBoxUsername.Text);
                cmd.Parameters.AddWithValue("@Email", textBoxEmail.Text);
                cmd.Parameters.AddWithValue("@userId", userId);

                int result = cmd.ExecuteNonQuery(); // Exécute la mise à jour

                if (result > 0)
                {
                    MessageBox.Show("Profil mis à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Aucune modification effectuée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la mise à jour du profil: {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dbConnection.CloseConnection();
            }
        }

        private void buttonSaveChanges_Click_1(object sender, EventArgs e)
        {
            UpdateUserProfile();
        }
    }
}
