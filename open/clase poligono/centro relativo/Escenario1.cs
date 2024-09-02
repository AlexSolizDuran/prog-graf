using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace centro_relativo
{
    internal class Escenario1 
    {   
        private CfiguraT figura1 = new CfiguraT();
        private float[] _Vertices;
        private uint[] _Indices;
        public Escenario1()
        {
            figura1.Mover_Centroide(-0.2f, -0.5f, 0.0f);
            VecToVert();
            _Indices = figura1.GetIndices().ToArray();
            

        }
        private void VecToVert()
        {
            int cant = figura1.GetVertices().Count;
            _Vertices = new float [cant*3];
            for (int i = 0; i < cant; i++) 
            {
                _Vertices[i * 3] = figura1.GetVertices()[i].X;
                _Vertices[i * 3 + 1] = figura1.GetVertices()[i].Y;
                _Vertices[i * 3 + 2] = figura1.GetVertices()[i].Z;
            }
        }
        public float[] GetVertices() {  return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
    }
}
