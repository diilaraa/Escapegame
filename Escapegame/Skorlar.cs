using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Escapegame
{
    public partial class Skorlar : Form
    {
        public Skorlar()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        private void Skorlar_Load(object sender, EventArgs e)
        {
            skorlariGoster();
        }
        private void skorlariGoster()
        {
            table.Columns.Add("Oyuncu", typeof(string));
            table.Columns.Add("Skor", typeof(string));
            SkorGrid.DataSource = table;

            string scorePath = "scores.txt";
            string[] lines = File.ReadAllLines(scorePath);

            foreach (var line in lines)
            {
                string[] values = line.Split(new string[] { "->" }, StringSplitOptions.RemoveEmptyEntries);

                if (values.Length == 3)
                {
                    string oyuncu = values[1].Trim();
                    int skor;

                    if (int.TryParse(values[2].Trim(), out skor))
                    {
                        object[] rowValues = { oyuncu, skor };
                        table.Rows.Add(rowValues);
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz skor değeri: " + values[2]);
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz satır formatı: " + line);
                }
            }
        }
    }
}
