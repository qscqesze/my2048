using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace My2048
{
    public partial class Form1 : Form
    {
        private bool judge;
        public Form1()
        {
            InitializeComponent();//初始化功能
            ini_Game();
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)//按键判断
        {
            String moeKey = e.KeyChar.ToString();
            int change = 0;
            switch (moeKey)
            {
                case "w": change = GameCore.move_merger(0); break;
                case "s": change = GameCore.move_merger(1); break;
                case "a": change = GameCore.move_merger(2); break;
                case "d": change = GameCore.move_merger(3); break;
                default: return;
            }
            if (change > 0)
            {
                GameCore.update_map();
                draw_Game();
            }
            if(GameCore.is_win()&&judge)
            {
                MessageBox.Show("太棒了，你赢了！");
                judge = false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ini_Game();
        }
        private void ini_Game()
        {
            GameCore.map = new int[4, 4];
            GameCore.update_map();
            GameCore.update_map();
            GameCore.score = 0;
            draw_Game();
            judge = true;
        }
        private void draw_Game()
        {
            PictureBox[,] pb = new PictureBox[4, 4]{
                               {pb1,pb2,pb3,pb4},
                               {pb5,pb6,pb7,pb8},
                               {pb9,pb10,pb11,pb12},
                               {pb13,pb14,pb15,pb16}
                               };
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    set_imge(pb[i, j], GameCore.map[i,j]);
                }
            }
            scorebord.Text = GameCore.score.ToString();
        }
        private void set_imge(PictureBox p, int num)
        {
            switch (num)
            {
                case 0: p.Image = global::My2048.Properties.Resources._0; break;
                case 2: p.Image = global::My2048.Properties.Resources._2; break;
                case 4: p.Image = global::My2048.Properties.Resources._4; break;
                case 8: p.Image = global::My2048.Properties.Resources._8; break;
                case 16: p.Image = global::My2048.Properties.Resources._16; break;
                case 32: p.Image = global::My2048.Properties.Resources._32; break;
                case 64: p.Image = global::My2048.Properties.Resources._64; break;
                case 128: p.Image = global::My2048.Properties.Resources._128; break;
                case 256: p.Image = global::My2048.Properties.Resources._256; break;
                case 512: p.Image = global::My2048.Properties.Resources._512; break;
                case 1024: p.Image = global::My2048.Properties.Resources._1024; break;
                case 2048: p.Image = global::My2048.Properties.Resources._2048; break;
                case 4096: p.Image = global::My2048.Properties.Resources._4096; break;
                case 8192: p.Image = global::My2048.Properties.Resources._8192; break;
                default : break;
            }
        }

    }
}
