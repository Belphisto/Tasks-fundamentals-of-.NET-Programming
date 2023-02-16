using System;
using static System.Console;
using System.Xml.Serialization;

namespace Space
{
    
    public class Elemental : Planet
    {
       public string _element {get; set;}
       public List<string> _flora{get; set;}
       public List<string> _fauna{get; set;}
       public string _weather{get; set;}

       internal Elemental(string name, double w, double d, double p, in string val, int[] c,
            string elem, string wether, List<string> flora, List<string> fauna)
            : base(name, w, d, p, val, c)
       {
            this._element = elem;
            this._weather = wether;
            this._fauna = fauna;
            this._flora = flora;
       }
       internal Elemental()
            : base()
       {
       }
       public void PrintPlanet(Elemental planet)
       {
            WriteLine($"");
            WriteLine();
       }
        internal override void PrintPlanet()
        {
            base.PrintPlanet();
            WriteLine("         Additional characteristics of the Element Planet:");
            WriteLine($"            The planet is made up of the element: {this._element}");
            WriteLine($"            The weather on the planet is always: {this._weather} ");
            Write($"            Flora representatives: ");
            foreach (var temp in _flora)
            {
                Write($"{temp}, ");
            }
            WriteLine();
            Write($"            Fauna representatives: ");
            foreach (var temp in _fauna)
            {
                Write($"{temp}, ");
            }
            WriteLine();
        }
    }
}