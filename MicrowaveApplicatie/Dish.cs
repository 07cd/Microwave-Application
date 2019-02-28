using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicrowaveApplicatie 
{


    public class Dish 
    {
       

        private string name;

        // Set and get Name of the dish
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        
        private string url;

        // Set and get the URL
        public string URL
        {
            get { return url; }
            set { url = value; }
        }

   
        // Constructor to set the name and url
        public Dish(string name, string url)
        {
          
            Name = name;
            URL = url;
        }


    }
}
