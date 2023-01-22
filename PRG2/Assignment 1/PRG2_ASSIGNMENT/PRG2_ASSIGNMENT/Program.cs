using System;
using System.Collections.Generic;
using System.IO;

namespace PRG2_ASSIGNMENT
{
    class Program
    {
        static void LoadDataOne(List<Movie> m, List<Cinema> c) //(1) Loading the Movie and Cinema Data
        {

            string[] cinemadata = File.ReadAllLines("Cinema.csv");
            for (int i = 1; i < cinemadata.Length; i++)
           
                string[] cinema = cinemadata[i].Split(',');
                Cinema newC = new Cinema(cinema[0], Convert.ToInt32(cinema[1]), Convert.ToInt32(cinema[2]));
                c.Add(newC);
            }

            string[] moviedata = File.ReadAllLines("Movie.csv");
            for (int i = 1; i < moviedata.Length; i++)
            {
                string[] movie = moviedata[i].Split(',');
                string[] DTime = movie[4].Split('/');
                DateTime dt = Convert.ToDateTime(DTime[1] + "/" + DTime[0] + "/" + DTime[2]);
                Movie newm = new Movie(movie[0], Convert.ToInt32(movie[1]), movie[3], dt, new List<Screening>());
                if (movie[2].Contains("/"))
                {
                    string[] genrelist = movie[2].Split('/');
                    foreach (string g in genrelist)
                    {
                        newm.AddGenre(g);
                    }
                }
                else { newm.AddGenre(movie[2]); }
                m.Add(newm);
            }

        }

        static void LoadDataTwo(List<Screening> s, List<Movie> m, List<Cinema> c) //(2) Loading the Screning Data
        {
            string[] screeningdata = File.ReadAllLines("Screening.csv");
            int screeningNumber = 1001;
            for (int i = 1; i < screeningdata.Count(); i++)
            {
                string[] screening = screeningdata[i].Split(',');
                string[] sDTime = screening[0].Split('/');
                DateTime sdt = Convert.ToDateTime(sDTime[1] + "/" + sDTime[0] + "/" + sDTime[2]);
                Cinema cine = SearchCinema(screening[2], Convert.ToInt32(screening[3]), c);
                Screening newS = new Screening(screeningNumber, sdt, screening[1], cine, SearchMovie(screening[4], m));
                newS.seatsRemaining = cine.capacity;
                foreach (Movie mov in m)
                {
                    if (mov.title == newS.Movie.title) { mov.AddScreening(newS); }
                }
                s.Add(newS);
                screeningNumber++;
            }
        }
        static Cinema SearchCinema(string n, int no, List<Cinema> cL) //Search the Cinema List for a specific Cinema
        {
            Cinema cObj = null;
            foreach (Cinema c in cL)
            {
                if ((c.name == n) && (c.hallNo == no)) { cObj = c; }
            }
            return cObj;
        }

        static Movie SearchMovie(string t, List<Movie> mL) //Searches the Movie List for a specific Movie
        {   
            Movie mObj = null;
            foreach (Movie m in mL)
            {
                if (m.title == t) { mObj = m; }
            }
            return mObj;
        }
        static void Main(string[] args)
            {
                List<Movie> movieList = new List<Movie>();
                List<Cinema> cinemaList = new List<Cinema>();
                List<Screening> screeningList = new List<Screening>();
                List<Order> orderList = new List<Order>();

        static void DisplayMovies(List<Movie> mL) //(3) Display all movies
        {
            int i = 1;
            foreach (Movie m in mL) { Console.WriteLine(String.Format("{0,-3}. {1}", i, m.ToString())); i++; }
        }

        static void ListScreenings(List<Movie> mL) //(4) List all screenings for a selected Movie
        {
            DisplayMovies(mL);
            int movieno = 0;
            bool valid_movieno = false;
            bool exit_option = true;
            while (!valid_movieno)
            {
                Console.Write("Select a movie: ");
                try
                {
                    movieno = Convert.ToInt32(Console.ReadLine()); if ((movieno <= mL.Count()) && (movieno >= 1)) { valid_movieno = true; }
                    else if (movieno == -1) { Console.WriteLine("Exiting to main menu..."); valid_movieno = true; exit_option = false; }
                    else { Console.WriteLine("Invalid Movie Number entered. Please try again."); }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
            if ((valid_movieno) && (exit_option))
            {
                Movie m = SearchMovie(mL[(movieno - 1)].title, mL);
                if (m.screeningList.Count != 0)
                {
                    foreach (Screening s in m.screeningList) { Console.WriteLine(s.ToString()); }
                }
                else { Console.WriteLine("There are no screenings for this movie."); }





        }
    }
}
