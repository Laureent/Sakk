namespace Sakk.Babuk
{
	public class Lo : Babu
	{
		
		public Lo(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Ló";
        }

        public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
        {
            LoLepesek(babuHelyzete, tabla);
        }
    }
}
