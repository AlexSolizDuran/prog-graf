using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graficar
{
    internal class CObjeto
    {
        public List<CPartes> PartesList {  get; private set; }
        public Vector3 Centro {  get; set; }
        
        public CObjeto(List<CPartes> list)
        {
            PartesList = list;
        }
        public void SetPartes(CPartes elem)
        {
            PartesList.Add(elem);
        }
    }
}
