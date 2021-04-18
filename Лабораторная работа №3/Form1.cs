using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лабораторная_работа__3
{
    public partial class Minesweeper : Form
    {
        const int maxwidth = 64;
        const int maxheigh = 32;
        int[] dx = new int[] { -1, 0, 1, -1, 1, -1, 0, 1 };
        int[] dy = new int[] { 1, 1, 1, 0, 0, -1, -1, -1 }; 
        int[] px = new int[] { 1, -1, 0, 0, 1, -1, 1, -1 };   // смещение координат(это в 4 направлениях)
        int[] py = new int[] { 0, 0, 1, -1, 1, 1, -1, -1 };
        public int nWidth;     // ширина поля
        public int nHeight;        
        public int nMineCnt; //колво мин
        bool bMouseLeft;    // левая или правая кнопка мыши нажаты ли 
        bool bMouseRight;
        bool bGame; // окончена ли  игра
        int[,] pMine = new int[maxwidth, maxheigh];  
        int[,] pState = new int[maxwidth, maxheigh];
        Point MouseFocus;   

        public Minesweeper()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            nWidth = Properties.Settings.Default.Width;
            nHeight = Properties.Settings.Default.Height; // стандартные параметры
            nMineCnt = Properties.Settings.Default.MineCnt;
            UpdateSize();
            SelectLevel();
        }
        private void SetGame(int Width, int Height, int MineCnt) //установка игры
        {
            nWidth = Width;
            nHeight = Height;
            nMineCnt = MineCnt;
            UpdateSize();
        }
        private void SetGameBeginner()
        {
            SetGame(9, 9, 10);
        }
        private void SetGameIntermediate() 
        {
            SetGame(16, 16, 40);
        }
        private void SetGameExpert()
        {
            SetGame(30, 16, 99);
        }
        private void SelectLevel()
        {
            if (nWidth == 10 && nHeight == 10 && nMineCnt == 10)
            {
                easyToolStripMenuItem.Checked = true;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                settingsToolStripMenuItem.Checked = false;
            }
            else if (nWidth == 16 && nHeight == 16 && nMineCnt == 40)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = true;
                hardToolStripMenuItem.Checked = false;
                settingsToolStripMenuItem.Checked = false;
            }
            else if (nWidth == 30 && nHeight == 16 && nMineCnt == 99)
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = true;
                settingsToolStripMenuItem.Checked = false;
            }
            else
            {
                easyToolStripMenuItem.Checked = false;
                mediumToolStripMenuItem.Checked = false;
                hardToolStripMenuItem.Checked = false;
                settingsToolStripMenuItem.Checked = true;
            }
        }
        private void Minesweeper_Paint(object sender, PaintEventArgs e)
        {
            PaintGame(e.Graphics);
        }
        private void PaintGame(Graphics g) //графика игры
        {
            g.Clear(Color.White);   // очистка области рисовки
            int nOffsetX = 6;   // отклонение х
            int nOffsetY = 6 + menu.Height;   // отклонение с учетом меню
            for (int i = 1; i <= nWidth; i++)    
            {
                for (int j = 1; j <= nHeight; j++)   // столбцы
                {
                    if (pState[i, j] != 1)   
                    {
                        // фон
                        if (i == MouseFocus.X && j == MouseFocus.Y)  // 是否为高亮点
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.SandyBrown)), new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        else
                        {
                            g.FillRectangle(Brushes.SandyBrown, new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));   // 绘制雷区方块
                        }
                        // 绘制标记
                        if (pState[i, j] == 2)
                        {
                            g.DrawImage(Properties.Resources.Flag, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   // 绘制红旗
                        }
                        if (pState[i, j] == 3)
                        {
                            g.DrawImage(Properties.Resources.Doubt, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   // 绘制问号
                        }
                    }
                    else if (pState[i, j] == 1)  // 点开
                    {
                        // 绘制背景
                        if (MouseFocus.X == i && MouseFocus.Y == j)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightGray)), new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        else
                        {
                            g.FillRectangle(Brushes.LightGray, new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        // 绘制数字
                        if (pMine[i, j] > 0)
                        {
                            Brush DrawBrush = new SolidBrush(Color.Blue);    // 定义钢笔
                            // 各个地雷数目的颜色
                            if (pMine[i, j] == 2) { DrawBrush = new SolidBrush(Color.Green); }
                            if (pMine[i, j] == 3) { DrawBrush = new SolidBrush(Color.Red); }
                            if (pMine[i, j] == 4) { DrawBrush = new SolidBrush(Color.DarkBlue); }
                            if (pMine[i, j] == 5) { DrawBrush = new SolidBrush(Color.DarkRed); }
                            if (pMine[i, j] == 6) { DrawBrush = new SolidBrush(Color.DarkSeaGreen); }
                            if (pMine[i, j] == 7) { DrawBrush = new SolidBrush(Color.Black); }
                            if (pMine[i, j] == 8) { DrawBrush = new SolidBrush(Color.DarkGray); }
                            SizeF Size = g.MeasureString(pMine[i, j].ToString(), new Font("Consolas", 16));
                            g.DrawString(pMine[i, j].ToString(), new Font("Consolas", 16), DrawBrush, nOffsetX + 34 * (i - 1) + 1 + (32 - Size.Width) / 2, nOffsetY + 34 * (j - 1) + 1 + (32 - Size.Height) / 2);
                        }
                        // 绘制地雷
                        if (pMine[i, j] == -1)
                        {
                            g.DrawImage(Properties.Resources.Mine, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   // 绘制地雷
                        }
                    }
                }
            }
        }
        private void Minesweeper_Load(object sender, EventArgs e)
        {

        }
    }
}
