using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
/*PLEASE IGNORE MY OLD CODE - I LEFT IT IN, SO I COULD UNDERSTAND THE STEPS*/
/* HERE IS A RABBIT TO HELP YOU IGNORE:
 * {\__/}
 * ( ^-^)
 * />HI!
  omg he likes you!*/

namespace MovieApp
{
    class Repository
    {
        //---connection to database
        private readonly MySqlConnection connection;
        //private IList<Movie> movies;
        //private static int counter = 0;

        public Repository(MySqlConnection mySqlConnection)
        {
            this.connection = mySqlConnection;
            //movies = new List<Movie>();
        }

        internal Movie CreateMovie(Movie toCreate)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "insert into movies(title, star, genre, date_released) " +
                "values(@Title, @Star, @Type, @Date)";
            command.Parameters.AddWithValue("@Title", toCreate.Title);
            command.Parameters.AddWithValue("@Star", toCreate.Star);
            command.Parameters.AddWithValue("@Type", toCreate.Type);
            command.Parameters.AddWithValue("@Date", toCreate.Date);
            command.Prepare();
            command.ExecuteNonQuery();

            connection.Close();

            Movie movie = new Movie();
            movie.ID = (int)command.LastInsertedId;
            movie.Title = toCreate.Title;
            return movie;
            //toCreate.ID = counter;
            //counter++;
            //movies.Add(toCreate);
            //return toCreate;

        }



        internal IEnumerable<Movie> ReadMovie()
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"select * from movies";
            MySqlDataReader reader = command.ExecuteReader();

            IList<Movie> movies = new List<Movie>();
            while (reader.Read())
            {
                int id = reader.GetFieldValue<int>("id");
                string title = reader.GetFieldValue<string>("title");

                Movie movie = new Movie() { ID = id, Title = title };
                movies.Add(movie);
            }

            connection.Close();
            return movies;
            //return movies;
        }

        internal bool Exists(int id)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT COUNT(*) FROM movies WHERE id=@id";
            command.Parameters.AddWithValue("@id", id);
            command.Prepare(); 
            int result = Convert.ToInt32(command.ExecuteScalar());

            connection.Close();

            return result > 0;
            //throw new NotImplementedException();
        }

        internal void DeleteMovie(int id)
        {
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from movies where id={id}";
            command.ExecuteNonQuery();

            connection.Close();


            //for (int i = 0; i < movies.Count; i++)
            //{
            //    if (movies[i].ID == id)
            //    {
            //        movies.RemoveAt(i);
            //        break;
            //    }
            //}
        }


        /*        internal Movie DeleteMovie()
                {
                    //movies.Remove(new Movie() {ID = remID });
                   return movies.RemoveAt(remID);
                }*/






    }
}
