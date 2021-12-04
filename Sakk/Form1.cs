using System;
using System.Drawing;
using System.Windows.Forms;
using Sakk.Babuk;

namespace Sakk
{

    public partial class Sakk : Form
    {
        public Tabla sakkTabla = new Tabla(8);        

        public Sakk()
        { 
            InitializeComponent();
            panel1.Width = sakkTabla.tabla.GetLength(0) * 70;
            panel1.Height = sakkTabla.tabla.GetLength(1) * 70;
            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(1); h++)
                {
                    sakkTabla.tabla[i, h].gomb.Click += GombNyomas;
                    panel1.Controls.Add(sakkTabla.tabla[i, h].gomb);
                }
            }
        }

        private void GombNyomas(object sender, EventArgs args)
        {
            Button gomb = (Button)sender;
            Point helyzet = gomb.Location;
            Mezo mezo = sakkTabla.tabla[helyzet.X / 70, helyzet.Y / 70];
            sakkTabla.GombNyomas(mezo, gomb, panel1);
            panelModositas();
        }
        
        private void panelModositas()
        {
            //panel1.Controls.Clear();
            const int meret = 70;

            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(0); h++)
                {
                    var mezo = sakkTabla.tabla[i, h];
					if (mezo.changed)
					{
                        mezo.szinez();
                        mezo.gomb.Location = new Point(i * meret, h * meret);
                        mezo.gomb.Text = mezo.babuNeve;
                        mezo.gomb.Height = meret;
                        mezo.gomb.Width = meret;
                        //mezo.gomb.Click -= GombNyomas;
                        mezo.gomb.Click += GombNyomas;
                        if (sakkTabla.jatekVege)
                        {
                            mezo.gomb.Enabled = false;
                        }
                        //tableLayoutPanel1.Controls.Add(mezo.gomb, i, h);
                        panel1.Controls.Add(mezo.gomb);
                        mezo.clearChanged();
                    }
                }
            }
            if (sakkTabla.kovetkezoSzin == BabuSzine.FEHER)
            {
                label1.Text = "Fehér játékos következik";
            }
            else
            {
                label1.Text = "Fekete játékos következik";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sakkTabla = new Tabla(8);            
            panel1.Controls.Clear();
            sakkTabla.jatekInditasa();
            panelModositas();
        }
	}
}
