using System;
namespace Class_Task
{
	public class Book: Product
	{
        
        public Book(string name,double price,string genre):base(name,price)
		{

			this.Genre = genre;
		}
		public string Genre;
		
	}
}

