using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;



namespace Graficar
{
    internal class CPartes
    {
        public List<CPoligono> PoligonoList {  get; private set; }
        public Vector3 Centro {  get; set; }
        public CPartes(List<CPoligono> list)
        {
            PoligonoList = list;
        }
        public void SetPoligono(CPoligono elem)
        {
            PoligonoList.Add(elem);
        }
    }
}
