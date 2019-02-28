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

        public Watt(int initialIndex)
        {
            index = initialIndex;
        }

        public int[] Wattage = {600, 700, 800, 1000, 1200};
        
        public int index { get; set; }

        public int currWatt
        {
            get { return Wattage[index]; }
        
        }
    }
}
