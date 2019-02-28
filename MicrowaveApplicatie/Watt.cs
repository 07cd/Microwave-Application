using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MicrowaveApplicatie
{
    class Watt
    {
        // Constructor for the initial Watt
        public Watt(int initialIndex)
        {
            index = initialIndex;
        }

        // Array for all possible watt values
        public int[] Wattage = {600, 700, 800, 1000, 1200};
        
        // Index for the Wattage array
        public int index { get; set; }

        // Return Wattage value of selected index
        public int currWatt
        {
            get { return Wattage[index]; }
        
        }
    }
}
