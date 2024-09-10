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
        [JsonProperty]
        public Vector Centro {  get; private set; }
       
        public CObjeto() { }
        public CObjeto(List<CPartes> list)
        {
            PartesList = list;
            Centro = Metodo.centro(listcen());
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
        public void Mov_Centro(Vector newcentro)
        {
            
            foreach (CPartes V in PartesList)
            {
                float X = newcentro.X + V.Centro.X;
                float Y = newcentro.Y + V.Centro.Y;
                float Z = newcentro.Z + V.Centro.Z;
                Vector centro = new Vector(X, Y, Z);
                V.Mov_Centro(centro);
            }
        }
        public void SetCentro(Vector vector)
        {
            Centro = vector;
        }
        public List<Vector> listcen()
        {
            List<Vector> list = new List<Vector>();
            foreach (CPartes v in PartesList)
            {
                list.Add(v.Centro);
            }
            return list;
        }
    }
}
