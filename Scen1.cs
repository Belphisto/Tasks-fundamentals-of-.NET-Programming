using System;
using static System.Console;

namespace Space
{
    internal partial class Program
    {
        public static void Task1()
        {
            List<StarSystem> starSystems = new List<StarSystem>();
            StarSystem starSun = new StarSystem("Sun", 5780, 1, 12345);
            StarSystem starSirius = new StarSystem("Sirius", 9940, 10, 123454);
            StarSystem starProximaCentauri = new StarSystem("Proxima Centauri", 3042, 0.5, 12333);
            starSystems.Add(starSun);
            starSystems.Add(starSirius);
            starSystems.Add(starProximaCentauri);

            Constellation bigDog = new Constellation("Big Dog", "Orion", 380, 20);
            bigDog.AddStarTOConstellation(starSirius);
            bigDog.AddStarTOConstellation(starProximaCentauri);

            List<Planet> allPlanet = new List<Planet>();
            Planet testplanet = new Planet("test", 231, 12, 123, "TestVal", new int[3] {11, 11, 11});
            allPlanet.Add(testplanet);
            Elemental oceanPlanet = new Elemental("Ocean", 340, 23, 50, "pirate treasure", new int[3] {15, 12, 11}, 
            "water", "storm", new List<string> {"water Flower"}, new List<string> {"fur seal", "killer whale"});
            allPlanet.Add(oceanPlanet);
            Elemental icePlanet = new Elemental("Ice castle", 3400, 14, 70, "Treasures of the Snow Queen", new int[3] {100, 12, 112}, 
            "ice", "wind", new List<string> {"snowdrop"}, new List<string> {});
            allPlanet.Add(icePlanet);
            Magical FairyTail = new Magical("Fairy Tail", 244, 15, 110, "Treasure hunter's secret", new int[3] {100, 12, 112}, "holder", "Magic", 230000, 14);
            allPlanet.Add(FairyTail);
            Technoplanet roboPlanet = new Technoplanet("Robots", 12, 233, 10, "random", new int[3] {1100, 1100, 1001}, 12344444, "white", 23424, 10);
            allPlanet.Add(roboPlanet);

            List<SpaceObject> allObj = new List<SpaceObject>();
            Spaceship ship1 = new Spaceship("type A", "Edens Zero", "Shiki", "Treasure hunters", 2342, 12, 10, 12344, new DateTime(2022, 9, 19));
            Spaceship ship2 = new Spaceship("type B", "Fairy", "Mavsa", "Treasure hunters", 242, 10, 9, 123, new DateTime(2022, 9, 19));
            Satellite satellite1 = new Satellite("type C", "A3r23", new DateTime(2022, 8, 10), 234, "Aeroflot", new DateTime(2022, 9, 19));
            allObj.Add(ship1);
            allObj.Add(ship2);
            allObj.Add(satellite1);

            starSun.AddPlanetToStarSystem(testplanet);
            starSun.AddPlanetToStarSystem(oceanPlanet);
            starSirius.AddPlanetToStarSystem(icePlanet);
            starSirius.AddPlanetToStarSystem(oceanPlanet);
            starSun.AddSpaceObjToStarSystem(ship1);
            starSun.AddSpaceObjToStarSystem(ship2);
            starSun.AddSpaceObjToStarSystem(satellite1);


            WriteLine();
            WriteLine("Welcome to outer space! Please select an action:");
            WriteLine(" Press 1 to view information about all constellations");
            WriteLine(" Press 2 to see information about all planets");
            WriteLine(" Press 3 to view information about all stars");
            WriteLine(" Press 4 to view information about all free space objects");
            WriteLine(" Press 5 if you want information about a specific star system");
            WriteLine(" Press 6 if you want information about a specific space Object");
            WriteLine(" Press 7 if you want information about a specific planet");
            WriteLine(" Press 8 if you want information about aboud distance between planet");
            WriteLine(" Press 0 to exit");
            char temp;
                try{
                    do {
                    temp = Convert.ToChar(ReadLine());
                    {
                    switch (temp)
                    {
                        case '1':
                            bigDog.PrintConstellation();
                            break;
                        case '2':
                            foreach(var c in allPlanet)
                            {
                                //c.PrintPlanet();
                                if (c is Magical plan) plan.PrintPlanet();
                                else if (c is Technoplanet tech) tech.PrintPlanet();
                                else if (c is Elemental elem) elem.PrintPlanet();
                                else c.PrintPlanet();
                            }
                            break;
                        case '3':
                            foreach(var c in starSystems)
                            {
                                c.PrintStar();
                            }
                            break;
                        case '4':
                            foreach(var c in allObj)
                            {
                                c.PrintObject();
                                //if (c is Satellite sat) sat.PrintSatellite();
                                //else if (c is Spaceship spac) spac.PrintSpaceship();
                            }
                            break;
                        case '5':
                            Write("Write name star: ");
                            try {
                            string tempStarName = ReadLine();
                            bool check = false;
                            foreach(var c in starSystems)
                            {
                                if (c.GetName() == tempStarName)
                                {
                                    check = true;
                                    WriteLine($"This system has space objects: {c.GetAllNameObjects()}");
                                    WriteLine($"This system has planets: {c.GetAllNamePlanets()}");
                                }
                            }
                            if (!check) WriteLine("Star not found");
                            check = false;}
                            catch(FormatException) 
                            {
                                Console.WriteLine("Invalid string!");
                            }
                            break;
                        case '6':
                            Write("Write name space object: ");
                            try {
                            string tempNameObj = ReadLine();
                            bool check2 = false;
                            foreach(var c in allObj)
                            {
                                if (c.GetName() == tempNameObj)
                                {
                                    check2 = true;
                                    c.PrintObject();
                                }
                            }
                            if (!check2) WriteLine("Space Object not found");
                            check2 = false;}
                            catch(FormatException) 
                            {
                                Console.WriteLine("Invalid string!");
                            }
                            break;
                        case '7':
                            Write("Write name palnet: ");
                            try{
                            string tempNamePlanet = ReadLine();
                            bool check3 = false;
                            foreach(var c in allPlanet)
                            {
                                if (c.GetName() == tempNamePlanet)
                                {
                                    check3 = true;
                                    if (c is Magical plan) plan.PrintPlanet();
                                    else if (c is Technoplanet tech) tech.PrintPlanet();
                                    else if (c is Elemental elem) elem.PrintPlanet();
                                    else c.PrintPlanet();
                                }
                            }
                            if (!check3) WriteLine("Planet not found");
                            check3 = false;}
                            catch(FormatException) 
                            {
                                Console.WriteLine("Invalid string!");
                            }
                            break;
                        case '8':
                            double dist = Planet.GetDistBetwPlanets(testplanet, icePlanet);
                            WriteLine($"Distance between {testplanet.GetName()} and {icePlanet.GetName()} = {dist}");
                            break;
                        default:
                            WriteLine("Invalid character!");
                            break ;
                    }
                    }
                    }
                    while (temp != '0') ;
                }
                catch(FormatException) 
                {
                    Console.WriteLine("Invalid string!");
                }
                
            }
        
