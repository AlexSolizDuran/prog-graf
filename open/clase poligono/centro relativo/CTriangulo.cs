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
            
        }
        public List<Vector3> GetVertices()
        {
            List < Vector3 >vector = new(_Vertices);
            return vector ; 
        }
        public float PosverticesX(int pos) { return _Vertices[pos].X;}
        public Vector3 GetVerticespos(int pos){ return _Vertices[pos]; }

    }
}
