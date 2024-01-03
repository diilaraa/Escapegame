using EscapeLibrary.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeLibrary.Interface
{
    
    internal interface IHareketEden
    {
        Size HareketAlanBoyut { get; }
        int HareketMesafesi { get; }
        /// <summary>
        /// Cismi istenilen yonde hareket ettirir
        /// </summary>
        /// <param name="yon"> Hangi yonde hareket edilecegi</param>
        /// <returns>Cisim duvara carparsa true dondurur</returns>
        bool HareketEttir(Yon yon);
    }
}
