using System;
using System.Linq;
using System.Windows.Forms;

namespace Caesar_Encoder
{
    public partial class Form1 : Form
    {
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
            int index = 0;
            const string ruredux = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            const string Ruredux = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
            const string enredux = "abcdefghijklmnopqrstuvwxyz";
            const string Enredux = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string Numredux = "0123456789";
            const string Symredux = "!@#$%^&*()_+=-*/|\\<>?.,\"{}[];:£№'";
            
            if(ruredux.IndexOf(a) != -1)
            {
                index = ruredux.IndexOf(a) + shift;
                index %= ruredux.Length;
                if (index < 0) { index = ruredux.Length + index; }
                return ruredux[index];
            }
            if (Ruredux.IndexOf(a) != -1)
            {
                index = Ruredux.IndexOf(a) + shift;
                index %= Ruredux.Length;
                if (index < 0) { index = Ruredux.Length + index; }
                return Ruredux[index];
            }
            if (enredux.IndexOf(a) != -1)
            {
                index = enredux.IndexOf(a) + shift;
                index %= enredux.Length;
                if (index < 0) { index = 26 + enredux.Length; }
                return enredux[index];
            }
            if (Enredux.IndexOf(a) != -1)
            {
                index = Enredux.IndexOf(a) + shift;
                index %= Enredux.Length;
                if (index < 0) { index = Enredux.Length + index; }
                return Enredux[index];
            }
            if (Numredux.IndexOf(a) != -1)
            {
                index = Numredux.IndexOf(a) + shift;
                index %= Numredux.Length;
                if (index < 0) { index = Numredux.Length + index; }
                return Numredux[index];
            }
            if (Symredux.IndexOf(a) != -1)
            {
                index = Symredux.IndexOf(a) + shift;
                index %= Symredux.Length;
                if (index < 0) { index = Symredux.Length + index; }
                return Symredux[index];
            }
            return ' ';
        }
    }
}
