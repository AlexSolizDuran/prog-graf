using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class Ccubo:IPoligono
    {
        private List<CTriangulo> _CcuadradoList = [];
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide =new float[3];
        

        public Ccubo(float X, float Y, float Z)
        {
            
            _ListTriangulo.Add(new CTriangulo(0.0f, 0.0f, Z,
                                              Y, 0.0f, Z,
                                              Y, X, Z));
            _ListTriangulo.Add(new CTriangulo(0.0f, 0.0f, Z,
                                              0.0f, X, Z,
                                              Y, X, Z));
            Juntar_Vertices();
            Juntar_Indices();
            Juntar_Centroide();

        }
        private void Juntar_Centroide()
        {   
            
            for (int i = 0; i < 3; i++)
            {
                float suma = 0.0f;
                foreach (CCuadrado cuadrado in _CcuadradoList)
                {
                    suma += cuadrado.GetCentroide()[i];
                }
                _Centroide[i] = suma / _CcuadradoList.Count;
            }
            
        }
        private void Juntar_Indices()
        {
            //pasa los indices a un solo arreglo
            List<uint> inditemp = new List<uint>();
            uint suma = 0;
            foreach (CCuadrado cuadrado in _CcuadradoList)
            {
                uint[] indices = cuadrado.GetIndices();
                for (int i = 0; i < indices.Length; i++)
                {
                    inditemp.Add(indices[i] + suma);
                }
                suma = (uint)inditemp.ToArray().Length;

                    
            }
            _Indices = inditemp.ToArray();
        }
        private void Juntar_Vertices()
        {
            //pasa los vertices a un solo arreglo
            List<float> listtemp = new List<float>();
            foreach (CCuadrado cuadrado in _CcuadradoList)
            {
                listtemp.AddRange(cuadrado.GetVertices());
            }
            _Vertices = listtemp.ToArray();
        }

        
        public uint[] GetIndices() { return _Indices; }
        public float[] GetVertices(){ return _Vertices; }
        public float[] GetCentroide() { return _Centroide; }
        
        


    }
}
