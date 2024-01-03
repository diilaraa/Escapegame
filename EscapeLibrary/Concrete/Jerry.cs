using EscapeLibrary.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EscapeLibrary.Concrete
{
    internal class Jerry : Cisim
    {
        public Jerry( int panelGenisligi, Size hareketAlanBoyut) :base (hareketAlanBoyut)
        { 
            Left = 65;
            Top= 85;
            HareketMesafesi = 100;
        }
    }
}
