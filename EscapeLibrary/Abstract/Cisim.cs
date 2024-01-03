using EscapeLibrary.Enum;
using EscapeLibrary.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EscapeLibrary.Abstract
{
    internal abstract class Cisim : PictureBox, IHareketEden
    {
        public Size HareketAlanBoyut { get; }

        public int HareketMesafesi { get; protected set; }

        public int IlacinHareketMesafesi{ get; protected set; }
        public new int Right
        {
            get => base.Right;
            set => Left = value - Width; // Set özelliği olan bir Right oluşturduk.
        }
        public new int Bottom // Set özelliği olan bir Bottom oluşturuldu.
        {
            get => base.Bottom;
            set => Top = value - Height;
        }
        protected Cisim(Size hareketAlanBoyut) 
        {
            Image = Image.FromFile($@"img\{GetType().Name}.png");
            HareketAlanBoyut = hareketAlanBoyut;
            SizeMode = PictureBoxSizeMode.StretchImage;
        }
        public bool HareketEttir(Yon yon)
        {
            switch (yon)
            {
                case Yon.Yukari:
                   return YukariHareketEttir();
                case Yon.Saga:
                    return SagaHareketEttir();
                case Yon.Sola:
                    return SolaHareketEttir();
                case Yon.Asagi:
                    return AsagiHareketEttir();
                default:
                    throw new ArgumentOutOfRangeException(nameof(yon), yon, null);
            }
        }

        private bool AsagiHareketEttir()
        {
            if (Bottom == HareketAlanBoyut.Width - 80) return true;

            var yeniBottom = Bottom + HareketMesafesi; 
            var tasicakMi = yeniBottom > HareketAlanBoyut.Height - 80;

            Bottom = tasicakMi ? HareketAlanBoyut.Height - 80 : yeniBottom; // Set özelliği verdiğimiz Right'ı kullanıyoruz

            return Bottom == HareketAlanBoyut.Height - 80;
        }

        private bool SolaHareketEttir()
        {
            if (Left == 60) return true;
            var yeniLeft = Left - HareketMesafesi; // Jerry için belirlenmiş mesafe kadar hareket eder!
            var tasacakMi = yeniLeft < 60;
            Left = tasacakMi ? 60 : yeniLeft;

            return Left == 60;
        }

        private bool SagaHareketEttir()
        {
            if (Right == HareketAlanBoyut.Width - 60) return true;

            var yeniRight = Right + HareketMesafesi; // Jerry için belirlenmiş mesafe kadar hareket eder !!!!!!
            var tasacakMi = yeniRight > HareketAlanBoyut.Width - 60;

            Right = tasacakMi ? HareketAlanBoyut.Width - 60 : yeniRight; // Set özelliği verdiğimiz Right'ı kullanıyoruz

            return Right == HareketAlanBoyut.Width - 60;
        }

        private bool YukariHareketEttir()
        {
            if (Top == 80) return true; // Eğer çarptıysa Bool değişkeni true olacak.
            var yeniTop = Top - HareketMesafesi; // Set özelliği eklediğimiz Top property'sini kullandık.
            var tasicakMi = yeniTop < 80;
            Top =tasicakMi ? 80 : yeniTop; // Hareket alanı hareket mesafesinden az ise hareket alanı kadar hareket edecek

            return Top == 80;
        }
    }
}

