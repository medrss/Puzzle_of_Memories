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
    public partial class Form2 : Form
    {
        private string[] texts = {
            "",
            "Такое тяжёлое чувство в груди.",
            "Как будто часть меня потерялась, затерялась в лабиринте времени.",
            "Я словно  забыла,  куда  иду...",
            "Зачем  ехала  в  этой  стальной  коробке,  которая  несет  меня  в  неизвестность.",
            "Мои мысли словно разбросаны по всему миру.",
            "И вот я пытаюсь собрать себя по кусочкам, как этот пазл.",
            "Может быть, в нем я найду ответы.",
            "Арчи...",
            "Мой маленький милый котёнок.",
            "Ты был единственным, кто не бросил меня.",
            "Когда мир казался слишком серым,  ты  всегда  был  рядом,  согревая  меня  своей  любовью.",
            "Твои глаза, как две янтарные звезды, сверкали в темноте, словно маленькие фонарики.",
            "Арчи, ты был моим лучшим другом.",
            "Ты не знал, как говорить, но твоё мурчание и нежные прикосновения грели мое сердце.",
            "Я скучаю...",
            "Ты  ушел  от  меня  слишком  рано, но  память о тебе осталась  со  мной  навсегда.",
            "Я  никогда  тебя  не  забуду...",
            "Больница...",
            "Ужасное место.",
            "По крайней мере, в нашем маленьком городке.",
            "Пахнет хлоркой и лекарствами, стены белые и пустые.",
            "Здесь нет места для юности.",
            "Только бесконечный гул машин, капельниц, шуршание халатов...",
            "и глухие удары сердец, отсчитывающих  последние секунды своей жизни.",
            "Я помню, как меня привезли туда.",
            "17 лет, жизнь только началась, а ты уже лежишь в койке, с невыносимой болью,  и  страхом... ",
            "Страхом того, что ты здесь застрянешь навсегда.",
            "Дни сливались в одно белое пятно.",
            "Я выписалась, но  всё  осталось  там.",
            "Мое  детство,  мои  мечты,  мои чувства.",
            "Как  будто  меня  заменили  на  пустой  футляр.",
            "Но я продолжаю идти в случайном направлении, словно корабль без компаса...",
            "...в надежде, что найду что-то большее, чем этот туман",
            "\"Ну вот, ты опять опаздываешь...\"",
            "Я уже привыкла к тому, что электричка всегда уходит раньше, чем я успеваю до нее добраться.",
            "Но сегодня было особенно обидно.",
            "Я бежала изо всех сил, но все равно опоздала.",
            "Успела только мельком увидеть, как в тоннель уходит последний вагон.",
            "Остановилась, запыхавшаяся, не зная, что делать.",
            "Домой идти -  слишком долго, а следующая будет только через полчаса.",
            "И вдруг, из-за поворота,  медленно выехала еще одна электричка.",
            "Я сначала подумала, что ошибаюсь.",
            "Она была такая же, как предыдущая, но с одним отличием...",
            "У неё не было номера.",
            "Вроде бы и сомневаться не стоило, но что-то в этой электричке было странно притягательно.",
            "Она словно звала меня.",
            "И я, не раздумывая, шагнула в вагон.",
            "Там никого не было. ",
            "Пустые сидения, словно ждали, когда их займут.",
            "Я устроилась на одном из них и посмотрела в окно. ",
            "Не знаю, как это описать, но мир за окном стал каким-то... другим.",
            "Я видела знакомые места, но они были одновременно новыми и нереальными.",
            "Словно нарисованными на  каком-то волшебном полотне. "
        };

        private int currentTextIndex = 0;
        private System.Media.SoundPlayer player;

        public Form2()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            player = new System.Media.SoundPlayer();
            player.SoundLocation = "shum-vnutri-vagona.wav";
            player.PlayLooping();
        }
   
        private void label1_Click(object sender, EventArgs e)
        {
            currentTextIndex++;

            // Проверяем, нужно ли переходить на Form4
            if (currentTextIndex == 8)
            {
                player.Stop();
                Form3 newForm = new Form3(this); // Передача ссылки на текущую форму
                newForm.Show();
                this.Hide();
            }
            else if (currentTextIndex < texts.Length)
            {
                label1.Text = texts[currentTextIndex];
            }
            if (currentTextIndex == 18)
            {
                player.Stop();
                Form5 newForm = new Form5(this); // Передача ссылки на текущую форму
                newForm.Show();
                this.Hide();
            }
            if (currentTextIndex == 34)
            {
                player.Stop();
                Form7 newForm = new Form7(this); // Передача ссылки на текущую форму
                newForm.Show();
                this.Hide();
            }
            if (currentTextIndex == texts.Length)
            {
                player.Stop();
                sleep newForm = new sleep();
                newForm.Show();
                this.Hide();
            }
        }

        // Метод для обработки возвращения с Form4 
        public void ContinueFromForm4()
        {
            player.PlayLooping();
            currentTextIndex = 8;
            label1.Text = texts[currentTextIndex];
        }
        public void ContinueFromForm6()
        {
            player.PlayLooping();
            currentTextIndex = 18;
            label1.Text = texts[currentTextIndex];
        }
        public void ContinueFromForm8()
        {
            player.PlayLooping();
            currentTextIndex = 34;
            label1.Text = texts[currentTextIndex];
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}

