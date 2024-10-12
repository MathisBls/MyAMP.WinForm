using System;
using System.Windows.Forms;
using Stripe;
using Microsoft.Extensions.Configuration;

namespace MyAMP
{
    public partial class Subscription : Form
    {
        public Subscription()
        {
            InitializeComponent();
            ConfigureStripe();
        }

        private void ConfigureStripe()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../..")) // Gardez ce chemin
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
        }

        private void buttonSubmitPayment_Click_1(object sender, EventArgs e)
        {
            // Supposons que vous ayez des TextBox pour chaque champ
            string cardNumber = txtCardNumber.Text; // TextBox pour le numéro de carte
            int expMonth = int.Parse(txtExpMonth.Text); // TextBox pour le mois
            int expYear = int.Parse(txtExpYear.Text); // TextBox pour l'année
            string cvc = txtCVC.Text; // TextBox pour le CVV

            // Vérifiez que les champs ne sont pas vides
            if (string.IsNullOrWhiteSpace(cardNumber) ||
                string.IsNullOrWhiteSpace(txtExpMonth.Text) ||
                string.IsNullOrWhiteSpace(txtExpYear.Text) ||
                string.IsNullOrWhiteSpace(cvc))
            {
                MessageBox.Show("Veuillez remplir tous les champs.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Créer une carte source
                var options = new SourceCreateOptions
                {
                    Type = "card",
                    Card = new SourceCardOptions
                    {
                        Number = cardNumber,
                        ExpMonth = expMonth,
                        ExpYear = expYear,
                        Cvc = cvc,
                    },
                };

                var service = new SourceService();
                Source source = service.Create(options);

                // Utiliser le token de la source pour créer un paiement
                var chargeOptions = new ChargeCreateOptions
                {
                    Amount = 5000, // Montant en cents (ex: 50,00 USD)
                    Currency = "usd",
                    Source = source.Id,
                    Description = "Achat d'abonnement",
                };

                var chargeService = new ChargeService();
                Charge charge = chargeService.Create(chargeOptions);

                // Afficher le message de succès
                MessageBox.Show($"Paiement réussi ! ID de la transaction : {charge.Id}", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (StripeException stripeEx)
            {
                // Gérer les exceptions spécifiques à Stripe
                MessageBox.Show($"Erreur Stripe : {stripeEx.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Gérer d'autres exceptions
                MessageBox.Show($"Erreur lors du traitement du paiement : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
