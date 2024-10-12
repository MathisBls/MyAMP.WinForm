using System;
using System.ServiceProcess;

public class ServiceManager
{
    private Button startApache;
    private Button startMySQL;
    private Panel statusApacheCircle;
    private Panel statusSQLCircle;

    public ServiceManager(Button startApache, Button startMySQL, Panel statusApacheCircle, Panel statusSQLCircle)
    {
        this.startApache = startApache;
        this.startMySQL = startMySQL;
        this.statusApacheCircle = statusApacheCircle;
        this.statusSQLCircle = statusSQLCircle;
    }

    public void StartService(string serviceName)
    {
        try
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                if (service.Status != ServiceControllerStatus.Running)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                    MessageBox.Show($"{serviceName} a démarré avec succès.");
                }
                else
                {
                    MessageBox.Show($"{serviceName} est déjà en cours d'exécution.");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors du démarrage de {serviceName}: {ex.Message}");
        }
    }

    public void StopService(string serviceName)
    {
        try
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                if (service.Status != ServiceControllerStatus.Stopped)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                    MessageBox.Show($"{serviceName} a été arrêté avec succès.");
                }
                else
                {
                    MessageBox.Show($"{serviceName} est déjà arrêté.");
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de l'arrêt de {serviceName}: {ex.Message}");
        }
    }

    public bool IsServiceRunning(string serviceName)
    {
        try
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                return service.Status == ServiceControllerStatus.Running;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erreur lors de la vérification de {serviceName}: {ex.Message}");
            return false;
        }
    }

    public void UpdateServiceButtons()
    {
        // Pour Apache
        if (IsServiceRunning("Apache2.4"))
        {
            startApache.Text = "Stop Apache";
            startApache.ForeColor = Color.FromArgb(255, 30, 70);
            statusApacheCircle.BackColor = Color.Green;
        }
        else
        {
            startApache.Text = "Start Apache";
            startApache.ForeColor = Color.White;
            statusApacheCircle.BackColor = Color.Red;
        }

        // Pour MySQL
        if (IsServiceRunning("MySQL"))
        {
            startMySQL.Text = "Stop MySQL";
            startMySQL.ForeColor = Color.FromArgb(255, 30, 70);
            statusSQLCircle.BackColor = Color.Green;
        }
        else
        {
            startMySQL.Text = "Start MySQL";
            startMySQL.ForeColor = Color.White;
            statusSQLCircle.BackColor = Color.Red;
        }
    }
}
