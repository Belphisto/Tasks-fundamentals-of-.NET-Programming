using System;
using static System.Console;

namespace Space
{
    public interface IStarSystem
        {
            internal string _name {get; set;}
            internal int _temperature {get;set;}
        }

    public class StarSystem: IStarSystem
    {
       public string _name {get; set;}
       public int _temperature {get; set;}
       public string _color;
       public double _weight;
       public char _spectralClass;
       public int _old;
       protected Constellation _system; 
       public List<SpaceObject> _spaceObject;
       public List<Planet> _planets;

        internal StarSystem(){}
       internal StarSystem(string name, int temp, double weight, int old)
       {
            this._spaceObject = new List<SpaceObject>();
            this._planets = new List<Planet>();
            this._old = old;
            this._name = name;
            this._temperature = temp;
            this._weight = weight;
            if (temp >= 30000)
            {
                this._color = "Blue";
                this._spectralClass = 'O';
            }
            else if (temp >= 10000)
            {
                this._color = "Blue-white";
                this._spectralClass = 'B';
            }
            else if (temp >= 7500)
            {
                this._color = "White";
                this._spectralClass = 'A';
            }
            else if (temp >= 6000)
            {
                this._color = "Yellow-white";
                this._spectralClass = 'F';
            }
            else if (temp >= 5200)
            {
                this._color = "Yellow";
                this._spectralClass = 'G';
            }
            else if (temp >= 3700)
            {
                this._color = "Light-orange";
                this._spectralClass = 'K';
            }
            else
            {
                this._color = "Orange-red";
                this._spectralClass = 'M';
            }
       }
       internal string GetName() => this._name;
       internal string GetTemperature() => this._color;
       internal char GetSpectral() => this._spectralClass;
       internal void PrintSystem()
        {
            GetName();
            WriteLine($"Center of the star system: {this._name}");
            WriteLine($"Planets in this star system: {this.GetAllNamePlanets}");
            WriteLine($"Space object of this star system: {this.GetAllNameObjects}");
        }
       internal void PrintStar()
       {
            WriteLine($"This is the {this._name} star");
            WriteLine($"    This star is {this._old} million years old.");
            WriteLine($"    Star weight: {this._weight} astronomical masses");
            WriteLine($"    Star temperature: {this._temperature} K");
            WriteLine($"    star color: {this._color}, spectral class of the star: {this._spectralClass}");
       }

       internal string GetAllNameObjects()
        {
            string output = "";
            for (int i = 0; i < _spaceObject.Count; i++)
            {
                output += _spaceObject[i].GetName();
            }
            return output;
        }
        internal string GetAllNamePlanets()
        {
            string output = "";
            for (int i = 0; i < _planets.Count; i++)
            {
                output += _spaceObject[i].GetName();
            }
            return output;
        }

        internal void AddPlanetToStarSystem(Planet planet)
       {
        if (planet.CheckAddToStar(this))
        {
            this._planets.Add(planet);
            Log.WriteLog($"The planet {planet.GetName()} has been successfully attached to the {this._name} star system!");
        }
        else Log.WriteLog($"The planet {planet.GetName()} already belongs to another star system");
       }
       internal void AddPlanetToStarSystem(List<Planet> planet)
       {
            for (int i = 0; i < planet.Count; i++) {
                if (planet[i].CheckAddToStar(this))
                {
                    this._planets.Add(planet[i]);
                    Log.WriteLog($"The planet {planet[i].GetName()} has been successfully attached to the {this._name} star system!");
                }
                else Log.WriteLog($"The planet {planet[i].GetName()} already belongs to another star system");
            }
       }

       internal void AddSpaceObjToStarSystem(SpaceObject spaceObject)
       {
            this._spaceObject.Add(spaceObject);
            Log.WriteLog($"The space object {spaceObject.GetName()} has been successfully attached to the {this._name} star system!");
       }

       internal bool CheckAddToConstellation(Constellation system)
       {
            if (this._system == null)
            {
                this._system = system;
                return true;
            }
            else
            {
                return false;
            }
       }

    }

    public class Constellation
    {
        public string _name;
        public double _square;
        public int _count;
        public string _whoDescribed;
        public List<StarSystem> _stars;

        internal string GetName() => this._name;
        internal Constellation() {}

        internal Constellation(string name, string Described, double s, int c)
        {
            this._name = name;
            this._square = s;
            this._count = c;
            this._whoDescribed = Described;
            this._stars = new List<StarSystem>();
        }

        internal string GetAllNameStar()
        {
            string temp = "";
            foreach (var c in this._stars)
            {
                temp+= c.GetName();
                temp+= " ";
            }
            return temp;
        }
        internal void PrintConstellation()
        {
            WriteLine($"This is the constellation Aquarius.");
            WriteLine($"    Constellation Described {this._whoDescribed}");
            WriteLine($"    Area in sq. degrees : {this._square}");
            WriteLine($"    Total stars in the constellation: {this._count}");
            WriteLine($"    Star information available: {this.GetAllNameStar()}");
            WriteLine();
        }

        internal void AddStarTOConstellation(StarSystem star)
        {
            if (star.CheckAddToConstellation(this))
            {
                this._stars.Add(star);
                Log.WriteLog($"The star {star.GetName()} has been successfully attached to the {this._name} constellation!");
            }
            else Log.WriteLog($"The planet {star.GetName()} already belongs to another star system");
        }

    }
}