using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    class MovieController
    {

        //private static int counter = 0;

        //------linking services with controller
        private readonly Services services;
        public MovieController(Services services)
        {
            this.services = services; 
        }
        //==============CREATE METHOD===============//
        public void CreateMovie()
        {
            Console.WriteLine("Please enter title of movie:");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter Star of movie:");
            string star = Console.ReadLine();
            Console.WriteLine("Please enter genre of movie:");
            string genre = Console.ReadLine();
            Console.WriteLine("Please enter Date movie was released:");
            string dateInput = Console.ReadLine();
            var date = DateTime.ParseExact(dateInput, "d", null);


            Movie toCreate = new Movie(title, star, genre, date);
            Movie newMovie = services.CreateMovie(toCreate); 
            Console.WriteLine($"Created new movie {newMovie}");

        }
        //==============READ METHOD===============//
        public void ReadMovie()
        {
            IEnumerable<Movie> movies = services.ReadMovie();
            foreach (var item in movies)
            {
                Console.WriteLine(item);
            }
        }
        //==============DELETE METHOD===============//
        public void DeleteMovie()
        {
            Console.WriteLine("Please enter ID of movie you want to delete:");
            string inputID = Console.ReadLine();
            var remID = int.TryParse(inputID, out int id);
            if (remID)
            {
                services.DeleteMovie(id);
            }
            
        }

/*        public void DeleteMovie()
        {

            Console.WriteLine("Please ID of movie you want to delete:");
            string inputID = Console.ReadLine();
            var remID = Int32.Parse(inputID);

            //Movie newMovie = new Movie(title, star, genre, date);
            //newMovie.ID = counter;
            //counter++;

        }*/






    }
}
