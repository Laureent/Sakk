namespace Sakk
{
	public class Kiraly : Mezo
	{
		public int lepesekSzama { get; set; }

		public Kiraly(int sor, int oszlop) : base(sor, oszlop)
		{
			lepesekSzama = 0;
		}
	}
}
