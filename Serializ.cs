using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;


namespace Space
{
    interface ISerializator 
       {
             void Serialize<T>(List<T> objs, string fileName);
             List<T> Deserialize<T>(string fileName);
        }


    interface IJSONSerializator : ISerializator { }

    class JSONSerializator : IJSONSerializator
    {
        public List<T> Deserialize<T>(string fileName)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            int count = File.ReadAllLines(fileName).Length;
            string[] collectionfromJSON = File.ReadAllLines(fileName);
            List<T> currentCol = new List<T>();
            string fromJson = File.ReadAllText(fileName);
            currentCol = JsonConvert.DeserializeObject<List<T>>(fromJson);
            return currentCol;

        }
        public List<SpaceObject> Deserialize2<SpaceObject>(string fileName)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            int count = File.ReadAllLines(fileName).Length;
            string[] collectionfromJSON = File.ReadAllLines(fileName);
            List<SpaceObject> currentCol = new List<SpaceObject>();
            string fromJson = File.ReadAllText(fileName);
            currentCol = JsonConvert.DeserializeObject<List<SpaceObject>>(fromJson, new Newtonsoft.Json.JsonSerializerSettings 
            { 
                TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto,
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
            });
            return currentCol;

        }

        public void Serialize<T>(List<T> objs, string fileName)
        {
            //var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonConvert.SerializeObject(objs);

            File.WriteAllText(fileName, Newtonsoft.Json.JsonConvert.SerializeObject(objs, Formatting.Indented));

        }
        public void Serialize2<SpaceObject>(List<SpaceObject> objs, string fileName)
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            serializer.TypeNameHandling = Newtonsoft.Json.TypeNameHandling.Auto;
            using (StreamWriter sw = new StreamWriter(fileName))
            using (Newtonsoft.Json.JsonWriter writer = new Newtonsoft.Json.JsonTextWriter(sw))
            {
                serializer.Serialize(writer, objs, typeof(SpaceObject));
            }

        }
    }
}