using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeLibrary.Enum;

namespace EscapeLibrary.Interface
{
    internal interface IOyun //internal sadece bu projenin içerisinde kullanılır.
    {
        event EventHandler GecenSureDegisti;
        bool DevamEdiyorMu { get; }
        TimeSpan GecenSure { get; }
        void Baslat();
        void Durdur();
        void Hareket(Yon yon);
    }
}
