using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class NotifyIconMenuManagerLeftClick
{
    private NotifyIcon _notifyIcon;
    private ContextMenuStrip _contextMenu;
    private Form _mainForm; // Référence à la fenêtre principale

    public NotifyIconMenuManagerLeftClick(NotifyIcon notifyIcon, Form mainForm)
    {
        _notifyIcon = notifyIcon;
        _mainForm = mainForm; // Initialisation de la référence à la fenêtre principale
        _contextMenu = new ContextMenuStrip();

        _contextMenu.Renderer = new CustomContextMenuRenderer();

        // Ajouter des éléments au menu contextuel (clic gauche)
        _contextMenu.Items.Add("Vérifier les versions", null, CheckVersions_Click);
        _contextMenu.Items.Add(new ToolStripSeparator());
        _contextMenu.Items.Add("Démarrer Apache", null, StartApache_Click);
        _contextMenu.Items.Add("Arrêter Apache", null, StopApache_Click);
        _contextMenu.Items.Add("Démarrer MySQL", null, StartMySQL_Click);
        _contextMenu.Items.Add("Arrêter MySQL", null, StopMySQL_Click);
        _contextMenu.Items.Add(new ToolStripSeparator());
        _contextMenu.Items.Add("Quitter", null, Quit_Click);
        // Abonnement à l'événement Closed pour fermer automatiquement le menu
        _contextMenu.Closed += ContextMenu_Closed;

        notifyIcon.Visible = true;
    }

    public void ShowMenu()
    {
        _contextMenu.Show(Control.MousePosition); // Afficher le menu à la position du curseur
        SetMouseHook(); // Activer le hook global pour capturer les clics extérieurs
    }

    private void ContextMenu_Closed(object sender, ToolStripDropDownClosedEventArgs e)
    {
        RemoveMouseHook(); // Désactiver le hook lorsque le menu est fermé
    }

    private void CheckVersions_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Apache: 2.4.46\nMySQL: 8.0.21\nPHP: 7.4.3", "Versions des services");
    }

    private void StartApache_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", "/C net start Apache2.4");
    }

    private void StopApache_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", "/C net stop Apache2.4");
    }

    private void StartMySQL_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", "/C net start MySQL");
    }

    private void StopMySQL_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", "/C net stop MySQL");
    }

    private void Quit_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    #region Mouse Hook

    private const int WH_MOUSE_LL = 14;
    private LowLevelMouseProc _proc;
    private IntPtr _hookID = IntPtr.Zero;

    // Déclaration du hook global pour capturer les clics de souris
    public void SetMouseHook()
    {
        _proc = HookCallback;
        _hookID = SetHook(_proc);
    }

    public void RemoveMouseHook()
    {
        UnhookWindowsHookEx(_hookID);
    }

    private IntPtr SetHook(LowLevelMouseProc proc)
    {
        using (var curProcess = Process.GetCurrentProcess())
        using (var curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_MOUSE_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

    private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && (wParam == (IntPtr)0x201 || wParam == (IntPtr)0x204)) // Left or right button down
        {
            // Vérifier si le clic est à l'extérieur du menu contextuel
            if (!_contextMenu.Bounds.Contains(Cursor.Position) && !IsClickInsideApplication())
            {
                _contextMenu.Close(); // Fermer le menu si le clic est à l'extérieur
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    // Méthode pour vérifier si le clic est à l'intérieur de la fenêtre de l'application
    private bool IsClickInsideApplication()
    {
        // Vérifier si le clic est à l'intérieur de la fenêtre principale de l'application
        return _mainForm.Bounds.Contains(Cursor.Position);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);

    #endregion
}
