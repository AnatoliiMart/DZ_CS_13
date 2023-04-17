using System.Text;
namespace DZ_CS_13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Poem> poems = new List<Poem>();
            string? text = "Я помню чудное мгновенье:\r\n" +
                           "Передо мной явилась ты,\r\n" +
                           "Как мимолетное виденье,\r\n" +
                           "Как гений чистой красоты.\r\n\r\n" +
                           "В томленьях грусти безнадежной,\r\n" +
                           "В тревогах шумной суеты,\r\n" +
                           "Звучал мне долго голос нежный\r\n" +
                           "И снились милые черты.\r\n\r\n" +
                           "Шли годы. Бурь порыв мятежный\r\n" +
                           "Рассеял прежние мечты,\r\n" +
                           "И я забыл твой голос нежный,\r\n" +
                           "Твои небесные черты.\r\n\r\n" +
                           "В глуши, во мраке заточенья\r\n" +
                           "Тянулись тихо дни мои\r\n" +
                           "Без божества, без вдохновенья,\r\n" +
                           "Без слез, без жизни, без любви.\r\n\r\n" +
                           "Душе настало пробужденье:\r\n" +
                           "И вот опять явилась ты,\r\n" +
                           "Как мимолетное виденье,\r\n" +
                           "Как гений чистой красоты.\r\n\r\n" +
                           "И сердце бьется в упоенье,\r\n" +
                           "И для него воскресли вновь\r\n" +
                           "И божество, и вдохновенье,\r\n" +
                           "И жизнь, и слезы, и любовь.";

            Poem poem1 = new Poem("Я помню чудное мгновенье…", "Александр Пушкин",
                                  1825, "K***", text);
            text = "Встала весна, чорну землю\r\n" +
                   "Сонну розбудила,\r\n" +
                   "Уквiтчала її рястом,\r\n" +
                   "Барвiнком укрила.\r\n" +
                   "А на полi жайворонок,\r\n" +
                   "Соловейко в гаї -\r\n" +
                   "Землю, убрану весною,\r\n" +
                   "Вранцi зустрiчають.\r\n";
            Poem poem2 = new Poem("Встала весна", "Тарас Шевченко", 1841, "Уривок iз поеми «Гайдамаки»", text);

            poem1.AddToList(poems);
            poem2.AddToList(poems);
            SearchByAuthor(poems);
            SearchByPoemName(poems);
            SearchByPoemTheme(poems);
            reportByAuthorsName(poems);
            reportByPoemName(poems);
            reportByPoemTheme(poems);
            reportByPoemLength(poems);
            reportByWordInPoem(poems);
            reportByYearOfCreation(poems);
            Poem.RemovePoemFromList(poems);
            ToFile(poems);
            TakeFromFile();
        }

        static void ToFile(List<Poem> poems)
        {
            FileStream fileStream = new FileStream("Poems.txt", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream, Encoding.UTF8);
            foreach (var poem in poems)
            {
                writer.WriteLine(poem);
                writer.WriteLine();
                writer.WriteLine("---------------------------------------------------");
            }
            writer.Close();
            writer.Dispose();
            fileStream.Close();
            fileStream.Dispose();
        }

        static void TakeFromFile()
        {
            try
            {
                FileStream stream = new FileStream("Poems.txt", FileMode.Open, FileAccess.Read);
                StreamReader streamReader = new StreamReader(stream, Encoding.UTF8);
                Console.WriteLine(streamReader.ReadToEnd());
                streamReader.Close();
                stream.Close();
                stream.Dispose();
                streamReader.Dispose();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        static void SearchByAuthor(List<Poem> poems)
        {
            Console.WriteLine("Enter searching authors name:");
            string? authorSearch = Console.ReadLine();

            if (authorSearch != null)
            {
                var serch = from item in poems
                            where item.authorName == authorSearch
                            select item;
                Console.WriteLine("Result:");
                Console.WriteLine();
                if (serch.Count() > 0)
                    foreach (var item in serch)
                        Console.WriteLine(item.ToString());
                else
                    Console.WriteLine("No results!!!");
            }
            else
                Console.WriteLine("nothing was inputed!!!");
        }

        static void SearchByPoemName(List<Poem> poems)
        {
            Console.WriteLine("Enter searching poem name:");
            string? poemNameSearch = Console.ReadLine();

            if (poemNameSearch != null)
            {
                var serch = from item in poems
                            where item.poemName == poemNameSearch
                            select item;
                Console.WriteLine("Result:");
                Console.WriteLine();
                if (serch.Count() > 0)
                    foreach (var item in serch)
                        Console.WriteLine(item.ToString());
                else
                    Console.WriteLine("No results!!!");
            }
            else
                Console.WriteLine("nothing was inputed!!!");
        }

        static void SearchByPoemTheme(List<Poem> poems)
        {
            Console.WriteLine("Enter searching poem theme:");
            string? poemThemeSearch = Console.ReadLine();

            if (poemThemeSearch != null)
            {
                var serch = from item in poems
                            where item.poemTheme == poemThemeSearch
                            select item;
                Console.WriteLine("Result:");
                Console.WriteLine();
                if (serch.Count() > 0)
                    foreach (var item in serch)
                        Console.WriteLine(item.ToString());
                else
                    Console.WriteLine("No results!!!");
            }
            else
                Console.WriteLine("nothing was inputed!!!");
        }

        static void reportByAuthorsName(List<Poem> poems)
        {
            var res = from item in poems
                      group item by item.authorName;

            Console.WriteLine("Report by author name:");
            Console.WriteLine();

            foreach (var item in res)
            {
                Console.WriteLine($"Autors name: {item.Key}");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"Poem name:  {item1.poemName}");
                    Console.WriteLine($"Poem theme: {item1.poemTheme}");
                }
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }

        static void reportByPoemName(List<Poem> poems)
        {
            var res = from item in poems
                      group item by item.poemName;

            Console.WriteLine("Report by poem name:");
            Console.WriteLine();

            foreach (var item in res)
            {
                Console.WriteLine($"Poem name: {item.Key}");
                foreach (var item1 in item)
                {
                    Console.WriteLine($"Author name:  {item1.authorName}");
                    Console.WriteLine($"Poem theme:   {item1.poemTheme}");
                }
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static void reportByPoemTheme(List<Poem> poems)
        {
            var res = from item in poems
                      group item by item.poemTheme;

            Console.WriteLine("Report by poem theme:");
            Console.WriteLine();

            foreach (var item in res)
            {
                Console.WriteLine($"Poem theme: {item.Key}");

                foreach (var item1 in item)
                {
                    Console.WriteLine($"Poem name:  {item1.poemName}");
                    Console.WriteLine($"Author theme: {item1.authorName}");
                }
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine();
        }

        static void reportByWordInPoem(List<Poem> poems)
        {
            string[] strings;
            
            foreach (var item in poems)
            {
                Console.WriteLine(item.poemName);
                Console.WriteLine("-----------------------------------");

                strings = item.poemText.Split(new char[] { ',', ' ','!','?',':',';','.','\r','\n','\t' });
                var res = from str in strings
                          group str by str.ToLower().ToString();

                foreach (var item1 in res)
                {
                    Console.WriteLine($"Word: {item1.Key}");
                    Console.WriteLine($"Amount:{item1.Count()}");
                    Console.WriteLine("**********************");
                }
                Console.WriteLine("-----------------------------------");
            }
        }

        static void reportByYearOfCreation(List<Poem> poems)
        {
            var res = from item in poems
                      group item by item.yearOfCreation;

            foreach (var item in res)
            {
                Console.WriteLine($"Year of creation: {item.Key}");

                foreach (var item1 in item)
                {
                    Console.WriteLine($"Poem author: {item1.authorName}");
                    Console.WriteLine($"Poem name:   {item1.poemName}");
                    Console.WriteLine("----------------------------------");
                }
                Console.WriteLine();
            }
        }

        static void reportByPoemLength(List<Poem> poems)
        {
            string[] strings;
           
            foreach (var item in poems ) 
            {
                Console.WriteLine("-----------------------------------");
                strings = item.poemText.Split(new char[] { ',', ' ', '!', '?', ':', ';', '.', '\r', '\n'});
                var res = from p in strings
                          group p by strings.Length;
                foreach (var item1 in res) 
                {
                    Console.WriteLine($"Poem length: {item1.Key}");
                }
                Console.WriteLine($"Poem author: {item.authorName}");
                Console.WriteLine($"Poem name:   {item.poemName}");
                
            }
        }
    }
}