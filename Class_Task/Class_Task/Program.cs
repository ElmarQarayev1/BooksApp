using System.Diagnostics;

namespace Class_Task;

class Program
{
    static void Main(string[] args)
    {
       
        Library library = new Library();
       
        string secim;
        bool check;
        do
        {        
             ShowMenu();
             secim = Console.ReadLine();
             check = library.CheckIsBeingBook();
        switch (secim)
        {
                case "1":
                    string name;
                    do
                    {
                        Console.WriteLine("kitabin adini daxil edin:");
                        name = Console.ReadLine();
                    } while (String.IsNullOrWhiteSpace((name))|| !CheckAddingName(name));
                    if (library.CheckName(name))
                    {
                        Console.WriteLine("eyni adli kitab daxil etmek olmaz!");
                    }
                    else
                    {
                        string Strprice;
                        double price;
                        do
                        {
                            Console.WriteLine("kitabin qiymetini daxil edin");
                            Strprice = Console.ReadLine();
                        } while (!double.TryParse(Strprice, out price) || price < 0);
                        string genre;
                        do
                        {
                            Console.WriteLine("kitabin janrini daxil edin:");
                            genre = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(genre));

                        Book books = new Book(ChangingSpace(name), price, genre);
                        library.AddBook(books);

                    }       
                    break;
                case "2":
                   
                    library.ShowInfo();
                  
                    if (check)
                    {
                        Console.WriteLine("hal hazirda kitab yoxdur");
                    }
                    else
                    {
                        string namee;
                        do
                        {
                            Console.WriteLine("\nsileceyiniz kitab adini daxil edin:");
                            namee = Console.ReadLine();

                        } while (String.IsNullOrWhiteSpace(namee));

                        library.RemoveBookByName(namee);                       
                    }         
                    break;
                case "3":
               
                    if (check)
                    {
                        Console.WriteLine("hal hazirda kitab yoxdur");
                    }
                    else
                    {
                        library.ShowInfo(); 
                    }
                   
                    break;
                case "4":
                   
                    if (check)
                    {
                        Console.WriteLine("hal hazirda kitab yoxdur");

                    }
                    else
                    {
                        string searched;
                        do
                        {
                            Console.WriteLine("axtaracaginiz kitabi daxil edin:");
                            searched = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(searched));
                        Book word = library.FindBookByName(searched);

                        if (word == null)
                        {
                            Console.WriteLine("bele bir kitab yoxdur!");
                        }
                        else
                        {
                            Console.WriteLine($"sizin axtardiginiz kitab : adi:{word.Name}-qiymeti:{word.Price}-janri:{word.Genre}");
                        }
                        
                    }
                   
                    break;
                case "5":
                   
                    if (check)
                    {
                        
                       Console.WriteLine("hal hazirda kitab yoxdur");
                    }
                    else
                    {
                        string search;
                        do
                        {
                            Console.WriteLine("axtaracaginiz kitabin adini daxil edin:");
                            search = Console.ReadLine();
                        } while (String.IsNullOrWhiteSpace(search));
                        Book[] words = library.FindAllBookByName(search);

                        if (words == null)
                        {
                            Console.WriteLine("bele bir kitab yoxdur!");
                        }
                        else
                        {
                            Console.WriteLine("sizin axtardiginiz kitablar:");
                            for (int i = 0; i < words.Length; i++)
                            {
                                Console.WriteLine($"{i + 1}.kitab adi:{words[i].Name}-qiymeti:{words[i].Price}-janri:{words[i].Genre}");

                            }
                        }
                    }                   
                    break;
                default:
                    Console.WriteLine("secim yanlisdir!");
                break;
        }
        } while (secim !="0");
        
        Console.ReadLine();

}
    static void ShowMenu()
    {
        Console.WriteLine("\n1.Kitab elave et\n2.Kitab sil\n3.Butun kitablara bax\n4.Secilmis kitaba bax\n5.Ada gore axtaris et\n");
        Console.WriteLine("secim edin:");
        
    }
    static bool CheckAddingName(string name)
    {
        if (name.Length>=3 && name.Length<=20)
        {
            if (CheckingIsLetter(name))
            {
                return true;
            }
        }
        return false;
    }
    static bool CheckingIsLetter(string name)
    {
        for (int i = 0; i < name.Length; i++)
        {
            if (!char.IsLetter(name[i]) && !name.Contains(" ")) return false;         
        }
        return true;
    }
    static string ChangingSpace(string name)
    {
       
        while (name.Contains("  "))
        {
            name = name.Replace("  ", " ");
        }
        name = name.Trim();
       
        return name;
    }


}    


