using System;
using System.Collections.Generic;
//using System.Globalization.DateTimeStyles = 

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime dt = new DateTime();
            Movie mv1 = new Movie("RockyIV", "Stallone", "action", new DateTime(1986, 01, 24) );
            //Console.WriteLine(mv1.GetInfo());

            Console.WriteLine("1. Movies \n2. Quit");
            string input = Console.ReadLine();

            switch (input) 
            {
                case "1":
                    CrudMenu();
                    break;
                case "2":

                    break; 
            }
        }


        public static void CrudMenu()
        {
            Menu menu = new Menu(new MovieController());
            menu.CrudMenu();
        }



    }
}
