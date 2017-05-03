using SQLite;

namespace JTRAP_Assignment4
{
	public class Book
	{
		[PrimaryKey, AutoIncrement]
		public int BookId { get; set; }
		public string BookTitle { get; set; }
		public string ISBN { get; set; }
	}
}
