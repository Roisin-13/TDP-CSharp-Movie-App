using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    class Menu
    {
        private MovieController movieController;

        public Menu(MovieController movieController) {
            this.movieController = movieController;
        }
        public enum CrudOptions
        {
            CREATE,
            READ,
           // UPDATE,
            DELETE,
            QUIT
        }

        public void CrudMenu()
        {
            bool inMenu = true;
            var values = Enum.GetValues(typeof(CrudOptions));
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
            while (inMenu)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                bool b = Enum.TryParse(input, true, out CrudOptions crudInput);
                if (!b)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                switch (crudInput)
                {
                    case CrudOptions.CREATE:
                        Console.WriteLine("Creating");
                        movieController.CreateMovie();
                        Console.WriteLine();
                        Console.WriteLine("Chose another option:");
                        CrudMenu();
                        break;
                    case CrudOptions.READ:
                        Console.WriteLine("Reading");
                        movieController.ReadMovie();
                        Console.WriteLine();
                        Console.WriteLine("Chose another option:");
                        CrudMenu();
                        break;
                    case CrudOptions.DELETE:
                        Console.WriteLine("Deleting");
                        movieController.DeleteMovie();
                        Console.WriteLine();
                        Console.WriteLine("Chose another option:");
                        CrudMenu();
                        break;
                    case CrudOptions.QUIT:
                        inMenu = false;
                        break;
                }
                Console.WriteLine("Please press any key to continue");
                Console.ReadKey();
            }
        }





    }
}
