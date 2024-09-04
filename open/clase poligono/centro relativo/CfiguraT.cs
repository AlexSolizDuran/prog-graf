using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class CfiguraT
    {  
        private Dictionary<string, CObjeto> Objeto = new Dictionary<string, CObjeto>();
        private List<Vector3> _Vertices = new List<Vector3>();
        private List<uint> _Indices = new List<uint>();
        private Vector3 _Centroide;

        public CfiguraT()  
        {
            Objeto.Add("Cubo 1", new CObjeto(0.3f, 0.7f, 0.2f));
            Objeto.Add("Cubo 2", new CObjeto(0.6f, 0.3f, 0.2f));

            Objeto["Cubo 1"].Mov_Centroide(0.0f, 0.45f, 0.0f);
            Objeto["Cubo 2"].Mov_Centroide(0.0f, 0.0f, 0.0f);
            Juntar_Vertices();
            Juntar_Indices();
            Juntar_Centroide();

        }
        public void Cargar_buffer()
        {
            foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
            {
                kvp.Value.Cargar_Buffer();
            }
        }
        public void Dibujar()
        {
            foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
            {
                kvp.Value.Dibujar();
            }
        }
        public void Mover_Centroide(float X, float Y,float Z)
        {
            foreach(KeyValuePair<string, CObjeto> kvp in Objeto)
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

            foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
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
            foreach (KeyValuePair<string,CObjeto>kvp in Objeto)
            {
                listemp.AddRange(kvp.Value.GetVertices());
            }
            _Vertices = listemp;
        }
        private void Juntar_Indices()
        {   uint longitud = _Indices.Any() ? _Indices.Max() : 0;
            foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
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
    }
}
