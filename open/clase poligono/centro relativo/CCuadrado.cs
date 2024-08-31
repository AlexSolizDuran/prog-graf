using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class CCuadrado : IPoligono
    {
        private readonly CTriangulo Triangulo1;
        private readonly CTriangulo Triangulo2; 
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide;
        public CCuadrado(float X, float Y, float Z) 
        {
            
                Triangulo1 = new CTriangulo(0.0f, 0.0f, Z,
                                            Y, 0.0F, Z,
                                            Y, X, Z);
                Triangulo2 = new CTriangulo(0.0f, 0.0f, Z,
                                            0.0f, X, Z,
                                            Y, X, Z);
            
            
            Juntar_Vertices();
            Juntar_Indices();
            Juntar_Centroide();

        }
        private void Juntar_Centroide()
        {
            float[] cen1 = Triangulo1.GetCentroide();

            float[] cen2 = Triangulo2.GetCentroide();
            _Centroide = new float[3]
            {
                (cen1[0]+cen2[0])/2,(cen1[1]+cen2[1])/2,(cen1[2]+cen2[2])/2
            };
        }
        public void Mov_Centroide(float X,float Y,float Z)
        {
            Triangulo1.Mov_Centroide(X, Y, Z);
            Triangulo2.Mov_Centroide(X, Y, Z);
        }

        private void Juntar_Vertices()
        {
            float[] ver1 = Triangulo1.GetVertices();
            
            float[] ver2 = Triangulo2.GetVertices();

            int cant = ver1.Length + ver2.Length;
            
            _Vertices = new float[cant];
            Array.Copy(ver1, 0, _Vertices, 0, ver1.Length);
            Array.Copy(ver2, 0, _Vertices, ver1.Length, ver2.Length);
            
        }
        private void Juntar_Indices()
        {
            uint[] ind1 = Triangulo1.GetIndices();

            uint[] ind2 = Triangulo2.GetIndices();

            int cant = ind1.Length + ind2.Length;

            _Indices = new uint[cant];
            Array.Copy(ind1, 0,_Indices,0,ind1.Length);
            for (int i = 0; i < ind2.Length; i++)
            {
                ind2 [i] += ind1.Max();
            }
            Array.Copy(ind2,0,_Indices,ind1.Length,ind2.Length);
        }
        public float[] GetCentroide()
        {
            return _Centroide;
        }

        public uint[] GetIndices()
        {
            return _Indices;
        }

        public float[] GetVertices()
        {
            return _Vertices;
        }
    }
}
