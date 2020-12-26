using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinowyde.DOP.Sim
{
    internal class SimType
    {
        internal SimType()
        {

        }

        public short Type { get; set; }
        public int Interval { get; set; }
        public int Step { get; set; }

        public int RangeMax { get; set; }
        public int RangeMin { get; set; }

        private double value = 0;
        public double Value
        {
            get
            {
                switch (Type)
                {
                    case 0:
                        Random rand = new Random();
                        return rand.Next(RangeMin, RangeMax);

                    case 1:
                        value += Step;
                        break;
                    case 2:
                        value -= Step;
                        break;
                }

                return value;
            }
            set { this.value = value; }
        }
    }
}
