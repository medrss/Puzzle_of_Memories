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
    public partial class sleep : Form
    {
        private string[] texts = {
            "",
            "А потом я уснула.",
            "Проснулась от  шума  и  яркого света.",
            "Электричка  остановилась, двери  открылись.",
            "Я  оказалась  на  незнакомой  станции и огляделась вокруг.",
            "Все  было  не так, как  я привыкла.",
            "Где  я?  Что  произошло?",
            "В голове  закружились  вопросы,  но  ответов  не было. ",
            "Я вышла из электрички и пошла вперед, погружаясь в незнакомый мир, который отобрал у меня память..."
        };
        private int currentTextIndex = 0;
        public sleep()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            player.SoundLocation = "goodbye.wav";
            player.PlayLooping();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            currentTextIndex++;

            if (currentTextIndex == texts.Length)
            {
                Form10 newForm = new Form10();
                newForm.Show();
                this.Hide();
            }
            else if (currentTextIndex < texts.Length)
            {
                label1.Text = texts[currentTextIndex];
            }
        }

        private void sleep_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
