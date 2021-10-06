using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

using System.IO;
using MovieApp.Utils;

namespace MovieApp
{
    class Program
    {
        static void Main(string[] args)
        {//==========OLD stinky code================//
            //DateTime dt = new DateTime();
            //Movie mv1 = new Movie("RockyIV", "Stallone", "action", new DateTime(1986, 01, 24) );
            //Console.WriteLine(mv1.GetInfo());


            //============DB connection===================//
            MySqlConnection connection = mySqlUtils.GetConnection();
            connection.Open();

            //----connecting to sql file
            mySqlUtils.RunSchema(Environment.CurrentDirectory + @"\static\schema.sql", connection);


            //---checking connection
            bool connectionOpen = connection.Ping();
            Console.WriteLine($@"Connection status: {connection.State}
Ping successful: {connectionOpen}
DB version: {connection.ServerVersion}");


            connection.Dispose();



            //====================MENU code=======================//
                       Console.WriteLine("1. Movies \n2. Quit");
                        string input = Console.ReadLine();

                        switch (input)
                        {
                            case "movies":
                                CrudMenu();
                                break;
                            case "quit":

                                break;
                        }


            
    

        }
        //----I don't know why this has to be all the way down here, but won't work otherwise - so here it stays
        public static void CrudMenu()
        {
            Menu menu = new Menu(new MovieController(
                new Services(
                    new Repository(mySqlUtils.GetConnection()))));
            menu.CrudMenu();
        }



    }
}
