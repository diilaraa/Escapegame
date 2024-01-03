using EscapeLibrary.Concrete;
using EscapeLibrary.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Escapegame
{
    public partial class Menu : Form

    {
        public Menu()
        {
            InitializeComponent();
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            level1 level1page = new level1();
            level1page.ShowDialog();

        }

        private void btn_options_Click(object sender, EventArgs e)
        {
            option optionpage = new option();
            optionpage.ShowDialog();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                level1 level1page = new level1();
                level1page.ShowDialog();


            }
        }

        private void skorlar_Click(object sender, EventArgs e)
        {
                Skorlar skorformu = new Skorlar();
                skorformu.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            level1 level1page = new level1();
            level1page.ShowDialog();
        }
    }
}

