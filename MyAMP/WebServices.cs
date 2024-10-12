using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAMP
{
    public partial class WebServices : Form
    {
        public WebServices()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
        bool expandPHP = false;
        bool expandApache = false;
        bool expandSQL = false;

        private void timerPHP_Tick_1(object sender, EventArgs e)
        {
            HandleDropdownPHP();
        }

        private void timerApache_Tick(object sender, EventArgs e)
        {
            HandleDropdownApache();
        }

        private void timerSQL_Tick(object sender, EventArgs e)
        {
            HandleDropdownSQL();
        }

        #region HandleDropdown

        private void HandleDropdownPHP()
        {
            if (expandPHP == false)
            {
                dropdownContainerPHP.Height += 15;
                if (dropdownContainerPHP.Height >= dropdownContainerPHP.MaximumSize.Height)
                {
                    timerPHP.Stop();
                    expandPHP = true;
                }
            }
            else
            {
                dropdownContainerPHP.Height -= 15;
                if (dropdownContainerPHP.Height <= dropdownContainerPHP.MinimumSize.Height)
                {
                    timerPHP.Stop();
                    expandPHP = false;
                }
            }
        }

        private void HandleDropdownApache()
        {
            if (expandApache == false)
            {
                dropdownContainerApache.Height += 15;
                if (dropdownContainerApache.Height >= dropdownContainerApache.MaximumSize.Height)
                {
                    timerApache.Stop();
                    expandApache = true;
                }
            }
            else
            {
                dropdownContainerApache.Height -= 15;
                if (dropdownContainerApache.Height <= dropdownContainerApache.MinimumSize.Height)
                {
                    timerApache.Stop();
                    expandApache = false;
                }
            }
        }

        private void HandleDropdownSQL()
        {
            if (expandSQL == false)
            {
                dropdownContainerSQL.Height += 15;
                if (dropdownContainerSQL.Height >= dropdownContainerSQL.MaximumSize.Height)
                {
                    timerSQL.Stop();
                    expandSQL = true;
                }
            }
            else
            {
                dropdownContainerSQL.Height -= 15;
                if (dropdownContainerSQL.Height <= dropdownContainerSQL.MinimumSize.Height)
                {
                    timerSQL.Stop();
                    expandSQL = false;
                }
            }
        }

        #endregion

        private void buttonDropdownPHP_Click_1(object sender, EventArgs e)
        {
            timerPHP.Start();
        }

        private void buttonDropdownApache_Click(object sender, EventArgs e)
        {
            timerApache.Start();
        }

        private void buttonDropdownSQL_Click(object sender, EventArgs e)
        {
            timerSQL.Start();
        }
    }
}