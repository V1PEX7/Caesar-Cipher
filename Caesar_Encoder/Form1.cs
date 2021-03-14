using System;
using System.Linq;
using System.Windows.Forms;

namespace Caesar_Encoder
{
    public partial class Form1 : Form
    {
        char tempchar = ' ';
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int shift = 0;
            try
            {
                if (textBox2.Text != "")
                {
                    shift = Convert.ToInt32(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Неверно введен ключ!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введен ключ!");
            }
            if (shift != 0)
            {
                textBox3.Text = Encode(text, shift);
            }
            else
            {
                MessageBox.Show("Неверно введен ключ!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            int shift = 0;
            try
            {
                if (textBox2.Text != "")
                {
                    shift = Convert.ToInt32(textBox2.Text);
                }
                else
                {
                    MessageBox.Show("Неверно введен ключ!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введен ключ!");
            }
            if (shift != 0)
            {
                textBox3.Text = Decode(text, shift);
            }
            else
            {
                MessageBox.Show("Неверно введен ключ!");
            }
        }

        private string Encode(string text, int shift)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += Caesar(text[i], shift);
            }
            return result;
        }

        private string Decode(string text, int shift)
        {
            string result = "";
            shift *= -1;
            for (int i = 0; i < text.Length; i++)
            {
                result += Caesar(text[i], shift);
            }
            return result;
        }

        private char Caesar(char a, int shift)
        {
            tempchar = ' ';
            const string ruredux = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            const string Ruredux = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            const string enredux = "abcdefghijklmnopqrstuvwxyz";
            const string Enredux = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Numredux = "0123456789";
            const string Symredux = "!@#$%^&*()_+=-*/|\\<>?.,\"{}[];:£№'";

            ChangeIndex(ruredux, a, shift);
            ChangeIndex(Ruredux, a, shift);
            ChangeIndex(enredux, a, shift);
            ChangeIndex(Enredux, a, shift);
            ChangeIndex(Numredux, a, shift);
            ChangeIndex(Symredux, a, shift);
            return tempchar;
        }

        private void ChangeIndex(string redux, char a, int shift)
        {
            int index = 0;
            if (redux.IndexOf(a) != -1)
            {
                index = redux.IndexOf(a) + shift;
                index %= redux.Length;
                if (index < 0) { index = redux.Length + index; }
                tempchar = redux[index];
            }
        }
    }
}
