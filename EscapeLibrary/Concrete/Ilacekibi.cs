using EscapeLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeLibrary.Concrete
{
    internal class Ilacekibi : Cisim
    {
        public Ilacekibi(Size hareketAlanBoyut) : base(hareketAlanBoyut)
        {
            Random random = new Random();
            IlacinHareketMesafesi = 90;

            Name = "Ilacekibi";
            Size = new Size(70, 70);

            SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
