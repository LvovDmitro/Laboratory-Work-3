using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_работа__3
{
    public partial class Settings : Form
    {
        Minesweeper Main;
        public Settings(Minesweeper main)
        {
            InitializeComponent();
            Main = main; //передача экземпляра род
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            numericUpDownwidth.Value = Convert.ToDecimal(Main.nWidth);
            numericUpheight.Value = Convert.ToDecimal(Main.nHeight);
            numericUpDownmine.Value = Convert.ToDecimal(Main.nMineCnt);
        }

        private void buttonok_Click(object sender, EventArgs e)
        {
            Main.nWidth = Convert.ToInt32(numericUpDownwidth.Value);
            Main.nHeight = Convert.ToInt32(numericUpheight.Value);
            Main.nMineCnt = Convert.ToInt32(numericUpDownmine.Value);
            this.Close();
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
