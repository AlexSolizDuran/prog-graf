using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class Ccubo:IPoligono
    {
        private readonly float[] _vertices;
        private uint[] _indices;
        private float[] _Centroide;
       
        public Ccubo(float X, float Y , float Z)
        {   
                        
        }

        
        public uint[] GetIndices() { return _indices; }
        public float[] GetVertices(){ return _vertices; }
        public float[] GetCentroide() { return _Centroide; }
        
        


    }
}
