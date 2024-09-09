using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Graficar
{
    internal class CPoligono
    {
        public List<Vector3> vertices { get; private set; }
        public CPoligono(List<Vector3> list)
        {
            vertices = list;
        }
        public void SetVector(Vector3 elem)
        {
            vertices.Add(elem);
        }

    }
}
