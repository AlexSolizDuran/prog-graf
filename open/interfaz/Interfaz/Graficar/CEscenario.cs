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
using LearnOpenTK.Common;
namespace Graficar
{
    internal class CEscenario
    {
        [JsonProperty]
        public Dictionary<string,CObjeto> Objetos {  get;private set; }
        [JsonProperty]
        public Vector Centro { get; private set; }
        public CEscenario() { }
        
        public CEscenario(Dictionary<string, CObjeto> list )
        {
            Objetos = list;
            Centro = Metodo.centro(listcen());
        }
        public void SetObjeto(CObjeto elem)
        {
            //Objetos.Add(elem);
           
        }
        public void shader()
        {
            foreach (var objeto in Objetos)
            {
                objeto.Value.shader();
            }

        }
        public void transformaciones()
        {
            foreach (var objeto in Objetos)
            {
                objeto.Value.transformaciones();
            }

        }
        public void transformacion(Vector3 trasl, Vector3 esca, Vector3 rota)
        {
            foreach(var objeto in Objetos)
            {
                objeto.Value.transformacion(trasl, esca, rota);
            }
        }
        public void Cargar()
        {
            foreach (var objeto in Objetos)
            {
                objeto.Value.Cargar();
            }
        }
        public void Dibujar()
        {
            foreach (var objeto in Objetos)
            {
                objeto.Value.Dibujar();
            }
        }
        public void Mov_Centro(Vector newcentro)
        {
            
            foreach (var V in Objetos)
            {
                float X = newcentro.X;//+ Centro.X;
                float Y = newcentro.Y;// + Centro.Y;
                float Z = newcentro.Z;// + Centro.Z;
                Vector centro = new Vector(X, Y, Z);
                V.Value.Mov_Centro(centro);
            }
        }
        public void SetCentro(Vector vector)
        {
            Centro = vector;    
        }
        public List<Vector> listcen()
        {
            List<Vector> list = new List<Vector>();
            foreach (var v in Objetos)
            {
                list.Add(v.Value.Centro);
            }
            return list;
        }
    }
}
