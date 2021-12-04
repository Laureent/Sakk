using Sakk.Babuk;
using System.Drawing;
using System.Windows.Forms;

namespace Sakk
{
    public class Tabla
    {
        public Mezo[,] tabla { get; set; }
        private Koordinata aktivMezo { get; set; }
        public BabuSzine kovetkezoSzin { get; set; }
        public bool jatekVege { get; set; }
        private int utesSzamlalo = 63;

        //tábla legenerálása
        public Tabla(int tablameret)
        {
            tabla = new Mezo[tablameret, tablameret];
            int gombMeret = 70;

            for (int i = 0; i < tablameret; i++)
            {
                for (int h = 0; h < tablameret; h++)
                {
                    tabla[i, h] = new Mezo(h, i);
                    tabla[i, h].gomb.Height = gombMeret;
                    tabla[i, h].gomb.Width = gombMeret;
                }
            }
        }
        //bábu kiválasztása vagy léptetése
        public void GombNyomas(Mezo mezo, Button gomb = null, Panel panel = null)
        {
            if (mezo.foglalt && kovetkezoSzin == mezo.babuSzine)
            {
                LehetosegekTorlese();
                LehetosegekBeallitasa(mezo, mezo.babuTipus);
                aktivMezo = new Koordinata(mezo.oszlop, mezo.sor);
            }
            else if (mezo.lepesek)
            {
                Mezo regiMezo = tabla[aktivMezo.x, aktivMezo.y];
                Lepes(regiMezo, mezo, panel, gomb);
                if (kovetkezoSzin == BabuSzine.FEHER)
                {
                    kovetkezoSzin = BabuSzine.FEKETE;
                }
                else
                {
                    kovetkezoSzin = BabuSzine.FEHER;
                }
            }
        }
        private bool FeherFelfeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 0 && hova.sor == 1 && hova.oszlop == 0 && honnan is Kiraly;
        }
        private bool FeherLefeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 0 && hova.sor == 5 && hova.oszlop == 0 && honnan is Kiraly;
        }
        private bool FeketeFelfeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 7 && hova.sor == 1 && hova.oszlop == 7 && honnan is Kiraly;
        }
        private bool FeketeLefeleSancolt(Mezo honnan, Mezo hova)
        {
            return honnan.sor == 3 && honnan.oszlop == 7 && hova.sor == 5 && hova.oszlop == 7 && honnan is Kiraly;
        }
        //bábu léptetése
        public void Lepes(Mezo honnan, Mezo hova, Panel panel = null, Button gomb = null)
        {
            if (FeherFelfeleSancolt(honnan, hova))
            {
                Lepes(tabla[0, 0], tabla[0, 2]);
            }
            if (FeherLefeleSancolt(honnan, hova))
            {
                Lepes(tabla[0, 7], tabla[0, 4]);
            }
            if (FeketeFelfeleSancolt(honnan, hova))
            {
                Lepes(tabla[7, 0], tabla[7, 2]);
            }
            if (FeketeLefeleSancolt(honnan, hova))
            {
                Lepes(tabla[7, 7], tabla[7, 4]);
            }

            if ((honnan.babuFekete && hova.babuFeher) || (honnan.babuFeher && hova.babuFekete))
            {

                //MessageBox.Show(panel.Controls.Count + " , " + panel.Controls.IndexOf(gomb));
                panel.Controls.RemoveAt(panel.Controls.IndexOf(gomb));
                //utesSzamlalo++;
                hova = new Mezo(hova.sor,hova.oszlop);
                tabla[hova.oszlop, hova.sor] = hova;
                int honnanSor = honnan.sor;
                int honnanOszlop = honnan.oszlop;
                honnan.Lepes(hova.sor, hova.oszlop);
                hova = new Mezo(honnanSor, honnanOszlop);
                hova.setChanged();
                honnan.setChanged();
                tabla[honnan.oszlop, honnan.sor] = honnan;
                tabla[hova.oszlop, hova.sor] = hova;
            }
            else
            {
                int hovaSor = hova.sor;
                int hovaOszlop = hova.oszlop;
                hova.Lepes(honnan.sor, honnan.oszlop);
                honnan.Lepes(hovaSor, hovaOszlop);
                honnan.setChanged();
                hova.setChanged();
                tabla[honnan.oszlop, honnan.sor] = honnan;
                tabla[hova.oszlop, hova.sor] = hova;
            }

            LehetosegekTorlese();
            if (hova is Kiraly && hova.babuFekete)
            {
                MessageBox.Show("A fehér nyert!");
                jatekVege = true;
            }
            if (hova is Kiraly && hova.babuFeher)
            {
                MessageBox.Show("A fekete nyert!");
                jatekVege = true;
            }
        }
        public bool FeherFelfeleTudSancolni()
        {
            return tabla[0, 3] is Kiraly && tabla[0, 3].babuFeher && (tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla[0, 0] is Bastya && (tabla[0, 0] as LepesSzamlalo).nemLepettMeg && tabla[0, 0].babuFeher && !tabla[0, 1].foglalt && !tabla[0, 2].foglalt;
        }
        public bool FeherLefeleTudSancolni()
        {
            return tabla[0, 3] is Kiraly && tabla[0, 3].babuFeher && (tabla[0, 3] as LepesSzamlalo).nemLepettMeg && tabla[0, 7] is Bastya && (tabla[0, 7] as LepesSzamlalo).nemLepettMeg && tabla[0, 7].babuFeher && !tabla[0, 4].foglalt && !tabla[0, 5].foglalt && !tabla[0, 6].foglalt;
        }
        public bool FeketeFelfeleTudSancolni()
        {
            return tabla[7, 3] is Kiraly && tabla[7, 3].babuFekete && (tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla[7, 0] is Bastya && (tabla[7, 0] as LepesSzamlalo).nemLepettMeg && tabla[7, 0].babuFekete && !tabla[7, 1].foglalt && !tabla[7, 2].foglalt;
        }
        public bool FeketeLefeleTudSancolni()
        {
            return tabla[7, 3] is Kiraly && tabla[7, 3].babuFekete && (tabla[7, 3] as LepesSzamlalo).nemLepettMeg && tabla[7, 7] is Bastya && (tabla[7, 7] as LepesSzamlalo).nemLepettMeg && tabla[7, 7].babuFekete && !tabla[7, 4].foglalt && !tabla[7, 5].foglalt && !tabla[7, 6].foglalt;
        }
        //előzőleg kijelölt területek törlése
        public void LehetosegekTorlese()
        {
            for (int i = 0; i < tabla.GetLength(0); i++)
            {
                for (int h = 0; h < tabla.GetLength(1); h++)
                {
                    if (tabla[i, h].lepesek)
                    {
                        tabla[i, h].lepesek = false;
                        tabla[i, h].setChanged();
                    }
                }
            }
        }
        //azoknak a mezőkek a kijelölése ahová léphet a bábu
        public void lepesiLehetoseg(Mezo cel, Mezo start)
        {
            if ((cel.foglalt && cel.babuSzine != start.babuSzine) || !cel.foglalt)
            {
                tabla[cel.oszlop, cel.sor].lepesek = true;
                tabla[cel.oszlop, cel.sor].setChanged();
            }
        }
        //bábuk lépés szabályai
        public void LehetosegekBeallitasa(Mezo babuHelyzete, Babu babu)
        {
            babu.LepesBeallitas(babuHelyzete, this);
        }

        public void BastyaGenerelasaBabuTipusaBastyaEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            if (babuTipusa == "Bastya")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Bastya(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Bastya(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Bástya";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void FutoGeneralasaBabuTipusaFutoEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
        if (babuTipusa == "Futo")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Futo(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Futo(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Futó";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void KiralyGeneralasaBabuTipusaKiralyEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            if (babuTipusa == "Kiraly")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Kiraly(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Kiraly(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Király";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void KiralynoGeneralasaBabuTipusaKiralynoEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            if (babuTipusa == "Kiralyno")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Kiralyno(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Kiralyno(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Királynő";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void LoGeneralasaBabuTipusaLoEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            if (babuTipusa == "Lo")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Lo(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Lo(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Ló";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void ParasztGeneralasaBabuTipusaParasztEseten(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            if (babuTipusa == "Paraszt")
            {
                tabla[babuHelyzeteX, babuHelyzeteY] = new Paraszt(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuTipus = new Paraszt(babuHelyzeteY, babuHelyzeteX);
                tabla[babuHelyzeteX, babuHelyzeteY].babuNeve = "Paraszt";
                tabla[babuHelyzeteX, babuHelyzeteY].babuSzine = szine;
            }
        }
        public void babuGeneralasa(string babuTipusa, BabuSzine szine, int babuHelyzeteX, int babuHelyzeteY)
        {
            BastyaGenerelasaBabuTipusaBastyaEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
            FutoGeneralasaBabuTipusaFutoEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
            LoGeneralasaBabuTipusaLoEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
            KiralyGeneralasaBabuTipusaKiralyEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
            KiralynoGeneralasaBabuTipusaKiralynoEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
            ParasztGeneralasaBabuTipusaParasztEseten(babuTipusa, szine, babuHelyzeteX, babuHelyzeteY);
        }

        public void bastyakGeneralasa()
        {
            babuGeneralasa("Bastya", BabuSzine.FEHER, 0, 0);
            babuGeneralasa("Bastya", BabuSzine.FEHER, 0, 7);
            babuGeneralasa("Bastya", BabuSzine.FEKETE, 7, 0);
            babuGeneralasa("Bastya", BabuSzine.FEKETE, 7, 7);
        }
        public void lovakGeneralasa()
        {
            babuGeneralasa("Lo", BabuSzine.FEHER, 0, 1);
            babuGeneralasa("Lo", BabuSzine.FEHER, 0, 6);
            babuGeneralasa("Lo", BabuSzine.FEKETE, 7, 1);
            babuGeneralasa("Lo", BabuSzine.FEKETE, 7, 6);
        }
        public void futokGeneralasa()
        {
            babuGeneralasa("Futo", BabuSzine.FEHER, 0, 2);
            babuGeneralasa("Futo", BabuSzine.FEHER, 0, 5);
            babuGeneralasa("Futo", BabuSzine.FEKETE, 7, 2);
            babuGeneralasa("Futo", BabuSzine.FEKETE, 7, 5);
        }
        public void kiralyokGeneralasa()
        {
            babuGeneralasa("Kiraly", BabuSzine.FEHER, 0, 3);
            babuGeneralasa("Kiraly", BabuSzine.FEKETE, 7, 3);
        }
        public void kiralynokGeneralasa()
        {
            babuGeneralasa("Kiralyno", BabuSzine.FEHER, 0, 4);
            babuGeneralasa("Kiralyno", BabuSzine.FEKETE, 7, 4);
        }
        public void parasztokGeneralasa()
        {
			for (int i = 0; i < 8; i++)
			{
                babuGeneralasa("Paraszt", BabuSzine.FEHER, 1, i);
                babuGeneralasa("Paraszt", BabuSzine.FEKETE, 6, i);
            }
        }

        public void osszesBabuGeneralasa()
        {
            bastyakGeneralasa();
            lovakGeneralasa();
            futokGeneralasa();
            kiralyokGeneralasa();
            kiralynokGeneralasa();
            parasztokGeneralasa();
        }

        //tábla alaphelyzet
        public void jatekInditasa()
        {
            kovetkezoSzin = BabuSzine.FEHER;
            osszesBabuGeneralasa();
        }
    }
}
