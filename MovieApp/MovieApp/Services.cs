using MovieApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    class Services
    {
        //private IList<Movie> movies;
        //private static int counter = 0;

        //------linking repository with services
        private readonly Repository repository;
        public Services(Repository repository)
        {
            this.repository = repository;
        }

  /*      public Services()
        {
            movies = new List<Movie>();
        }*/

        internal Movie CreateMovie(Movie toCreate)
        {
            Movie newMovie = repository.CreateMovie(toCreate);
            return newMovie;

        }

        internal IEnumerable<Movie> ReadMovie()
        {
            return repository.ReadMovie();
        }


        internal void DeleteMovie(int id)
        {
            if (!repository.Exists(id))
            {
                throw new ItemNotFoundException();
            }
            repository.DeleteMovie(id);
        }



    }
}
