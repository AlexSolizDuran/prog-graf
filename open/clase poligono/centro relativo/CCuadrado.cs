using OpenTK.Graphics.OpenGL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace centro_relativo
{
    internal class CCuadrado : IPoligono
    {
        private List<CTriangulo> _ListTriangulo = new List<CTriangulo>();
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide = new float[3];
        public CCuadrado(float X, float Y, float Z)
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
        public void Plano_X()
        {
            foreach (CTriangulo triangulo in _ListTriangulo)
            {
                triangulo.Plano_X();
            }
        }
        public void dibujar()
        {

        }
        private void Juntar_Centroide()
        { float suma;
            for (int i = 0; i < 3; i++)
            { 
                suma = 0.0f;
                foreach (CTriangulo triangulo in _ListTriangulo)
                {
                    suma += triangulo.GetCentroide()[i];
                }
                _Centroide[i] = suma / _ListTriangulo.Count;
            }
            
         
        }
        public void Mov_Centroide(float X,float Y,float Z)
        {
            foreach (CTriangulo triangulo in _ListTriangulo)
            {
                triangulo.Mov_Centroide(X,Y,Z);
            }
        }

        private void Juntar_Vertices()
        {
            List<float> vertemp = new List<float>();
            foreach (CTriangulo triangulo in _ListTriangulo)
            {
                vertemp.AddRange(triangulo.GetVertices());
            }
            _Vertices = vertemp.ToArray();
        }
        private void Juntar_Indices()
        {
            List<uint> inditemp = new List<uint>();
            uint suma=0;
            foreach (CTriangulo triangulo in _ListTriangulo)
            {
                uint[] indices = triangulo.GetIndices();
                for (int i = 0; i < indices.Length; i++)
                {
                    inditemp.Add(indices[i] + suma);
                }
                suma = (uint)inditemp.ToArray().Length;
            }
            _Indices = inditemp.ToArray();
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
