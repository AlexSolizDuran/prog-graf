using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace centro_relativo
{
    internal class CTriangulo :IPoligono 
    {
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide;

        public CTriangulo(float X1, float Y1, float Z1,
                          float X2, float Y2, float Z2,
                          float X3, float Y3, float Z3)
        {
            _Vertices = new float[9]
            {
                X1, Y1, Z1,
                X2, Y2, Z2,
                X3, Y3, Z3
            };

            _Indices = new uint[3]
            {
                0, 1, 2
            };

            
            _Centroide = new float[3]
            {
                (X1 + X2 + X3) / 3,
                (Y1 + Y2 + Y3) / 3,
                (Z1 + Z2 + Z3) / 3
            };
        }

        public void Mov_Centroide(float X, float Y, float Z)
        {

            _Centroide[0] = X - _Centroide[0] ; _Centroide[1] = Y - _Centroide[1] ; _Centroide[2] = Z - _Centroide[2];
            Mov_Vertices();
        }

        private void Mov_Vertices()
        {

            _Vertices[0] += _Centroide[0]; _Vertices[3] += _Centroide[0]; _Vertices[6] += _Centroide[0];
            _Vertices[1] += _Centroide[1]; _Vertices[4] += _Centroide[1]; _Vertices[7] += _Centroide[1];
            _Vertices[2] += _Centroide[2]; _Vertices[5] += _Centroide[2]; _Vertices[8] += _Centroide[2];
        }

        public void SetVertices(int pos, float valor) { _Vertices[pos] = valor; }
        public float Posvertices(int pos) { return _Vertices[pos];}
        public float[] GetVertices(){ return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
        public float[] GetCentroide() { return _Centroide; }
    }
}
