using System;
using System.Collections.Generic;
using System.Text;

namespace SliderProofOfConcept
{
    public class Slide
    {
        private double _val;

        public Slide(double value)
        {
            Val = value;
            Val = Math.Round(Val, 1);
        }

        public double Val
        {
            get
            {
                return _val;
            }
            set
            {
                _val = value;
                _val = Math.Round(_val, 1);
            }
        }
    }
}
