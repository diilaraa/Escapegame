using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EscapeLibrary.Interface;
using EscapeLibrary.Enum;
using System.Windows.Forms;
using System.Drawing;
using System.IO.Ports;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace EscapeLibrary.Concrete
{
    public class Oyun : IOyun
    {
        #region Alanlar

        private readonly Timer _gecenSureTimer = new Timer { Interval = 1000 };


        private readonly Panel _anaPanel;
        private Jerry _jerry;
        private Block[] _blocks = new Block[31];
        private Random random = new Random();
        private Label _levelLabel;
        private Label _canLabel;
        private Label _skorLabel;
        private Label _oyuncuLabel;
        #endregion
        private readonly Timer _TerlikZamanOlustur = new Timer { Interval = 3000 };
        private readonly Timer _bastanBaslatSuresi = new Timer { Interval = 6000 };
        private readonly Timer _ilacOlusturSuresi = new Timer { Interval = 2000 };
        private readonly Timer _ilaciHareketSure = new Timer { Interval = 1000 };

        #region Olaylar

        public event EventHandler GecenSureDegisti;


        #endregion

        #region Ozellikler
        public bool DevamEdiyorMu { get; private set; }

        private TimeSpan _gecenSure;
        public TimeSpan GecenSure
        {
            get => _gecenSure;
            private set
            {
                _gecenSure = value;

                GecenSureDegisti?.Invoke(this, EventArgs.Empty);
            }
        }
        public int _level = 1;
        public int _can = 3;
        public int _skor = 0;
        public int can
        { 
            get => _can;
            set { _can = value; }
        }
        public int skor
        {
            get => _skor;
            set
            {
                _skor = value;
            }
        }


        #endregion

        #region Metotlar

        public Oyun(Panel anaPanel, Label levelLabel, Label canLabel, Label skorLabel, Label oyuncuLabel)
        {
            _anaPanel = anaPanel;
            _levelLabel = levelLabel;
            _canLabel = canLabel;
            _skorLabel = skorLabel;
            _oyuncuLabel = oyuncuLabel;

            _gecenSureTimer.Tick += GecenSureTimer_Tick;
           _TerlikZamanOlustur.Tick += TerlikZamanOlustur_Tick;
            _bastanBaslatSuresi.Tick += BastanBaslatSuresi_Tick;
            /*_ilacOlusturSuresi.Tick += IlacOlusturSuresi_Tick;
            _ilaciHareketSure.Tick += IlaciHareketSure_Tick;*/

        }

        private void GecenSureTimer_Tick(object sender, EventArgs e)
        {
            GecenSure += TimeSpan.FromSeconds(1);
        }
        private void TerlikZamanOlustur_Tick(object sender, EventArgs e)
        {
            TerlikOlustur();
        }
        /*private void IlaciHareketSure_Tick(object sender, EventArgs e)
        {
            IlaciHareketettir();
        }

        private void IlacOlusturSuresi_Tick(object sender, EventArgs e)
        {
            IlaciOlustur();
        }*/
        private void BastanBaslatSuresi_Tick(object sender, EventArgs e)
        {
            BastanBaslat();
        }


        public void Baslat()
        {
            if (DevamEdiyorMu) return;
            DevamEdiyorMu = true;
            _gecenSureTimer.Start();

            JerryOlustur();
            BlockOlustur();
            TuzakOlustur();
            gizliKutuOlustur();
        }
        public void Durdur()
        {
            DevamEdiyorMu = !DevamEdiyorMu;
            if (DevamEdiyorMu)
            {
                switch (_level)
                {
                    case 1:
                        _gecenSureTimer.Start();
                        break;
                    case 2:
                        _gecenSureTimer.Start();
                        _TerlikZamanOlustur.Start();
                        _bastanBaslatSuresi.Start();
                        break;
                }
            }
            else
            {
                _gecenSureTimer.Stop();
                _TerlikZamanOlustur.Stop();
                _bastanBaslatSuresi.Stop();
            }
        }
       
        public void Hareket(Yon yon)
        {
            if (!DevamEdiyorMu) return;

            _jerry.HareketEttir(yon);
            TuzakKontrol();
            TerlikKontrol();
            BitisKontrol();
            gizliKutukontrol();

        }
        private void Suredur() //can kaybi icin olusturuldu
        {
            _gecenSureTimer.Stop();
            _TerlikZamanOlustur.Stop();
            _bastanBaslatSuresi.Stop();
            _ilacOlusturSuresi.Stop();
            _ilaciHareketSure.Stop();

        }
        private void JerryOlustur()
        {
            _jerry = new Jerry(_anaPanel.Height, _anaPanel.Size);

            _jerry.BringToFront();
            _jerry.Size = new Size(70, 70);
            _jerry.MaximumSize = new Size(70, 70);
            _jerry.MinimumSize = new Size(70, 70);
            _jerry.BackColor = Color.Transparent;
            _anaPanel.Controls.Add(_jerry);
        }
        private void gizliKutuOlustur()
        {
            while (true)
            {
                int number = random.Next(2, 30);
                if (number != 30 && _blocks[number].Name.StartsWith("Block"))
                {
                    _blocks[number].Name = "GizliKutu";
                    _blocks[number].Image = Image.FromFile(@"img\Peynir.png");
                    break;  // Döngüyü burada kırarak bir kez gizli kutu oluşturunca çıkmasını sağlayın.
                }
            }
        }

        private void gizliKutukontrol()
        {
            foreach (Control control in _anaPanel.Controls)
            {
                if (control is Block && control.Name.Contains("GizliKutu") && _jerry.Bounds.IntersectsWith(control.Bounds))
                {
                    double sanslimi = random.NextDouble();

                    switch (sanslimi < 0.8)
                    {
                        case true:
                            control.Name = "sansli";
                            CanArttir();
                            break;
                        case false:
                            control.Name = "sanssiz";
                            Cankaybi();
                            break;
                    }
                }
            }
        }


        protected void BlockOlustur()
        {
            
            int startX = 150;
            int startY = 70;

            int width = 100;
            int height = 100;

            

            for (int i = 0; i < 31; i++) // Oluşturulacak block sayısı
            {
                _blocks[i] = new Block(_anaPanel.Height, _anaPanel.Size)
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Name = "Block" + (i+1),
                    Size = new Size(100,100),
                    Location = new Point(startX, startY)
                };
                _blocks[i].SendToBack();
                _blocks[i].Click += Block_click;
                
                if (i == 30)
                {
                    _blocks[i].Name = "Finish";
                    _blocks[i].Size = new Size(130, 200);
                    _blocks[i].Location = new Point(1180,120);
                    _blocks[i].Click += Block_click;
                    _blocks[i].Image = Image.FromFile(@"img\Finish.png");
                }


                _anaPanel.Controls.Add(_blocks[i]);

                startY += height;
                if (startY + height > _anaPanel.Height)
                {
                    startY = 70;
                    startX += width;
                }
            }
        }
        private void Block_click(object sender, EventArgs e)
        {
            Block clicked = (Block)sender;
            MessageBox.Show(clicked.Name + " Clicked!"); // Tıklanan pictureBox'un ismini öğren.
        }

        public void TuzakOlustur()
        {
            Random random = new Random();

            // Blokları sıfırla
            foreach (var block in _blocks)
            {
                if (block.Name == "Finish")
                {
                    continue; // Finish bloğunu atla ve diğer bloklara geç
                }
                // Bloğun adını sıfırla
                block.Name = $"Block{_blocks.ToList().IndexOf(block):D2}";
            }

            // Tuzak sayacı
            int tuzakSayisi = 0;

            // Rastgele 10 bloğa tuzak adı ekle
            while (tuzakSayisi < 10)
            {
                var randomBlock = _blocks[random.Next(_blocks.Length)];

                // Eğer seçilen blok Block30 değilse ve daha önce tuzak eklenmediyse
                if (randomBlock.Name != "Finish" && !randomBlock.Name.StartsWith("Tuzak"))
                {
                    randomBlock.Name = $"Tuzak{tuzakSayisi:D2}";
                    tuzakSayisi++;
                }
            }


        }

        protected void TuzakKontrol()
        {
            foreach (var block in _blocks)
            {
                if (block.Name.Contains("Tuzak") && _jerry.Bounds.IntersectsWith(block.Bounds) && block.Name != "Block30")
                {
                    int blockIndex = int.Parse(block.Name.Substring(5));
                    Random tuzakSayisi = new Random();
                    int randomTuzak = tuzakSayisi.Next(1, 4);

                    switch (randomTuzak)
                    {
                        case 1:
                            block.Image = Image.FromFile(@"img\Kapan.png");
                            break;
                        case 2:
                            block.Image = Image.FromFile(@"img\Tahta.png");
                            break;
                        case 3:
                            block.Image = Image.FromFile(@"img\Tom.png");
                            break;
                        default:
                            break;
                    }
                    Cankaybi();
                    break; // Tuzak bulundu, döngüden çık
                }
            }
        }

        protected void TerlikOlustur()
        {
            BastanBaslat();

            for (int i = 0; i < 10; i++)
            {
                Block selectedBlock = null;

                do
                {
                    int randomIndex = random.Next(_blocks.Length);
                    selectedBlock = _blocks[randomIndex];
                }
                while (selectedBlock.Name == "Finish");

                int blockIndex = Array.IndexOf(_blocks, selectedBlock);
                selectedBlock.Name = $"Terlik{blockIndex + 1:D2}";
                selectedBlock.Image = Image.FromFile(@"img\Terlik.png");
            }

            TerlikKontrol();
        }

        private void BastanBaslat()
        {
            foreach (var block in _blocks)
            {
                _jerry.BringToFront();

                if (block.Name.StartsWith("Terlik"))
                {
                    block.Image = Image.FromFile(@"img\Block.png");
                    int blockIndex = Array.IndexOf(_blocks, block);
                    block.Name = $"Block{blockIndex + 1:D2}";
                }
            }
        }

        protected void TerlikKontrol()
        {
            foreach (Control control in _anaPanel.Controls)
            {
                if (control is Block && control.Name.Contains("Terlik") && _jerry.Bounds.IntersectsWith(control.Bounds)) // Bomba kontrolü
                {
                    Cankaybi();
                }
            }
        }
        
        protected void BitisKontrol()
        {
            foreach (var block in _blocks)
            {
                if (block.Name.Contains("Finish") && _jerry.Bounds.IntersectsWith(block.Bounds)) // Finish kontrolü
                {

                    Levelarttir();
                }
            }
        }
        protected void Levelarttir()
        {
            Destroy();
            _level++;
            CanArttir();
            switch (_level)
            {
                case 2:
                    BlockOlustur();
                    JerryOlustur();
                    TerlikOlustur();
                    gizliKutuOlustur();
                    _TerlikZamanOlustur.Start();
                    _bastanBaslatSuresi.Start();
                    _levelLabel.Text = Convert.ToString(_level);
                    _canLabel.Text = Convert.ToString(can);
                    break;
                case 3:
                    _jerry.BringToFront();
                    _TerlikZamanOlustur.Stop();
                    _bastanBaslatSuresi.Stop();
                    gizliKutuOlustur();
                    BlockOlustur();
                    JerryOlustur();
                    _ilaciHareketSure.Start();
                    _ilacOlusturSuresi.Start();
                    _levelLabel.Text = Convert.ToString(_level);
                    _canLabel.Text = Convert.ToString(can);
                    break;
                    


            }
        }
        private void Destroy()
        {
            _anaPanel.Controls.Remove(_jerry);
            BlockKaldir();
        }
        private void BlockKaldir()
        {
            foreach (var block in _blocks)
            {
                if (!block.Name.Contains("Block30"))
                {
                    _anaPanel.Controls.Remove(block);
                }
            }
        }

        private void skorHesapla()
        {
            _skor = _can * 500 + (1000 - GecenSure.Seconds);
            string s = _skorLabel.Text = Convert.ToString(_skor);
        }
        private void skorYaz()
        {
            using (StreamWriter writer = new StreamWriter("Scores.txt", true))
            {
                writer.WriteLine($"Oyuncu ->{_skor}");
            }
        }






        private void Cankaybi()
        {
            _can--;
            if (_can > 0)
            {
                _canLabel.Text = Convert.ToString(can);
            }
            else if (_can == 0)
            {
                _canLabel.Text = Convert.ToString(can);
                Suredur();
                MessageBox.Show("Oyun Bitti !!!");
            }
        }
        private void CanArttir()
        {
            _can++;
            _canLabel.Text = Convert.ToString(can);
        }


        #endregion
    }
}

