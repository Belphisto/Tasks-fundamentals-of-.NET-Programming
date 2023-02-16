using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Space
{
   
    public interface IPlanet
    {
        public string _name {get; set;}
        public string _valuableResource {get;set;}
        public double _weight {get; set;}
    }
    [XmlInclude(typeof(Elemental))]
    [XmlInclude(typeof(Magical))]
    [XmlInclude(typeof(Technoplanet))]
    public class Planet: IPlanet
    {
        public string _name {get; set;}
        public double _weight {get; set;}
        public double _diameter {get; set;}
        public double _period {get; set;}
        public string _valuableResource {get;set;}
        public int[] _coordinate = new int[3];
        [XmlIgnore]
        public StarSystem _mainStar {get;set;}

        internal string GetName() => this._name;
        public Planet(){}

        public Planet(string name, double w, double d, double p, string val, int[] c)
        {
            if (w < 0) {throw new PlanetException("A planet cannot have a negative weight.", w);}
            else
            {
                this._name = name;
                this._weight = w;
                this._diameter = d;
                this._period = p;
                this._valuableResource = val;
                this._coordinate = c;
                _mainStar = null;
            }
        }
        internal interface IEnumerable<out Planet> :IEnumerable
        {
            new IEnumerator<Planet> GetEnumerator();
        }

        internal virtual void PrintPlanet() //
        {
            WriteLine($"Planet {this._name}:");
            WriteLine($"    A distance x = {this._coordinate[0]}, y = {this._coordinate[1]}, z = {this._coordinate[2]} from the center of the star {this._mainStar} system");
            WriteLine($"    Diameter of the planet {this._diameter} space units");
            WriteLine($"    Weight of the planet {this._weight} space units");
            WriteLine($"    Orbital period around a star is {this._period} days");
            WriteLine($"    Useful resource: {this._valuableResource}");
        }

        internal bool CheckAddToStar(StarSystem star)
        {
            if (this._mainStar == null)
            {
                this._mainStar = star;
                return true;
            }
            else
            {
                return false;
            }
        }

        internal static double GetDistBetwPlanets (Planet planet1, Planet planet2)
        {
            double distance = Math.Sqrt((planet2._coordinate[0] - planet1._coordinate[0])^2+(planet2._coordinate[1]
             - planet1._coordinate[1])^2+(planet2._coordinate[2] - planet1._coordinate[2])^2);
            return distance;
        }

        
    }
}