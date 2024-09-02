using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace centro_relativo
{
    internal class CObjeto:IPoligono
    {
        private List<CTriangulo> _CcuadradoList = [];
        private int _VBO;
        private int _VBA;
        private int _VCA;
        private float[] _Vertices;
        private uint[] _Indices;
        private float[] _Centroide =new float[3];
        

        public CObjeto(float Y, float X, float Z)
        {
            // Cara frontal (plano Z constante)
            _CcuadradoList.Add(new CTriangulo(
             0.0f, 0.0f, 0.0f,   
             X, 0.0f, 0.0f,      
             X, Y, 0.0f));       

            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, Y, 0.0f,         
                0.0f, Y, 0.0f));   

            // Cara trasera (plano Z constante)
            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, Z,     
                X, 0.0f, Z,        
                X, Y, Z));    

            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, Z,    
                X, Y, Z,           
                0.0f, Y, Z));    

            // Cara superior (plano Y constante)
            _CcuadradoList.Add(new CTriangulo(
                0.0f, Y, 0.0f,  
                X, Y, 0.0f,     
                X, Y, Z));      

            _CcuadradoList.Add(new CTriangulo(
                0.0f, Y, 0.0f,   
                X, Y, Z,        
                0.0f, Y, Z));  

            // Cara inferior (plano Y constante)
            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, 0.0f, 0.0f,     
                X, 0.0f, Z));       

            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                X, 0.0f, Z,          
                0.0f, 0.0f, Z));    

            // Cara derecha (plano X constante)
            _CcuadradoList.Add(new CTriangulo(
                X, 0.0f, 0.0f,    
                X, Y, 0.0f,       
                X, Y, Z));       

            _CcuadradoList.Add(new CTriangulo(
                X, 0.0f, 0.0f,     
                X, Y, Z,          
                X, 0.0f, Z));    

            // Cara izquierda (plano X constante)
            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,    
                0.0f, Y, 0.0f,      
                0.0f, Y, Z));       

            _CcuadradoList.Add(new CTriangulo(
                0.0f, 0.0f, 0.0f,   
                0.0f, Y, Z,        
                0.0f, 0.0f, Z));   

            Juntar_Vertices();
            Juntar_Indices();
            Juntar_Centroide();

        }
        public void Mov_Centroide(float X, float Y, float Z)
        {
            float X1 = X - _Centroide[0];
            float Y1 = Y - _Centroide[1];
            float Z1 = Z - _Centroide[2];
            
            foreach (CTriangulo triangulo in _CcuadradoList)
            {
                int j = 0;
                for (int i = 1;i < 4;i++)
                { 
                    triangulo.SetVertices(0 + j , triangulo.Posvertices(0+j) + X1);
                    triangulo.SetVertices(1 + j , triangulo.Posvertices( 1 + j) + Y1);
                    triangulo.SetVertices(2 + j , triangulo.Posvertices(2 +j) + Z1);
                    j += 3;
                }

            }
            Juntar_Centroide();
            Juntar_Vertices();
            

        }
        private void Juntar_Centroide()
        {   
            
            for (int i = 0; i < 3; i++)
            {
                float suma = 0.0f;
                foreach (CTriangulo cuadrado in _CcuadradoList)
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
            foreach (CTriangulo cuadrado in _CcuadradoList)
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
            foreach (CTriangulo cuadrado in _CcuadradoList)
            {
                listtemp.AddRange(cuadrado.GetVertices());
            }
            _Vertices = listtemp.ToArray();
        }
        public float PosCentroide(int pos) {  return _Centroide[pos]; }
        
        public uint[] GetIndices() { return _Indices; }
        public float[] GetVertices(){ return _Vertices; }
        public float[] GetCentroide() { return _Centroide; }
        
        


    }
}
