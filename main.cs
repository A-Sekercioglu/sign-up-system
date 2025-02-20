using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kayıt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sayac = 1;

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            string name = txtbox1.Text;

            // isimde boşluk var mı yok mu diye kontrol eder
            if (name.Contains(" ") || password.Contains(" "))
            {
                ShowMessageAndClear("Please don't use space in your name or password");
                return;
            }

            // isim ve şifre boş mu diye kontrol eder
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                ShowMessageAndClear("Please fill all the empty boxes.");
                return;
            }

            // şifre uzunluk kontrol
            if (password.Length < 6)
            {
                ShowMessageAndClear("Please use a longer password.");
                return;
            }

            // şifre veya ismin başka kullanıcıda olup olmadığını kontrol eder
            foreach (var item in lstbox1.Items)
            {
                if (item.ToString().Contains(" Şifre : " + password))
                {
                    MessageBox.Show("This password is already used.");
                    return; // şifre kontrol
                }

                if (item.ToString().Contains("- İsim : " + name))
                {
                    MessageBox.Show("This name is already used.");
                    return; // isim kontrol
                }
            }

            //listeye yeni öge ekler
            lstbox1.Items.Add(sayac + "- İsim : " + name + " Şifre : " + password);
            sayac++; // sayacı arttırır
        }

        private void ShowMessageAndClear(string message)
        {
            MessageBox.Show(message);
            txtbox1.Clear();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // kutuları boşaltır
            txtbox1.Clear();
            textBox1.Clear();
        }

     
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtbox1_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void lstbox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
