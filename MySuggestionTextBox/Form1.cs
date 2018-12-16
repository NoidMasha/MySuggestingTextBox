using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySuggestingTextBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1Items = new object[] {
            "January",
            "Febriuary",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"};

        }

        int indexOfPhrase = 0;
        string lastPhrase = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private object[] listBox1Items;
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (listBox1.Visible && e.KeyData == Keys.Down)
            {
                this.ActiveControl = listBox1;
                listBox1.SelectedIndex = 0;
                return;
            }
            listBox1.Items.Clear();
            listBox1.Visible = false;

            indexOfPhrase = 0;
            lastPhrase = string.Empty;

            if (!string.IsNullOrWhiteSpace(textBox1.Text) && char.IsLetter(textBox1.Text[textBox1.Text.Length - 1]))
            {
                
                for (int i = textBox1.Text.Length - 1; i >= 0; i--)
                {
                    if (char.IsLetter(textBox1.Text[i]))
                    {
                        lastPhrase = textBox1.Text[i] + lastPhrase;
                        indexOfPhrase = i;
                    }
                    else break;
                }
            }
            else return;

            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("en", false);
            int maxLength = 0;
            foreach (string item in listBox1Items)
            {
                int index = culture.CompareInfo.IndexOf(item, lastPhrase, System.Globalization.CompareOptions.IgnoreCase);
                if (index >= 0)
                {
                    if (!listBox1.Visible)
                    {
                        listBox1.Location = new Point(textBox1.Location.X+(indexOfPhrase==0? 0:indexOfPhrase-1)*(int)Math.Round(textBox1.Font.SizeInPoints),textBox1.Location.Y+textBox1.Size.Height);
                        listBox1.Visible = true;
                    }
                    if (item.Length > maxLength) maxLength = item.Length;
                    listBox1.Items.Add(item);
                    listBox1.Size = new Size((maxLength + 1) * (int)Math.Round(listBox1.Font.SizeInPoints), (listBox1.Items.Count + 1) * listBox1.Font.Height);
                }
            }
        }


        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                listBox1_DoubleClick(null, null);
            }
            else if(e.KeyData != Keys.Up && e.KeyData != Keys.Down)
            {
                textBox1.Focus();
                textBox1.Select(textBox1.Text.Length, 0);
            }
            
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Substring(0, indexOfPhrase) + listBox1.SelectedItem;
            listBox1.Items.Clear();
            listBox1.Visible = false;
            textBox1.Focus();
            textBox1.Select(textBox1.Text.Length, 0);
        }
    }
}