        /*public static void Task2_3()
        {
            Planet testplanet = new Planet("A", 241, 12, 123, "TestVal", new int[3] {11, 11, 11});
            Elemental oceanPlanet = new Elemental("L", 240, 23, 50, "pirate treasure", new int[3] {15, 12, 11}, 
            "water", "storm", new List<string> {"Cffff"}, new List<string> {"fur seal", "killer whale"});
            Elemental icePlanet = new Elemental("C", 3400, 14, 70, "Treasures of the Snow Queen", new int[3] {100, 12, 112}, 
            "ice", "wind", new List<string> {"Eererer"}, new List<string> {});
            Magical FairyTail = new Magical("D", 244, 15, 110, "Treasure hunter's secret", new int[3] {100, 12, 112}, "holder", "Magic", 230000, 14);
            Technoplanet roboPlanet = new Technoplanet("N", 12, 233, 10, "random", new int[3] {1100, 1100, 1001}, 12344444, "white", 23424, 10);

            SinglyLinkedList<Planet> planets = new SinglyLinkedList<Planet>();
            planets.Add(testplanet); 
            planets.Add(oceanPlanet);
            planets.Add(icePlanet); 
            planets.Add(FairyTail); 
            planets.Add(roboPlanet); 

            Func<Planet, Planet, bool> names = (Planet x, Planet y) => x._name.CompareTo(y._name) == 1;
            Func<Planet, Planet, bool> values = (Planet x, Planet y) => x._valuableResource.CompareTo(y._valuableResource) == 1;
            Func<Planet, Planet, int> weight = (Planet x, Planet y) => x._weight.CompareTo(y._weight) ;
            Action<Planet> print = (Planet x) => WriteLine(x._name);
            Action<Planet> printWeight = (Planet x) => WriteLine(x._weight.ToString());
            SinglyLinkedList<Planet> planets_sorted = new SinglyLinkedList<Planet>();


            WriteLine("Not sorted list: ");
            foreach(var item in planets)
            {
                planets_sorted.AddBySortingByField(item, names);
                print(item);
                planets.Remove(item);
                
            }
            WriteLine();
            WriteLine("Sorted planets by name: ");
            foreach(var item in planets_sorted)
            {
                print(item);
            }
            WriteLine();
            WriteLine("Sorted planets by valuable Resource:");
            foreach(var item in planets_sorted)
            {
                planets.AddBySortingByField(item, values);
            }
            foreach(var item in planets)
            {
                print(item);
            }
            planets.CompareByField(testplanet, oceanPlanet, weight, "weight");

            printWeight(testplanet); printWeight(oceanPlanet);
            
        }*/
    
