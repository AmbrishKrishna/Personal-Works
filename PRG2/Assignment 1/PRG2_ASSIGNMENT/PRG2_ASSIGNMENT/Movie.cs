using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG2_ASSIGNMENT
{
    class Movie
    {
        //attributes
        private string title;
        private int duration;
        private string classification;
        private DateTime opening_date;

        //properties
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Duration
        {
            get { return duration; }
            set { duration = value; }
        }

        public string Classification
        {
            get { return classification; }
            set { classification = value; }
        }

        public DateTime Opening_date
        {
            get { return opening_date; }
            set { opening_date = value; }
        }
        public List<string> GenreList { get; set; }
        public List<Screening> ScreeningList { get; set; }

        //constructors
        public Movie() { }
        public Movie(string t, int d, string c, DateTime o, List<Screening> s)
        {
            Title = t;
            Duration = d;
            Classification = c;
            Opening_date = o;
            ScreeningList = s;
        }
        
        public void AddGenre(string g)
        {
            GenreList.Add(g);
        }
        public override string ToString()
        {
            return "Title: " + Title + " Duration: " + Duration + " Classification: " + Classification
                + " OpeningDate: " + Opening_date + " GenreList: " + GenreList + " ScreeningList: " + ScreeningList;
        }
    }
}
