using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using OpenTK.Mathematics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using LearnOpenTK.Common;

namespace centro_relativo
{
    internal class CObjeto : IDibujable
    {
        private List<CTriangulo> _TrianguloList = [];
        private int _VAO;
        private int _VBO;
        private int _EBO;
        private float[] _Vertice;
        private uint[] _Indice;
        private List<Vector3> _Vertices = new List<Vector3>();
        private List<uint> _Indices = new List<uint>();
        private Vector3 _Centroide;
        

        public CObjeto(List<CTriangulo> Lista)
        {
            _TrianguloList = Lista;
            
            Juntar_Vertices();
            OptimizarVer();
            VecToVer();
            Definir_Centroide();
        }
        public CObjeto(float[] vertice, uint[] indice)
        {
            _Vertice = vertice;
            _Indice = indice;
            _Indices = new List<uint>(_Indice);
            Definir_Centroide();
        }

        public void Cargar_Buffer()
        {
            _VAO = GL.GenVertexArray();
            GL.BindVertexArray(_VAO);

            _VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, _Vertice.Length * sizeof(float), _Vertice, BufferUsageHint.StaticDraw);

            _EBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _Indice.Length * sizeof(uint), _Indice, BufferUsageHint.StaticDraw);

            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 3 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);

            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.BindVertexArray(0);
        }
        public void Dibujar()
        {
            
            GL.BindVertexArray(_VAO);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
           
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
            GL.DrawElements(PrimitiveType.Triangles, _Indice.Length, DrawElementsType.UnsignedInt, 0);
            GL.BindVertexArray(0);

        }
        public void VecToVer()
        {
            int cant = _Vertices.Count;
            _Vertice = new float[cant * 3];
            for (int i = 0; i < cant; i++)
            {
                _Vertice[i * 3] = _Vertices[i].X;
                _Vertice[i * 3 + 1] = _Vertices[i].Y;
                _Vertice[i * 3 + 2] = _Vertices[i].Z;
            }
            
        }
        public void OptimizarVer()
        {
            int pos;
            uint ind = 0;
            List<Vector3> listemp = new List<Vector3>();
            foreach (Vector3 vector in _Vertices)
            {
                pos = listemp.IndexOf(vector);
                if (pos == -1)
                {
                    listemp.Add(vector);
                    _Indices.Add(ind);
                    ind++;
                }
                else
                {
                    _Indices.Add((uint)pos);
                }
                
            }
            _Vertices = listemp;
            _Indice = _Indices.ToArray();
        }
        public void Mov_Centroide(float X, float Y, float Z)
        {
            float X1 = X - _Centroide.X;
            float Y1 = Y - _Centroide.Y;
            float Z1 = Z - _Centroide.Z;

            for (int i = 0; i < _Vertice.Length; i += 3)
            {
                _Vertice[i] = _Vertice[i] + X1;
                _Vertice[i + 1] = _Vertice[i+1] + Y1;
                _Vertice[i + 2] = _Vertice[i+2] + Z1;
            }
            Definir_Centroide();
            
        }
        private void Definir_Centroide()
        {
            float sumax = 0;
            float sumay = 0;
            float sumaz = 0;
            for (int i = 0;i < _Vertice.Length;i+=3)
            {
                sumax += _Vertice[i];
                sumay += _Vertice[i+1];
                sumaz += _Vertice[i+2];
            }

            int c = _Vertice.Length/3;
            _Centroide.X = sumax/c;
            _Centroide.Y = sumay/c;
            _Centroide.Z = sumaz/c;
            
            
        }
        private void Juntar_Vertices()
        {
            foreach (CTriangulo triangulo in _TrianguloList)
            {
                List <Vector3> vector = triangulo.GetVertices();
                _Vertices.AddRange(vector);
            };
        }
       
        public List<uint> GetIndices() { return _Indices; }
        public List<Vector3> GetVertices(){ return _Vertices; }
        public Vector3 GetCentroide() { return _Centroide; }
        public float[] Getvertice() { return _Vertice; }
        public uint[] Getindice() { return _Indice; }
        
        


    }
}