        //Task2
            /*
            MyCollection<Planet> currentCol = new MyCollection<Planet>();
            Planet testplanet = new Planet("C", 231, 12, 123, "A", new int[3] {11, 11, 11});
            Elemental oceanPlanet = new Elemental("E", 340, 23, 50, "D", new int[3] {15, 12, 11}, 
                "water", "storm", new List<string> {"water Flower"}, new List<string> {"fur seal", "killer whale"});
            Elemental icePlanet = new Elemental("A", 3400, 14, 70, "B", new int[3] {100, 12, 112}, 
                "ice", "wind", new List<string> {"snowdrop"}, new List<string> {});
            Magical FairyTail = new Magical("D", 244, 15, 110, "A", new int[3] {100, 12, 112}, "holder", "Magic", 230000, 14);
            Technoplanet roboPlanet = new Technoplanet("B", 12, 233, 10, "random", new int[3] {1100, 1100, 1001}, 12344444, "white", 23424, 10);
            currentCol.Add(testplanet);
            currentCol.Add(oceanPlanet);
            currentCol.Add(icePlanet);
            currentCol.Add(FairyTail);
            currentCol.Add(roboPlanet);
            currentCol.Add(roboPlanet);
            foreach(var temp in currentCol)
            {
                WriteLine(temp._name);
            }


            //Task3
            Func<IPlanet, IPlanet, bool> name = (IPlanet x, IPlanet y) => x._name.CompareTo(y._name) == 1;
            Func<IPlanet, IPlanet, bool> value = (IPlanet x, IPlanet y) => x._valuableResource.CompareTo(y._valuableResource) == 1;
            Func<IPlanet, IPlanet, bool> weight = (IPlanet x, IPlanet y) => x._weight.CompareTo(y._weight) == 1;
            Action<IPlanet> printName = (IPlanet x) => WriteLine($"name = {x._name}");
            Action<IPlanet> printNameAndVal = (IPlanet x) => WriteLine($"name = {x._name} ; value = {x._valuableResource}");
            Action<IPlanet> printNameAndW = (IPlanet x) => WriteLine($"name = {x._name} ; value = {x._weight}");
            WriteLine("SORTED BY NAME:");
            currentCol.SortByField(name);
            currentCol.Foreach(printName);
            WriteLine();
            WriteLine("SORTED BY VALUE:");
            currentCol.SortByField(value);
            currentCol.Foreach(printNameAndVal);
            WriteLine();
            WriteLine("SORTED BY WEIGHT:");
            currentCol.SortByField(weight);
            currentCol.Foreach(printNameAndW);
            */
    }
}