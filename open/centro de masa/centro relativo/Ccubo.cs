using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class Ccubo
    {
        private readonly float[] _vertices = new float[24];
        private uint[] _indices =
        {
            //frente
            0, 1, 2,
            0, 3, 2,
            // atras
            4, 5, 6,
            4, 7, 6,
            //izquierda
            4, 0, 3,
            4, 7, 3,
            //derecha
            5, 1, 2,
            5, 6, 2,
            //abajo
            3, 2, 6,
            3, 7 ,6,
            //arriba
            0, 1, 5,
            0, 4, 5,
            
        };
       
        public Ccubo(float largo,float alto, float profu,float X,float Y,float Z)
        {   //frente
            _vertices[0] = (-alto / 2)+ X ; _vertices[1]  =  (largo / 2) + Y; _vertices[2]  = (profu / 2) + Z;    //0
            _vertices[3] = (alto / 2)+ X; _vertices[4]  =  (largo / 2) + Y; _vertices[5]  = (profu / 2) + Z;    //1
            _vertices[6] = (alto / 2) + X; _vertices[7]  = (-largo / 2) + Y; _vertices[8]  = (profu / 2) + Z;    //2 
            _vertices[9] = (-alto / 2)+ X; _vertices[10] = (-largo / 2) + Y;  _vertices[11] = (profu / 2) + Z;    //3
            //atras
            _vertices[12] = (-alto / 2) + X; _vertices[13] =  (largo / 2) + Y;  _vertices[14] = (-profu / 2) + Z; //4
            _vertices[15] = (alto / 2) + X; _vertices[16] = (largo / 2) + Y;  _vertices[17] = (-profu / 2) + Z; //5
            _vertices[18] = (alto / 2) + X; _vertices[19] = (-largo / 2) + Y;  _vertices[20] = (-profu / 2) + Z; //6
            _vertices[21] = (-alto / 2) + X; _vertices[22] = (-largo / 2) + Y;  _vertices[23] = (-profu / 2) + Z; //7

            //Centro(-0.1f,0.1f,0.0f);
        }

        //  X= largo , Y=alto, Z= profundidad
        private void Centro(float X, float Y, float Z)
        {
            //frente
            _vertices[0] += Y;   _vertices[1] += X ;   _vertices[2] += Z ;    //0
            _vertices[3] += Y;    _vertices[4] += X;    _vertices[5] += Z ;    //1
            _vertices[6] += Y;    _vertices[7] += X;   _vertices[8] += Z ;    //2 
            _vertices[9] += Y;   _vertices[10] += X;  _vertices[11] += Z ;   //3
            //atras
            _vertices[12] += Y;  _vertices[13] += X ;  _vertices[14] += Z ; //4
            _vertices[15] += Y ;  _vertices[16] += X ;  _vertices[17] += Z ; //5
            _vertices[18] += Y ;  _vertices[19] += X ; _vertices[20] += Z ; //6
            _vertices[21] += Y;  _vertices[22] += X ; _vertices[23] += Z ; //7
        }
        public uint[] GetIndices()
            { return _indices; }
         
        public float[] GetVertices()
            { return _vertices; }   
        
        


    }
}
