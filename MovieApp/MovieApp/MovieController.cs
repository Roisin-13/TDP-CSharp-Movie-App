using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    class MovieController
    {
        private readonly IList<Movie> movies;

        private static int counter = 0;

        public MovieController() => movies = new List<Movie>();

        //public void AddMovie(Movie movie)
        //{
        //    movies.Add(movie);
        //}




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


            Movie newMovie = new Movie(title, star, genre, date);
            newMovie.ID = counter;
            counter++;

            movies.Add(newMovie);

            Console.WriteLine($"Created new movie {newMovie}");

        }

        public void ReadMovie()
        {
            foreach (var item in movies)
            {
                Console.WriteLine(item);
            }
        }

 //       foreach (var item in collection)
	//{

	//}

        public void DeleteMovie()
        {
            Console.WriteLine("Please ID of movie you want to delete:");
            string inputID = Console.ReadLine();
            var remID = Int32.Parse(inputID);
            movies.Remove(new Movie() {ID = remID });
   


            //Movie newMovie = new Movie(title, star, genre, date);
            //newMovie.ID = counter;
            //counter++;

            //movies.Add(newMovie);

            //Console.WriteLine($"Created new movie {newMovie}");

        }






    }
}
