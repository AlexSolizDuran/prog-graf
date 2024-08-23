using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class CfiguraT
    {  
        private float[] _Vertices ;
        private uint[] _Indices;
            
        public CfiguraT(float X, float Y, float Z)
        {                    //alto,largo,prof   X    Y     Z 
            Ccubo cubo1 = new(0.3f, 0.7f, 0.4f, X, 0.3f + Y, Z);
            Ccubo cubo2 = new(0.6f, 0.3f, 0.4f, X, -0.15f + Y, Z);
            _Indices = cubo1.GetIndices();
            _Vertices = cubo1.GetVertices();
            JuntarInd(cubo1.GetIndices(), cubo2.GetIndices());
            JuntarVer(cubo1.GetVertices(), cubo2.GetVertices());

        }
        private void JuntarVer(float[] ver1, float[] ver2)
        {
            int cant = ver1.Length;
            if (ver1.Length < cant + cant)
            {
                Array.Resize(ref _Vertices, cant + cant);
            }

            for (int i = 0; i < cant; i++)
            {
                _Vertices[cant + i] = ver2[i];
            }

        }
        private void JuntarInd(uint[] ind1, uint[] ind2)
        {
            int cant = ind1.Length;
            if (ind1.Length < cant + cant)
            {
                Array.Resize (ref _Indices, cant + cant);
            }
            for (int i = 0;i < cant; i++)
            {
                _Indices [cant + i] = ind2[i]+8;
            }
        }
        public float[] GetVertices() { return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
    }
}
