﻿using System;
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
            Main = main;
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
