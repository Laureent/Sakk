namespace Sakk.Babuk
{
    public class Babu : LepesBeallitasok
    {
        public Babu(int sor, int oszlop) : base(sor, oszlop)
        {

        }

        public virtual void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            if (babuHelyzete.babuTipus is Paraszt)
            {
                new Paraszt(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
            else if (babuHelyzete.babuTipus is Bastya)
            {
                new Bastya(sor, oszlop).LepesBeallitas(babuHelyzete, tabla);
            }
        }
        public void ParasztLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFeher)
            {
                if (babuHelyzete.oszlop + 2 < 8 && !tabla.tabla[babuHelyzete.oszlop + 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                {
                    LepesBeallitasJobbra(babuHelyzete, tabla, 2);
                }
                if (!tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor].foglalt)
                {
                    LepesBeallitasJobbra(babuHelyzete, tabla, 1);
                }                
                if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].foglalt && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor - 1].babuFekete)
                {
                    LepesBeallitasJobbraFel(babuHelyzete, tabla, true);
                }
                if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop + 1 < 8 && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].foglalt && tabla.tabla[babuHelyzete.oszlop + 1, babuHelyzete.sor + 1].babuFekete)
                {
                    LepesBeallitasJobbraLe(babuHelyzete, tabla, true);
                }              
            }
            if (tabla.tabla[babuHelyzete.oszlop, babuHelyzete.sor].babuFekete)
            {
                if (babuHelyzete.oszlop - 2 > -1 && !tabla.tabla[babuHelyzete.oszlop - 2, babuHelyzete.sor].foglalt && (babuHelyzete as LepesSzamlalo).nemLepettMeg)
                {
                    LepesBeallitasBalra(babuHelyzete, tabla, 2);
                }
                if (!tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor].foglalt)
                {
                    LepesBeallitasBalra(babuHelyzete, tabla, 1);
                }
                if (babuHelyzete.sor - 1 > -1 && babuHelyzete.oszlop - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].foglalt && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor - 1].babuFekete)
                {
                    LepesBeallitasBalraFel(babuHelyzete, tabla, true);
                }
                if (babuHelyzete.sor + 1 < 8 && babuHelyzete.oszlop - 1 > -1 && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].foglalt && tabla.tabla[babuHelyzete.oszlop - 1, babuHelyzete.sor + 1].babuFekete)
                {
                    LepesBeallitasBalraLe(babuHelyzete, tabla, true);
                }
            }
        }
        public void BastyaLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasFelfele(babuHelyzete, tabla, false);
            LepesBeallitasLefele(babuHelyzete, tabla, false);
            LepesBeallitasJobbra(babuHelyzete, tabla, 7);
            LepesBeallitasBalra(babuHelyzete, tabla, 7);
        }
        public void FutoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasBalraFel(babuHelyzete, tabla, false);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, false);
            LepesBeallitasBalraLe(babuHelyzete, tabla, false);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, false);
        }
        public void SancolasVizsgalat(Tabla tabla)
        {
            if (tabla.FeherFelfeleTudSancolni())
            {
                tabla.tabla[0, 1].lepesek = true;
            }
            if (tabla.FeherLefeleTudSancolni())
            {
                tabla.tabla[0, 5].lepesek = true;
            }
            if (tabla.FeketeFelfeleTudSancolni())
            {
                tabla.tabla[7, 1].lepesek = true;
            }
            if (tabla.FeketeLefeleTudSancolni())
            {
                tabla.tabla[7, 5].lepesek = true;
            }
        }
        public void KiralyLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            SancolasVizsgalat(tabla);
            LepesBeallitasFelfele(babuHelyzete, tabla, true);
            LepesBeallitasJobbra(babuHelyzete, tabla, 1);
            LepesBeallitasLefele(babuHelyzete, tabla, true);
            LepesBeallitasBalra(babuHelyzete, tabla, 1);
            LepesBeallitasBalraFel(babuHelyzete, tabla, true);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, true);
            LepesBeallitasBalraLe(babuHelyzete, tabla, true);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, true);
        }
        public void KiralynoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LepesBeallitasFelfele(babuHelyzete, tabla, false);
            LepesBeallitasJobbra(babuHelyzete, tabla, 7);
            LepesBeallitasLefele(babuHelyzete, tabla, false);
            LepesBeallitasBalra(babuHelyzete, tabla, 7);
            LepesBeallitasBalraFel(babuHelyzete, tabla, false);
            LepesBeallitasJobbraFel(babuHelyzete, tabla, false);
            LepesBeallitasBalraLe(babuHelyzete, tabla, false);
            LepesBeallitasJobbraLe(babuHelyzete, tabla, false);
        }
        public void LoLepesek(Mezo babuHelyzete, Tabla tabla)
        {
            LoFelBalra(babuHelyzete, tabla);
            LoFelJobbra(babuHelyzete, tabla);
            LoBalraFel(babuHelyzete, tabla);
            LoBalraLe(babuHelyzete, tabla);
            LoJobbraFel(babuHelyzete, tabla);
            LoJobbraLe(babuHelyzete, tabla);
            LoLeBalra(babuHelyzete, tabla);
            LoLeJobbra(babuHelyzete, tabla);
        }
    }
}
