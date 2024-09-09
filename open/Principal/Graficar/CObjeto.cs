using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Newtonsoft.Json;
namespace Graficar
{
    internal class CObjeto
    {
        [JsonProperty]
        public List<CPartes> PartesList {  get; private set; }
        public Vector Centro {  get; set; }
       

        public CObjeto(List<CPartes> list)
        {
            PartesList = list;
        }
        public void SetPartes(CPartes elem)
        {
            PartesList.Add(elem);
        }
        public void Cargar ()
        {
            foreach (CPartes partes in PartesList)
            {
                partes.Cargar();
            }
        }
        public void Dibujar()
        {
            foreach (CPartes partes in PartesList)
            {
                partes.Dibujar();
            }
        }
    }
}
