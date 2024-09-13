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
        public List<CPoligono> PoligonoList {  get; private  set; }
        [JsonProperty]
        public Vector Centro { get; private set; }
        public CPartes() { }
        
        public CPartes(List<CPoligono> list)
        {
            PoligonoList = list;
            Centro = Metodo.centro(listcen());
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
        public void Mov_Centro(Vector newcentro)
        {
            float X = newcentro.X - Centro.X;
            float Y = newcentro.Y - Centro.Y;
            float Z = newcentro.Z - Centro.Z;
            Vector centro = new Vector(X, Y, Z);
            foreach (CPoligono V in PoligonoList)
            {
                V.Mov_Centro(centro);
            }
            Centro = Metodo.centro(listcen());
        }
        public void SetCentro(Vector vector)
        {
            Centro = vector;
        }
        public List<Vector> listcen()
        {
            List<Vector> list = new List<Vector>();
            foreach(CPoligono v in PoligonoList)
            {
                list.Add(v.Centro);
            }
            return list;
        }
    }
}
