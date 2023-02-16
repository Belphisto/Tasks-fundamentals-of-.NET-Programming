using System;
using static System.Console;

namespace Space
{
    public class PlanetException : ArgumentException
    {
        public double Value {get;}
        public PlanetException(string mes, double val) : base(mes)
        {
            Value = val;
        }
    }

}