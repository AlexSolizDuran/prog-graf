using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Xml.XPath;

namespace Graficar
{   
    internal static class Metodo
    {
        public static void Serializacion<T>(T obj, string filePath)
        {
            string json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        // Lee el JSON desde un archivo y deserializa el objeto
        public static T Deserializacion<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static float[] VectorToVertice(List<Vector> lis)
        {
            List<Vector> list = lis;
            List<float> result = new List<float>();
            foreach (Vector v in list)
            {
                result.Add(v.X);
                result.Add(v.Y);
                result.Add(v.Z);
            }
            return result.ToArray();
        }
    }
}
