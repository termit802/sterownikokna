using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZamykanieOkna
{
    public partial class Form1 : Form
    {
        Sterownik s;

        public void poinformuj(string komunikat, int pozycja_suwaka, int nowy_priorytet)
        {
            if (nowy_priorytet <= s.obecny_priorytet)
            {
                Text = komunikat;
                progressBar1.Value = pozycja_suwaka;
                s.obecny_priorytet = nowy_priorytet;
            }
        }

        public Form1()
        {
            InitializeComponent();
            s = new Sterownik(this);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s.tick();
        }

        private void btnZamknij_Click(object sender, EventArgs e)
        {
            s.zamknij();
        }

        private void btnOtworz_Click(object sender, EventArgs e)
        {
            s.otworz();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("czad-1", checkBox1.Checked ? 50 : 0);
            //s.otworz();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("przeszkoda", checkBox2.Checked ? 1 : 0);
        }

        private void checkBox3_CheckedChanged_1(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("temperatura", checkBox3.Checked ? 50 : 0);
        }

        private void checkBox4_CheckedChanged_1(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("wilgotność", checkBox4.Checked ? 60 : 0);
        }

        private void checkBox5_CheckedChanged_1(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("deszcz", checkBox5.Checked ? 1 : 0);
        }

        private void checkBox6_CheckedChanged_1(object sender, EventArgs e)
        {
            s.zmien_stan_czujnika("śnieg/lód", checkBox6.Checked ? 1 : 0);
        }
    }
}
