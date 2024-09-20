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
        public static Vector centro (List<Vector> list)
        {
            List<float> listX =new List<float>();
            List<float> listY =new List<float>();
            List<float> listZ =new List<float>();
            foreach(Vector v in list)
            {
                listX.Add(v.X);
                listY.Add(v.Y);
                listZ.Add(v.Z);
            }
            float[] arrayX = listX.ToArray();
            float[] arrayY = listY.ToArray();
            float[] arrayZ = listZ.ToArray();
            float X= (arrayX.Min() + arrayX.Max())/2;
            float Y= (arrayY.Min() + arrayY.Max())/2;
            float Z= (arrayZ.Min() + arrayZ.Max())/2;

            Vector vector = new Vector(X,Y,Z);

            return vector;
        }

        public static object BuscarPorNombre(object contenedor, string nombre)
        {
            if (contenedor == null) return null;

            // Verifica si el contenedor es un Dictionary<string, T>
            var tipoContenedor = contenedor.GetType();
            if (tipoContenedor.IsGenericType && tipoContenedor.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                // Obtiene la instancia del diccionario
                var claveTipo = tipoContenedor.GetGenericArguments()[0];
                var valorTipo = tipoContenedor.GetGenericArguments()[1];
                var diccionario = (System.Collections.IDictionary)contenedor;

                // Recorre el diccionario
                foreach (var clave in diccionario.Keys)
                {
                    var valor = diccionario[clave];

                    // Comprueba si la clave coincide con el nombre buscado
                    if (clave.ToString() == nombre)
                    {
                        return valor;
                    }

                    // Busca recursivamente en el valor
                    var resultado = BuscarPorNombre(valor, nombre);
                    if (resultado != null)
                    {
                        return resultado;
                    }
                }
            }

            return null;
        }
    }
}
