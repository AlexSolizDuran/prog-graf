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
        private float[] _Vertices ;
        private uint[] _Indices;

        public CfiguraT(float X, float Y, float Z)
        {                    //alto,largo,prof   X    Y     Z 
            Ccubo cubo1 = new(0.3f, 0.7f, 0.2f, X, 0.3f + Y, Z);
            _Indices = cubo1.GetIndices();
            _Vertices = cubo1.GetVertices();

            Ccubo cubo2 = new(0.6f, 0.3f, 0.2f, X, -0.15f + Y, Z);
            JuntarInd(cubo2.GetIndices());
            JuntarVer(cubo2.GetVertices());

        }
        //junta los vertices
        private void JuntarVer(float[] ver2)
        {
            int cant = Nvert();
            int cant1 = ver2.Length;
            if (cant < cant + cant1)
            {
                Array.Resize(ref _Vertices, cant + cant1);
            }

            for (int i = 0; i < cant1; i++)
            {
                InserVer(cant + i, ver2[i]);
            }

        }
        //junta los indices
        private void JuntarInd(uint[] ind2)
        {
            int cant = Nindi();
            int cant1 = ind2.Length;
            if (cant < cant + cant1)
            {
                Array.Resize(ref _Indices, cant + cant1);
            }

            for (int i = 0; i < cant1; i++)
            {
                InserInd(cant + i, ind2[i] + (ind2.Max() + 1));
            }
        }

        //inserta un uint a una posicion de el arreglo de indices
        private void InserInd(int pos, uint elem) { _Indices[pos] = elem; }
        //inserta un float a una posicion de el arreglo de vertices
        private void InserVer(int pos, float elem) { _Vertices[pos] = elem; }
        //cantidad de los vertices
        public int Cant_Vert() { return _Indices.Length / 3; }
        //cantidad de los elementos del arreglo de los indices
        public int Nindi() { return _Indices.Length; }
        //cantidad de los elementos del arreglo de vertices
        public int Nvert() { return _Vertices.Length; }

        public float[] GetVertices() { return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
    }
}
