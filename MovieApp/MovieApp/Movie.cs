using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp
{
    class Movie
    {
        public int ID { get; set; }
        private string name;
        private string actor;
        private string genre;
        private DateTime dateReleased;

        //--------get/set film name
        public string Title
        {
            get { return name; }
            set { name = value; }
        }
        //--------get/set film actor
        public string Star
        {
            get { return actor; }
            set { actor = value; }
        }
        //--------get/set film genre
        public string Type
        {
            get { return genre; }
            set { genre = value; }
        }
        //--------get/set film date released
        public DateTime Date
        {
            get { return dateReleased; }
            set { dateReleased = value; }
        }
        //-----movie construcors:
        public Movie(string name, string actor, string genre, DateTime dateReleased)
        {
            this.Title = name;
            this.Star = actor;
            this.Type = genre;
            this.Date = dateReleased;
        }

        public override string ToString()
        {
            return $"Movie Name: {name}, ID: {ID}";
        }
        public Movie()
        {
        }

        public string GetInfo()
        {
            return $"{name}, is an {genre}film, with: {actor} starring, released {dateReleased}.";
        }






    }



}
