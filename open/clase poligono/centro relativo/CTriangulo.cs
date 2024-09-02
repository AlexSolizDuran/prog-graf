using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace centro_relativo
{
    internal class CTriangulo 
    {
        private List<Vector3> _Vertices;
        private List<uint> _Indices;
        private Vector3 _Centroide;

        public CTriangulo(float X1, float Y1, float Z1,
                          float X2, float Y2, float Z2,
                          float X3, float Y3, float Z3)
        {
            _Vertices =
            [
                new(X1,Y1,Z1),
                new(X2,Y2,Z2),
                new(X3,Y3,Z3)
            ];
            _Indices = [0, 1, 2];
            _Centroide = ((X1 + X2 + X3) / 3,
                          (Y1 + Y2 + Y3) / 3,
                          (Z1 + Z2 + Z3) / 3);
        }

        public void Mov_Centroide(float X, float Y, float Z)
        {
            _Centroide.X = X - _Centroide.X;
            _Centroide.Y = Y - _Centroide.Y;
            _Centroide.Z = Z - _Centroide.Z;
            
            Mov_Vertices();
        }

        private void Mov_Vertices()
        {
            for (int i = 0; i < _Vertices.Count; i++)
            {
                Vector3 vector3 = _Vertices[i];
                vector3.X += _Centroide.X;
                vector3.Y += _Centroide.Y;
                vector3.Z += _Centroide.Z;
            }
        }

        public void SetVerticesX(int pos, float valor) 
        {
            Vector3 v = _Vertices[pos];
            v.X = valor;
            _Vertices[pos] = v;
        }
        public List<Vector3> GetVertices()
        {
            return new List<Vector3>(_Vertices); 
        }
        public float PosverticesX(int pos) { return _Vertices[pos].X;}
        public Vector3 GetVerticespos(int pos){ return _Vertices[pos]; }
        public uint GetIndicespos(int pos) { return _Indices[pos]; }
        public Vector3 GetCentroide(int pos) { return _Centroide; }
    }
}
