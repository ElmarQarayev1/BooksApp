using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Class_Task
{
	public class Library

    {	
        public Book[] Books= new Book[0];
     	public void AddBook(Book book)
		{		
			Array.Resize(ref Books, Books.Length + 1);
			Books[Books.Length - 1] = book;
		}
		public bool CheckName( string name)
		{
			for (int i = 0; i <Books.Length; i++)
			{

	        	if (Books[i].Name == name)
				{
					return true;
				}	
			}
			return false;

		}
        public void RemoveBookByName(string name)
        {
            int index = -1; 
            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name == name)
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                Array.Copy(Books, index + 1, Books, index, Books.Length - index - 1);
                Array.Resize(ref Books, Books.Length - 1);
            }
            else
            {
                Console.WriteLine("bele bir kitab yoxdur.");
            }
        }

        public Book FindBookByName(string name)
        {

            for (int i = 0; i < Books.Length; i++)
            {
                if (Books[i].Name==name)
                {
                    return Books[i];
                }
            }
            return null;
        }

        public Book[] FindAllBookByName(string name )
		{
			
			for (int i = 0; i < Books.Length; i++)
			{
				if (Books[i].Name.Contains(name))
				{
					return Books;
				}
			}
			return null;
		}

		public void ShowInfo()
		{
			Console.WriteLine("kitablar:");
			for (int i = 0; i < Books.Length; i++)
			{
				Console.WriteLine($"{i+1}.kitab adi:{this.Books[i].Name}-qiymeti:{this.Books[i].Price}-janri:{this.Books[i].Genre}");
            }
        }
		public bool CheckIsBeingBook()
		{
			if (Books.Length == 0)
			{
				return true;
			}
			return false;
		}
		
			
	}
}

