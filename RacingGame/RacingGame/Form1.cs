using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacingGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape) 
                this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 15;
            bg1.Top += speed;
            bg2.Top += speed;

            if (bg1.Top >= 650) 
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int speed = 13;
            if(e.KeyCode == Keys.Left || e.KeyCode == Keys.A)

        }
    }
}
