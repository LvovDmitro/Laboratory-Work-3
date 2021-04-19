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
        bool bMark;
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
            bMark = Properties.Settings.Default.Mark;

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
                        if (i == MouseFocus.X && j == MouseFocus.Y)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.SandyBrown)), new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        else
                        {
                            g.FillRectangle(Brushes.SandyBrown, new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));   // квадраты минного поля
                        }
                        if (pState[i, j] == 2)
                        {
                            g.DrawImage(Properties.Resources.Flag, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   // флаги
                        }
                        if (pState[i, j] == 3)
                        {
                            g.DrawImage(Properties.Resources.Doubt, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   
                        }
                    }
                    else if (pState[i, j] == 1) 
                    {
                        if (MouseFocus.X == i && MouseFocus.Y == j)
                        {
                            g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.LightGray)), new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        else
                        {
                            g.FillRectangle(Brushes.LightGray, new Rectangle(nOffsetX + 34 * (i - 1) + 1, nOffsetY + 34 * (j - 1) + 1, 32, 32));
                        }
                        if (pMine[i, j] > 0)
                        {
                            Brush DrawBrush = new SolidBrush(Color.Blue);    
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
                        if (pMine[i, j] == -1)
                        {
                            g.DrawImage(Properties.Resources.Mine, nOffsetX + 34 * (i - 1) + 1 + 4, nOffsetY + 34 * (j - 1) + 1 + 2);   
                        }
                    }
                }
            }
        }
        private void UpdateSize() //изменение размера в зависимости от окна
        {
            int nOffsetX = this.Width - this.ClientSize.Width;  // высота строки заголовка
            int nOffsetY = this.Height - this.ClientSize.Height;    // ширина левой и правой границы
            int nAdditionY = menu.Height + mineandtimepanel.Height;  // высота строки меню
            this.Width = 12 + 34 * nWidth + nOffsetX;   
            this.Height = 12 + 34 * nHeight + nAdditionY + nOffsetY;    
            newGameToolStripMenuItem_Click(new object(), new EventArgs()); //для применения настроек
        }


        private void Minesweeper_Load(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Array.Clear(pMine, 0, pMine.Length);
            Array.Clear(pState, 0, pState.Length);
            MouseFocus.X = 0; MouseFocus.Y = 0;
            Random Rand = new Random();
            for (int i = 1; i <= nMineCnt;)  // колво мин
            {
                int x = Rand.Next(nWidth) + 1;
                int y = Rand.Next(nHeight) + 1;
                if (pMine[x, y] != -1)
                {
                    pMine[x, y] = -1; i++;
                }
            }
            for (int i = 1; i <= nWidth; i++)    
            {
                for (int j = 1; j <= nHeight; j++)   
                {
                    if (pMine[i, j] != -1)   // колво мин вокруг
                    {
                        for (int k = 0; k < 8; k++) //8 направлений 
                        {
                            if (pMine[i + dx[k], j + dy[k]] == -1)   
                            {
                                pMine[i, j]++;  
                            }
                        }
                    }
                }
            }
            labelmine.Text = nMineCnt.ToString();  // показ колва мин
            labeltimer.Text = "0"; // выключение таймера
            timer.Enabled = true;  // запуск
            bGame = false;  
        }
        private void Minesweeper_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < 6 || e.X > 6 + nWidth * 34 ||
                e.Y < 6 + menu.Height ||
                e.Y > 6 + menu.Height + nHeight * 34) 
            {
                MouseFocus.X = 0; MouseFocus.Y = 0;
            }
            else
            {
                int x = (e.X - 6) / 34 + 1; 
                int y = (e.Y - menu.Height - 6) / 34 + 1; 
                MouseFocus.X = x; MouseFocus.Y = y; 
            }
            this.Refresh();    // перерисовка минных полей
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            labeltimer.Text = Convert.ToString(Convert.ToInt32(labeltimer.Text) + 1); // увеличение на 1 сек
        }
        private void Minesweeper_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)   // левая кнопка мыши нажата
            {
                bMouseLeft = true;
            }
            if (e.Button == MouseButtons.Right)  // правая
            {
                bMouseRight = true;
            }
        }
        private void Minesweeper_MouseUp(object sender, MouseEventArgs e)
        {
            if ((MouseFocus.X == 0 && MouseFocus.Y == 0) || bGame) 
            {
                return; 
            }

            if (bMouseLeft && bMouseRight)   
            {
                if (pState[MouseFocus.X, MouseFocus.Y] == 1 && pMine[MouseFocus.X, MouseFocus.Y] > 0)    
                {
                    int nFlagCnt = 0, nDoubtCnt = 0, nSysCnt = pMine[MouseFocus.X, MouseFocus.Y];   // колво элементов(мин и тд)
                    for (int i = 0; i < 8; i++)
                    {
                        int x = MouseFocus.X + dx[i];
                        int y = MouseFocus.Y + dy[i];
                        if (pState[x, y] == 2)   // флаг
                        {
                            nFlagCnt++;
                        }
                        if (pState[x, y] == 3)   // вопрос
                        {
                            nDoubtCnt++;
                        }
                        if (nFlagCnt == nSysCnt || nFlagCnt + nDoubtCnt == nSysCnt) // сетка из ячеек
                        {
                            bool bFlag = OpenMine(MouseFocus.X, MouseFocus.Y);
                            if (!bFlag) 
                            {
                                GameLost();
                            }
                        }
                    }
                }
            }
            else if (bMouseLeft) 
            {
                if (pMine[MouseFocus.X, MouseFocus.Y] != -1)
                {
                    if (pState[MouseFocus.X, MouseFocus.Y] == 0)
                    {
                        dfs(MouseFocus.X, MouseFocus.Y);
                    }
                }
                else
                {
                    GameLost();
                }
            }
            else if (bMouseRight)    //пометка флажком
            {
                if (bMark)   
                {
                    if (pState[MouseFocus.X, MouseFocus.Y] == 0) 
                    {
                        if (Convert.ToInt32(labelmine.Text) > 0)
                        {
                            pState[MouseFocus.X, MouseFocus.Y] = 2; 
                            labelmine.Text = Convert.ToString(Convert.ToInt32(labelmine.Text) - 1);   
                        }
                    }
                    else if (pState[MouseFocus.X, MouseFocus.Y] == 2) 
                    {
                        pState[MouseFocus.X, MouseFocus.Y] = 3; 
                        labelmine.Text = Convert.ToString(Convert.ToInt32(labelmine.Text) + 1);   
                    }
                    else if (pState[MouseFocus.X, MouseFocus.Y] == 3) 
                    {
                        pState[MouseFocus.X, MouseFocus.Y] = 0; 
                    }
                }
            }
            this.Refresh();
            GameWin();
            bMouseLeft = bMouseRight = false;
        }
        private void dfs(int sx, int sy)
        {
            pState[sx, sy] = 1; 
            for (int i = 0; i < 8; i++)
            {
                int x = sx + px[i];
                int y = sy + py[i];
                if (x >= 1 && x <= nWidth && y >= 1 && y <= nHeight &&
                    pMine[x, y] != -1 && pMine[sx, sy] == 0 &&
                    (pState[x, y] == 0 || pState[x, y] == 3)) 
                {
                    dfs(x, y); 
                }
            }
        }
        private bool OpenMine(int sx, int sy)
        {
            bool bFlag = true;  
            for (int i = 0; i < 8; i++)
            {
                int x = MouseFocus.X + dx[i];
                int y = MouseFocus.Y + dy[i];
                if (pState[x, y] == 0)   
                {
                    pState[x, y] = 1;   
                    if (pMine[x, y] != -1)   
                    {
                        dfs(x, y);
                    }
                    else 
                    {
                        bFlag = false;
                        break;
                    }
                }
            }
            return bFlag;
        }

        private void GameLost()
        {
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (pMine[i, j] == -1 && (pState[i, j] == 0 || pState[i, j] == 3))   
                    {
                        pState[i, j] = 1;   
                    }
                }
            }
            timer.Enabled = false; 
            bGame = true;
        }
        private void GameWin()
        {
            int nCnt = 0;   
            for (int i = 1; i <= nWidth; i++)
            {
                for (int j = 1; j <= nHeight; j++)
                {
                    if (pState[i, j] == 0 || pState[i, j] == 2 || pState[i, j] == 3) 
                    {
                        nCnt++;
                    }
                }
            }
            if (nCnt == nMineCnt)    // условия победы
            {
                timer.Enabled = false; 
                MessageBox.Show(String.Format("Победа：{0} ", labeltimer.Text), "", MessageBoxButtons.OK);
                if (nWidth == 10 && nHeight == 10 && nMineCnt == 10) 
                {
                    if (Properties.Settings.Default.Easy > Convert.ToInt32(labeltimer.Text))    
                    {
                        Properties.Settings.Default.Easy = Convert.ToInt32(labeltimer.Text);
                        Properties.Settings.Default.Save();
                    }
                }
                else if (nWidth == 16 && nHeight == 16 && nMineCnt == 40)   
                {
                    if (Properties.Settings.Default.Medium > Convert.ToInt32(labeltimer.Text))   
                    {
                        Properties.Settings.Default.Medium = Convert.ToInt32(labeltimer.Text);
                        Properties.Settings.Default.Save();
                    }
                }
                else if (nWidth == 30 && nHeight == 16 && nMineCnt == 99)   
                {
                    if (Properties.Settings.Default.Hard > Convert.ToInt32(labeltimer.Text))   
                    {
                        Properties.Settings.Default.Hard = Convert.ToInt32(labeltimer.Text);
                        Properties.Settings.Default.Save();
                    }
                }
                bGame = true;
            }
        }
        private void easyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nWidth = 9; nHeight = 9; nMineCnt = 10;
            SelectLevel();
            UpdateSize();
        }

        private void mediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nWidth = 16; nHeight = 16; nMineCnt = 40;
            SelectLevel();
            UpdateSize();
        }

        private void hardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nWidth = 30; nHeight = 16; nMineCnt = 99;
            SelectLevel();
            UpdateSize();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to exit the game?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        [DllImport("shell32.dll")]
        public extern static int ShellAbout(IntPtr hWnd, string szApp, string szOtherStuff, IntPtr hIcon);

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellAbout(this.Handle, "Minesweeper", "A minesweeper game using CSharp language.", this.Icon.Handle);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings Setting = new Settings(this); 
            Setting.ShowDialog();
            UpdateSize();
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Highscores Rank = new Highscores();
            Rank.ShowDialog();
        }

        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            marksToolStripMenuItem.Checked = bMark = !bMark;
        }
    }
}
