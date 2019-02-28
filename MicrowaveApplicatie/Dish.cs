using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicrowaveApplicatie 
{
    public class DishList : ObservableCollection<Dish>
    {
        public DishList() : base()
        {
            Add(new Dish("test", "hmm", " test"));
        }
    }




    public class Dish 
    {
       

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string url;

        public string URL
        {
            get { return url; }
            set { url = value; }
        }

        private string time;
        public string Time
        {
            get { return time; }
            set { time = value; }
        }


        public Dish(string name, string url, string time)
        {
            Time = time;
            Name = name;
            URL = url;
        }

        public Dish()
        {
        }
    }
}
