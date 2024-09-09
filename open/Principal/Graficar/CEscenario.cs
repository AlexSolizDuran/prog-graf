using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Graficar
{
    internal class CEscenario
    {
        public List<CObjeto> ObjetoList {  get; private set; }
        public CEscenario(List<CObjeto> list )
        {
            ObjetoList = list;
        }
        public void SetObjeto(CObjeto elem)
        {
            ObjetoList.Add(elem);
           
        }
    }
}
