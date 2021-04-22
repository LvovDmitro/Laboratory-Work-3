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
    public partial class Highscores : Form
    {
        public Highscores()
        {
            InitializeComponent();
        }

        private void Highscores_Load(object sender, EventArgs e)
        {
            double neasy = Properties.Settings.Default.Easy;
            double nmedium = Properties.Settings.Default.Medium;
            double nhard = Properties.Settings.Default.Hard;
            labeleasy.Text = String.Format("Easy:        {0}", neasy);
            labelmedium.Text = String.Format("Medium:    {0}", nmedium);
            labelhard.Text = String.Format("Hard:          {0}", nhard);
        }

        private void buttonreset_Click(object sender, EventArgs e)
        {
            labeleasy.Text = String.Format("Easy:        {0}", 999);
            labelmedium.Text = String.Format("Medium:    {0}", 999);
            labelhard.Text = String.Format("Hard:          {0}", 999);
            Properties.Settings.Default.Easy = 999;
            Properties.Settings.Default.Medium = 999;
            Properties.Settings.Default.Hard = 999;
            Properties.Settings.Default.Save();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
