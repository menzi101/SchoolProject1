using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Question_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader("Anime.txt");

            while (SR.EndOfStream == false)
            {
                clbAnime.Items.Add(SR.ReadLine());
            }

            SR.Close();

            Random R = new Random();

            int iNext = R.Next(clbAnime.Items.Count);

            lblAnimeOfDay.Text = "Anime of the Day: " + clbAnime.Items[iNext];
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StreamWriter SW = new StreamWriter("Favourite.txt");

            for (int i = 0; i < clbAnime.Items.Count; i++)
            {
                if (clbAnime.GetItemChecked(i) == true)
                {
                    SW.WriteLine(clbAnime.Items[i].ToString());
                }
            }

            SW.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdd.Text == string.Empty)
            {
                MessageBox.Show("Please enter something inside the textbox.", "Missing field", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (clbAnime.Items.Contains(txtAdd.Text) == true)
                {
                    MessageBox.Show("This item already exists.", "Already exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    clbAnime.Items.Add(txtAdd.Text);
                    txtAdd.Text = "";
                    txtAdd.Focus();
                }
            }
        }
    }
}
