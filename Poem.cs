
namespace DZ_CS_13
{
    internal class Poem
    {
        public string? poemName       { get; private set; }
        public string? authorName     { get; private set; }
        public int ?   yearOfCreation { get; private set; }
        public string? poemText       { get; private set; }
        public string? poemTheme      { get; private set; }

        public Poem() { }

        public Poem(string? PoemName, string? AuthorName, int YearOfCreation, string? PoemTheme, string? PoemText)
        {
            poemName       = PoemName;
            authorName     = AuthorName;
            yearOfCreation = YearOfCreation;
            poemText       = PoemText;
            poemTheme      = PoemTheme;

        }

        public void InputData()
        {
            Console.Write("Enter poem name: ");
            poemName = Console.ReadLine();

            Console.Write("Enter author name: ");
            authorName = Console.ReadLine();

            Console.Write("Enter the year of creation: ");
            yearOfCreation = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter theme of the poem: ");
            poemTheme = Console.ReadLine();

            Console.WriteLine("Enter poem text: ");
            poemText = Console.ReadLine();
            Console.WriteLine();
        }

        public void AddToList(List<Poem> poems)
        {
            //this.InputData();
            poems.Add(this);
        }

        static public void RemovePoemFromList(List<Poem> poems)
        {
            Console.Write("Enter name of poem to remove: ");
            string? poemToRemove = Console.ReadLine();
            foreach (var item in poems)
            {
                if (item.poemName != null && item.poemName.Equals(poemToRemove))
                {
                    poems.Remove(item);
                    Console.WriteLine("Succesfully removed!");
                    break;
                }
            }
        }

        public override string ToString() 
        {
            return $"Poem name:\t\t{poemName}\nPoem author:\t{authorName}\nYear of creation:\t" +
                   $"{yearOfCreation}\nPoem theme:\t\t{poemTheme}\nPoem text:\n{poemText}\n\n";
        }
    }
}
