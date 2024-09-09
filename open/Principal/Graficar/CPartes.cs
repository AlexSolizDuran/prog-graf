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
    internal class CPartes
    {
        [JsonProperty]
        public List<CPoligono> PoligonoList {  get; private set; }
        public Vector Centro {  get; set; }
        
        public CPartes(List<CPoligono> list)
        {
            PoligonoList = list;
        }
        public void SetPoligono(CPoligono elem)
        {
            PoligonoList.Add(elem);
        }
        public void Cargar()
        {
            foreach (CPoligono poligono in PoligonoList)
            {
                poligono.Cargar();
            }
        }
        public void Dibujar()
        {
            foreach (CPoligono poligono in PoligonoList)
            {
                poligono.Dibujar();
            }
        }
    }
}
