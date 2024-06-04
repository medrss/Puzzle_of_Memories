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
    public partial class Form5 : Form
    {
        private Form2 previousForm;
        Form2 form2;
        public Form5(Form2 form2)
        {
            InitializeComponent();
            previousForm = form2;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 newForm = new Form6(previousForm);
            newForm.Show();
        }
        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Help;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
