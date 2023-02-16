using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;

namespace Space
{
    internal partial class Program
    {
        
        async static Task Main(string[] args)
        {
            LogToFile.Activate();
            LogToConsole.Activate();
            Log.WriteLog("Program started WITHOUT AWAIT");


            MyCollection<Planet> currentCol = Coll();

            Action<IPlanet> printNameAndW = (IPlanet x) => WriteLine($"name = {x._name} ; value = {x._weight}");
            Action<SpaceObject> printObj = (SpaceObject x) => WriteLine($"name = {x._name} ; value = {x._type}");

            Func<IPlanet, IPlanet, bool> sortPlanetsByNames = (IPlanet x, IPlanet y) => x._name.CompareTo(y._name) == 1;
            Func<ISpaceObject, ISpaceObject, bool> sortSpaceObjsByNames = (ISpaceObject x, ISpaceObject y) => x._name.CompareTo(y._name) == 1;

            currentCol.AsyncSortByField(sortPlanetsByNames);
            currentCol.AsyncSortByField(sortSpaceObjsByNames);
            Log.WriteLog("Что-то тут происходит");
            Log.WriteLog("Что-то тут происходит2");

            
            
            ReadKey();
            Log.WriteLog("Program ended");
            
        }

        public static MyCollection<Planet> Coll()
        {
            MyCollection<Planet> currentCol = new MyCollection<Planet>();
            /*StarSystem starSun = new StarSystem("Sun", 5780, 1, 12345);
            StarSystem starSirius = new StarSystem("Sirius", 9940, 10, 123454);
            Constellation bigDog = new Constellation("Big Dog", "Orion", 380, 20);
            
            bigDog.AddStarTOConstellation(starSun);
            bigDog.AddStarTOConstellation(starSirius);

            currentCol.Add(bigDog);
            Log.WriteLog($"{bigDog._name} add to collection");
            currentCol.Add(starSun);
            Log.WriteLog($"{starSun._name} add to collection");
            currentCol.Add(starSirius);
            Log.WriteLog($"{starSirius._name} add to collection");*/

            Spaceship ship1 = new Spaceship("type SpaceShip1", "Edens Zero", "Shiki", "Treasure hunters", 2342, 12, 10, 12344, new DateTime(2022, 9, 19));
            Spaceship ship3 = new Spaceship("type SpaceShip3", "Tail", "Mavsa", "Treasure hunters", 242, 10, 9, 123, new DateTime(2022, 9, 19));
            Spaceship ship2 = new Spaceship("type SpaceShip2", "Fairy", "Mavsa", "Treasure hunters", 242, 10, 9, 123, new DateTime(2022, 9, 19));
            Satellite satellite1 = new Satellite("type Satellite1", "A3r23", new DateTime(2022, 8, 10), 234, "Aeroflot", new DateTime(2022, 9, 19));
            Satellite satellite2 = new Satellite("type Satellite2", "R2r23", new DateTime(2022, 8, 10), 234, "Aeroflot", new DateTime(2022, 9, 19));
            Satellite satellite3 = new Satellite("type Satellite3", "B3r23", new DateTime(2022, 8, 10), 234, "Aeroflot", new DateTime(2022, 9, 19));

            currentCol.Add(ship1); Log.WriteLog($" Spaceship{ship1._name} add to collection");
            currentCol.Add(ship3); Log.WriteLog($" Spaceship{ship3._name} add to collection");
            currentCol.Add(ship2); Log.WriteLog($" Spaceship{ship2._name} add to collection");
            currentCol.Add(satellite1); Log.WriteLog($" Satellite{satellite1._name} add to collection");
            currentCol.Add(satellite2); Log.WriteLog($" Satellite{satellite2._name} add to collection");
            currentCol.Add(satellite3); Log.WriteLog($" Satellite{satellite3._name} add to collection");

            Planet testplanet = new Planet("Planet", 231, 12, 123, "A", new int[3] {11, 11, 11});
            Planet testplanet2 = new Planet("A", 241, 12, 123, "TestVal", new int[3] {11, 11, 11});
            Planet testplanet32 = new Planet("Planet2", 231, 12, 123, "A", new int[3] {11, 11, 11});

            currentCol.Add(testplanet); Log.WriteLog($" Planet {testplanet._name} add to collection");
            currentCol.Add(testplanet2); Log.WriteLog($" Planet {testplanet2._name} add to collection");
            currentCol.Add(testplanet32); Log.WriteLog($" Planet {testplanet32._name} add to collection");

            Elemental oceanPlanet = new Elemental("Elemental", 340, 23, 50, "D", new int[3] {15, 12, 11}, 
                "water", "storm", new List<string> {"water Flower"}, new List<string> {"fur seal", "killer whale"});
            Elemental oceanPlanet2 = new Elemental("L", 240, 23, 50, "pirate treasure", new int[3] {15, 12, 11}, 
                "water", "storm", new List<string> {"Cffff"}, new List<string> {"fur seal", "killer whale"});
            Elemental icePlanet = new Elemental("C", 3400, 14, 70, "Treasures of the Snow Queen", new int[3] {100, 12, 112}, 
                "ice", "wind", new List<string> {"Eererer"}, new List<string> {});
            Elemental oceanPlanet32 = new Elemental("Elemental2", 340, 23, 50, "D", new int[3] {15, 12, 11}, 
                "water", "storm", new List<string> {"water Flower"}, new List<string> {"fur seal", "killer whale"});
            Magical FairyTail = new Magical("D", 244, 15, 110, "Treasure hunter's secret", new int[3] {100, 12, 112}, "holder", "Magic", 230000, 14);
            Magical FairyTail2 = new Magical("A1", 244, 15, 110, "Treasure hunter's secret", new int[3] {100, 12, 112}, "holder", "Magic", 230000, 14);
            Technoplanet roboPlanet = new Technoplanet("N", 12, 233, 10, "random", new int[3] {1100, 1100, 1001}, 12344444, "white", 23424, 10);
            Technoplanet roboPlanet2 = new Technoplanet("1N", 12, 233, 10, "random", new int[3] {1100, 1100, 1001}, 12344444, "white", 23424, 10);

            currentCol.Add(oceanPlanet);   Log.WriteLog($" Planet {oceanPlanet._name} add to collection");
            currentCol.Add(oceanPlanet2);  Log.WriteLog($" Planet {oceanPlanet2._name} add to collection");
            currentCol.Add(icePlanet);     Log.WriteLog($" Planet {icePlanet._name} add to collection");
            currentCol.Add(oceanPlanet32); Log.WriteLog($" Planet {oceanPlanet32._name} add to collection");
            currentCol.Add(FairyTail);     Log.WriteLog($" Planet {FairyTail._name} add to collection");
            currentCol.Add(FairyTail2);    Log.WriteLog($" Planet {FairyTail2._name} add to collection");
            currentCol.Add(roboPlanet);    Log.WriteLog($" Planet {roboPlanet._name} add to collection");
            currentCol.Add(roboPlanet2);   Log.WriteLog($" Planet {roboPlanet2._name} add to collection");
            
            
            return currentCol;
        }

