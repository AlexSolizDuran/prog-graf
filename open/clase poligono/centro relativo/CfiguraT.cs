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
        private float[] _Vertices ;
        private uint[] _Indices;
        private float[] _Centroide = new float[3];

        public CfiguraT(float X, float Y, float Z)  
        {
            Objeto.Add("Cubo 1", new CObjeto(0.3f, 0.7f, 0.2f));
            Objeto.Add("Cubo 2", new CObjeto(0.6f, 0.3f, 0.2f));

            Objeto["Cubo 1"].Mov_Centroide(0.0f, 0.45f, 0.0f);
            Objeto["Cubo 2"].Mov_Centroide(0.0f, 0.0f, 0.0f);
            JuntarVer();
            JuntarInd();
            Juntar_Centroide();

        }
        public void Mover_Centroide(float X, float Y,float Z)
        {
            
            foreach(KeyValuePair<string, CObjeto> kvp in Objeto)
            {
                float X2 = X + kvp.Value.PosCentroide(0);
                float Y2 = Y + kvp.Value.PosCentroide(1);
                float Z2 = Z + kvp.Value.PosCentroide(2);
                kvp.Value.Mov_Centroide(X2,Y2,Z2);
            }
            
            JuntarVer();
            Juntar_Centroide();
        }
        public void Juntar_Centroide()
        {
            for (int i = 0; i < 3;i++)
            {
                float suma = 0;
                foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
                {

                    suma += kvp.Value.GetCentroide()[i];
                }
                _Centroide[i] = suma / Objeto.Count;
            }  
        }
        //junta los vertices
        private void JuntarVer()
        {
            List<float> listtemp = new List<float>();
            foreach (KeyValuePair<string,CObjeto>kvp in Objeto)
            {
                listtemp.AddRange(kvp.Value.GetVertices());
            }
            _Vertices = listtemp.ToArray();

        }
        //junta los indices
        private void JuntarInd()
        {
            List<uint> listtemp = new List<uint>();
            uint suma = 0;
            foreach (KeyValuePair<string, CObjeto> kvp in Objeto)
            {
                uint[] indices = kvp.Value.GetIndices();
                for (int i = 0; i < indices.Length; i++)
                {
                    listtemp.Add(indices[i] + suma);
                }
                suma = (uint)listtemp.ToArray().Length;


            }
            
            _Indices = listtemp.ToArray();
        }

        

        public float[] GetVertices() { return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
    }
}
