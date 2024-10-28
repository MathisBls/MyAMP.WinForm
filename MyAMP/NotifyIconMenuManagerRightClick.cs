using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class NotifyIconMenuManagerRightClick
{
    private NotifyIcon _notifyIcon;
    private ContextMenuStrip _contextMenu;
    private Form _mainForm; 

    public NotifyIconMenuManagerRightClick(NotifyIcon notifyIcon, Form mainForm)
    {
        _notifyIcon = notifyIcon;
        _mainForm = mainForm; 
        _contextMenu = new ContextMenuStrip();

        _contextMenu.Renderer = new CustomContextMenuRenderer();

        _contextMenu.Items.Add("Afficher les logs", null, ShowLogs_Click);
        _contextMenu.Items.Add("Configurer Apache", null, ConfigureApache_Click);
        _contextMenu.Items.Add("Configurer MySQL", null, ConfigureMySQL_Click);
        _contextMenu.Items.Add(new ToolStripSeparator());
        _contextMenu.Items.Add("Redémarrer les services", null, RestartServices_Click);
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

    private void ShowLogs_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Affichage des logs d'Apache et MySQL", "Logs");
    }

    private void ConfigureApache_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Ouvrir la configuration d'Apache");
    }

    private void ConfigureMySQL_Click(object sender, EventArgs e)
    {
        MessageBox.Show("Ouvrir la configuration de MySQL");
    }

    private void RestartServices_Click(object sender, EventArgs e)
    {
        Process.Start("cmd.exe", "/C net stop Apache2.4 && net start Apache2.4");
        Process.Start("cmd.exe", "/C net stop MySQL && net start MySQL");
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

    private bool IsClickInsideApplication()
    {
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
