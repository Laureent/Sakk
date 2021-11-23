namespace Sakk.Babuk
{
	public class Futo : Babu
	{

		public Futo(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Futo";
        }
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
			FutoLepesek(babuHelyzete, tabla);
		}
	}
}
