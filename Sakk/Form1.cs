using System;
using System.Drawing;
using System.Windows.Forms;
using Sakk.Babuk;

namespace Sakk
{

    public partial class Sakk : Form
    {
        public Tabla sakkTabla = new Tabla(8);
        const int meret = 70;

        //gombok létrehozása és felhelyezése
        public Sakk()
        { 
            InitializeComponent();
            panel1.Width = sakkTabla.tabla.GetLength(0) * meret;
            panel1.Height = sakkTabla.tabla.GetLength(1) * meret;
            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(1); h++)
                {
                    sakkTabla.tabla[i, h].gomb.Click += GombNyomas;
                    panel1.Controls.Add(sakkTabla.tabla[i, h].gomb);
                }
            }
        }

        //a kattintott mező kiválasztása
        private void GombNyomas(object sender, EventArgs args)
        {
            Button gomb = (Button)sender;
            Point helyzet = gomb.Location;
            Mezo mezo = sakkTabla.tabla[helyzet.X / meret, helyzet.Y / meret];
            sakkTabla.GombNyomas(mezo, gomb, panel1);
            panelModositas();
        }

        //gomb kinézetének módosítása
        private void GombKinezetModositas(Mezo mezo,int i,int h)
        {
            mezo.gomb.Location = new Point(i * meret, h * meret);
            mezo.gomb.FlatStyle = FlatStyle.Flat;
            mezo.szinez();           
            mezo.gomb.Text = mezo.babuNeve;
            mezo.gomb.Height = meret;
            mezo.gomb.Width = meret;
            mezo.gomb.Click += GombNyomas;
        }
        
        //következő játékos feltűntetése 
        private void KovetkezoJatekos(Tabla sakkTabla)
        {
            if (sakkTabla.kovetkezoSzin == BabuSzine.FEHER)
            {
                label1.Text = "Fehér játékos következik";
            }
            else
            {
                label1.Text = "Fekete játékos következik";
            }
        }

        //bábuk módosítása
        private void panelModositas()
        {
            for (int i = 0; i < sakkTabla.tabla.GetLength(0); i++)
            {
                for (int h = 0; h < sakkTabla.tabla.GetLength(0); h++)
                {
                    var mezo = sakkTabla.tabla[i, h];
					if (mezo.changed)
					{
                        GombKinezetModositas(mezo, i, h);
                        if (sakkTabla.jatekVege)
                        {
                            mezo.gomb.Enabled = false;
                        }
                        panel1.Controls.Add(mezo.gomb);
                        mezo.clearChanged();
                    }
                }
            }
            KovetkezoJatekos(sakkTabla);
        }

        //játék indítása
        private void button1_Click(object sender, EventArgs e)
        {
            sakkTabla = new Tabla(8);            
            panel1.Controls.Clear();
            sakkTabla.jatekInditasa();
            panelModositas();
        }
	}
}
