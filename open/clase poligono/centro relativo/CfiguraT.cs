using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class CfiguraT : IDibujable
    {  
        private Dictionary<string, CCubo> Objeto = new Dictionary<string, CCubo>();
        private List<Vector3> _Vertices = new List<Vector3>();
        private List<uint> _Indices = new List<uint>();
        private Vector3 _Centroide;

        public CfiguraT()
        {
            //Objeto.Add("Cubo 1", new CCubo(0.3f, 0.7f, 0.2f));
            //Objeto.Add("Cubo 2", new CCubo(0.6f, 0.3f, 0.2f));
            //Objeto["Cubo 1"].Mov_Centroide(0.0f, 0.0f, 0.0f);
            //Objeto["Cubo 2"].Mov_Centroide(0.0f, 0.5f, 0.0f);
            String ubicacion1 = @"..\..\..\cubo1.txt";
            String ubicacion2 = @"..\..\..\cubo2.txt";
            (float[] vertice1, uint[] indice1) = Cargar(ubicacion1);
            (float[] vertice2, uint[] indice2) = Cargar(ubicacion2);
            Objeto.Add("Cubo 1", new CCubo(vertice1,indice1));
            Objeto.Add("Cubo 2", new CCubo(vertice2,indice2));
            

            Guardar(ubicacion1, Objeto["Cubo 1"].Getvertice(), Objeto["Cubo 1"].Getindice());
            Guardar(ubicacion2, Objeto["Cubo 2"].Getvertice(), Objeto["Cubo 2"].Getindice());
            
            
             
            Juntar_Vertices();
            Juntar_Indices();
            Juntar_Centroide();

        }
        public (float[], uint[]) Cargar(string filePath)
        {
            List<float> verticesList = new List<float>();
            List<uint> indicesList = new List<uint>();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.StartsWith("v "))
                {
                    // Procesar los vértices
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 4)
                    {
                        float x = float.Parse(parts[1], CultureInfo.InvariantCulture);
                        float y = float.Parse(parts[2], CultureInfo.InvariantCulture);
                        float z = float.Parse(parts[3], CultureInfo.InvariantCulture);

                        verticesList.Add(x);
                        verticesList.Add(y);
                        verticesList.Add(z);
                    }
                }
                else if (line.StartsWith("f "))
                {
                    // Procesar las caras (índices)
                    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 4)
                    {
                        for (int i = 1; i < parts.Length; i++)
                        {
                            uint index = uint.Parse(parts[i].Split('/')[0]) ;
                            indicesList.Add(index);
                        }
                    }
                }
            }

            return (verticesList.ToArray(), indicesList.ToArray());
        }
        public void Guardar(string filePath, float[] vertices, uint[] indices)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Escribir los vértices
                writer.WriteLine("# Vertices");
                for (int i = 0; i < vertices.Length; i += 3)
                {
                    writer.WriteLine($"v {vertices[i].ToString(CultureInfo.InvariantCulture)} {vertices[i + 1].ToString(CultureInfo.InvariantCulture)} {vertices[i + 2].ToString(CultureInfo.InvariantCulture)}");
                }

                // Escribir las caras (índices)
                writer.WriteLine("# Indices");
                for (int i = 0; i < indices.Length; i += 3)
                {
                    writer.WriteLine($"f {indices[i] } {indices[i + 1] } {indices[i + 2] }");
                }
            }
        }
        

        public void Cargar_Buffer()
        {
            foreach (KeyValuePair<string, CCubo> kvp in Objeto)
            {
                kvp.Value.Cargar_Buffer();
            }
        }
        public void Dibujar()
        {
            foreach (KeyValuePair<string, CCubo> kvp in Objeto)
            {
                kvp.Value.Dibujar();
            }
        }
        public void Mov_Centroide(float X, float Y,float Z)
        {
            foreach(KeyValuePair<string, CCubo> kvp in Objeto)
            {
                float X2 = X + kvp.Value.GetCentroide().X;
                float Y2 = Y + kvp.Value.GetCentroide().Y;
                float Z2 = Z + kvp.Value.GetCentroide().Z;
                kvp.Value.Mov_Centroide(X2,Y2,Z2);
            }
            Juntar_Vertices();
            Juntar_Centroide();
        }
        public void Juntar_Centroide()
        {
            float X = 0;
            float Y = 0;
            float Z = 0;

            foreach (KeyValuePair<string, CCubo> kvp in Objeto)
            {
                X += kvp.Value.GetCentroide().X;
                Y += kvp.Value.GetCentroide().Y;
                Z += kvp.Value.GetCentroide().Z;
            }
            int n = Objeto.Count;
            _Centroide.X = X / n;
            _Centroide.Y = Y / n;
            _Centroide.Z = Z / n;

        }
        
        private void Juntar_Vertices()
        {
            List<Vector3> listemp = new List<Vector3>();
            foreach (KeyValuePair<string,CCubo>kvp in Objeto)
            {
                listemp.AddRange(kvp.Value.GetVertices());
            }
            _Vertices = listemp;
        }
        private void Juntar_Indices()
        {   uint longitud = _Indices.Any() ? _Indices.Max() : 0;
            foreach (KeyValuePair<string, CCubo> kvp in Objeto)
            {
                List<uint> indices = kvp.Value.GetIndices();
                foreach (uint indice in indices)
                {
                    _Indices.Add(indice + longitud );
                }
                longitud = _Indices.Max() +1;
                
            }
        }
        public List<Vector3> GetVertices() { return _Vertices; }
        public List<uint> GetIndices() { return _Indices; }
        Vector3 IDibujable.GetCentroide(){ return _Centroide; }

        
    }
}
