using System.Windows.Forms;
using System;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "test.wav";
            player.PlayLooping();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2(); 
            newForm.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}