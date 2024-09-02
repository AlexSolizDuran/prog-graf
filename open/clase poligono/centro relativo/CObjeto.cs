using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using OpenTK.Mathematics;

namespace centro_relativo
{
    internal class CObjeto
    {
        private List<CTriangulo> _TrianguloList = [];
        private int _VBO;
        private int _VBA;
        private int _VCA;
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
