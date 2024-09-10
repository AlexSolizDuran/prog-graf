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
        public List<CObjeto> ObjetoList {  get;private set; }
        [JsonProperty]
        public Vector Centro { get; private set; }
        public CEscenario() { }
        
        public CEscenario(List<CObjeto> list )
        {
            ObjetoList = list;
            Centro = Metodo.centro(listcen());
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
        public void Mov_Centro(Vector newcentro)
        {
            
            foreach (CObjeto V in ObjetoList)
            {
                float X = newcentro.X + Centro.X;
                float Y = newcentro.Y + Centro.Y;
                float Z = newcentro.Z + Centro.Z;
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
            foreach (CObjeto v in ObjetoList)
            {
                list.Add(v.Centro);
            }
            return list;
        }
    }
}
