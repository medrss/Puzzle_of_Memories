using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form10 : Form
    {
        private System.Media.SoundPlayer player;
        public Form10()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            player = new System.Media.SoundPlayer();
            player.SoundLocation = "theEnd.wav";
            player.PlayLooping();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form11 newForm = new Form11();
            newForm.Show();
        }

        private void Form10_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