        public static void Task5()
        {
            MyCollection<Planet> currentCol = Coll();

            Action<IPlanet> printNameAndW = (IPlanet x) => WriteLine($"name = {x._name} ; value = {x._weight}");
            Action<SpaceObject> printObj = (SpaceObject x) => WriteLine($"name = {x._name} ; value = {x._type}");
            Action<Constellation> printConstell = (Constellation x) => WriteLine($"name = {x.GetName()} ; type = {x.GetType()}");
            Action<StarSystem> printStarSystem = (StarSystem x) => WriteLine($"name = {x.GetName()} ; type = {x._temperature}");

            WriteLine("COLLECTION BEFORE SERIALIZATION:");
            currentCol.Foreach(printNameAndW);
            currentCol.Foreach(printObj);
            currentCol.Foreach(printConstell);
            currentCol.Foreach(printStarSystem);
            
            try
            {
                currentCol.Serializ("outputFiles1");
                Log.WriteLog("All Collection Serializes");
                
                
            }
            catch(DirectoryNotFoundException ex)
            {
                Log.WriteLog(ex);
            }
            try
            {
                MyCollection<Planet> newCol = MyCollection<Planet>.Deserialize("outputFiles");
                Log.WriteLog("All Collection deserializes");

                WriteLine("COLLECTION AFTER SERIALIZATION:");
                newCol.Foreach(printNameAndW);
                newCol.Foreach(printObj);
                newCol.Foreach(printConstell);
                newCol.Foreach(printStarSystem);
            }
            catch(FileNotFoundException ex)
            {
                Log.WriteLog(ex);
            }

            try
            {
                Planet testplanetException = new Planet("Planet", -231, 12, 123, "A", new int[3] {11, 11, 11});
            }
            catch (PlanetException ex)
            {
                Log.WriteLog(ex);
            }
        }
    }
}