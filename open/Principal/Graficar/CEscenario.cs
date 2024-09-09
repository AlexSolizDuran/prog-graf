using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Text.Json;

using Newtonsoft.Json;
namespace Graficar
{
    internal class CEscenario
    {
        [JsonProperty]
        public List<CObjeto> ObjetoList {  get; private set; }
        
        public CEscenario(List<CObjeto> list )
        {
            ObjetoList = list;
        }
        public void SetObjeto(CObjeto elem)
        {
            ObjetoList.Add(elem);
           
        }
        public void Cargar()
        {
            foreach (CObjeto objeto in ObjetoList)
            {
                objeto.Cargar();
            }
        }
        public void Dibujar()
        {
            foreach (CObjeto objeto in ObjetoList)
            {
                objeto.Dibujar();
            }
        }
    }
}
