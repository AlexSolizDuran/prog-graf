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
        

        public CObjeto(float Y, float X, float Z)
        {
            // Cara frontal (plano Z constante)
            _TrianguloList.Add(new CTriangulo(
             0.0f, 0.0f, 0.0f,   
             X, 0.0f, 0.0f,      
             X, Y, 0.0f));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, Y, 0.0f,         
                0.0f, Y, 0.0f));

            // Cara trasera (plano Z constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, Z,     
                X, 0.0f, Z,        
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, Z,    
                X, Y, Z,           
                0.0f, Y, Z));

            // Cara superior (plano Y constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, Y, 0.0f,  
                X, Y, 0.0f,     
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, Y, 0.0f,   
                X, Y, Z,        
                0.0f, Y, Z));

            // Cara inferior (plano Y constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, 0.0f, 0.0f,     
                X, 0.0f, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, 0.0f, Z,          
                0.0f, 0.0f, Z));

            // Cara derecha (plano X constante)
            _TrianguloList.Add(new CTriangulo(
                X, 0.0f, 0.0f,    
                X, Y, 0.0f,       
                X, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                X, 0.0f, 0.0f,     
                X, Y, Z,          
                X, 0.0f, Z));

            // Cara izquierda (plano X constante)
            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,    
                0.0f, Y, 0.0f,      
                0.0f, Y, Z));

            _TrianguloList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                0.0f, Y, Z,        
                0.0f, 0.0f, Z));   
            
            Juntar_Vertices();
            OptimizarVer();
            Definir_Centroide();
            VecToVer();

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
            float X1 = X - _Centroide[0];
            float Y1 = Y - _Centroide[1];
            float Z1 = Z - _Centroide[2];

            for (int i = 0; i < _Vertices.Count; i++) 
            {
                Vector3 vector = _Vertices[i];
                Vector3 vectorN = new (vector.X +X1,vector.Y+Y1,vector.Z+ Z1);
                _Vertices[i] = vectorN;
            }
            Definir_Centroide();
            VecToVer();
        }
        private void Definir_Centroide()
        {
            float sumax = 0;
            float sumay = 0;
            float sumaz = 0;
            foreach (Vector3 triangulo in _Vertices)
            {
                sumax += triangulo.X;
                sumay += triangulo.Y;
                sumaz += triangulo.Z;
            }
            int c = _Vertices.Count;
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
        
        


    }
}
