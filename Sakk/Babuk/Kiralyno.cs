namespace Sakk.Babuk
{
	public class Kiralyno : Babu
	{

		public Kiralyno(int sor, int oszlop) : base(sor, oszlop)
		{
            babuNeve = "Királynő";
        }
		public override void LepesBeallitas(Mezo babuHelyzete, Tabla tabla)
		{
			KiralynoLepesek(babuHelyzete, tabla);
		}
	}
}
