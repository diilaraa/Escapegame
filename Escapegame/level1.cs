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

namespace Escapegame
{
    public partial class level1 : Form
    {
        private readonly Oyun _oyun;

        public level1()
        {
            InitializeComponent();
            _oyun = new Oyun(anaPanel, levelLabel, canLabel, skorLabel, oyuncuLabel);
            _oyun.GecenSureDegisti += Oyun_GecenSureDegisti;
        }


        private void level1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    _oyun.Hareket(Yon.Saga);
                    break;
                case Keys.Left:
                    _oyun.Hareket(Yon.Sola);
                    break;
                case Keys.Up:
                    _oyun.Hareket(Yon.Yukari);
                    break;
                case Keys.Down:
                    _oyun.Hareket(Yon.Asagi);
                    break;
                case Keys.P:
                    _oyun.Durdur();
                    break;
            }
        }
        private void Oyun_GecenSureDegisti(object sender, EventArgs e)
        {
            labelSure.Text = _oyun.GecenSure.ToString(@"mm\:ss");

        }

        private void level1_Load(object sender, EventArgs e)
        {
            _oyun.Baslat();
            this.KeyPreview = true;

        }

        
    }
}

