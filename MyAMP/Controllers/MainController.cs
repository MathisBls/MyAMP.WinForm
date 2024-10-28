using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAMP.Controllers
{
    public class MainController
    {
        private Form activeForm;
        private Panel panelContainer;

        public MainController(Panel container)
        {
            panelContainer = container;
        }

        public void OpenChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void ShowSubMenu(Panel subMenu)
        {
            subMenu.Visible = !subMenu.Visible;
        }
    }
}