using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Newtonsoft.Json;
using LearnOpenTK.Common;
using System.Security.Cryptography.Xml;
namespace Graficar
{
    
    internal class CObjeto
    {
        [JsonProperty]
        public Dictionary<string,CPartes> Partes {  get; private set; }
        [JsonProperty]
        public Vector Centro {  get; private set; }
        private Shader _shader;
        

        public CObjeto() { }
        public CObjeto(Dictionary<string, CPartes> list)
        {
            Partes = list;
            Centro = Metodo.centro(listcen());
        }
        public void SetPartes(CPartes elem)
        {
            //Partes.Add(elem);
        }
        
        public void shader()
        {
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();
        }
        
        public void transformacion(Vector3 trasl, Vector3 esca, Vector3 rota)
        {
            foreach (var par in Partes)
            {
                par.Value.SetTransformacion(trasl, esca, rota);
            }
        }
        public void Cargar ()
        {
            foreach (var partes in Partes)
            {
                partes.Value.Cargar();
            }
        }
        public void Dibujar()
        {
            _shader.Use();
            
            foreach (var partes in Partes)
            {
                _shader.SetMatrix4("transform", partes.Value.matrixtra());
                _shader.Use();

                partes.Value.Dibujar();
            }
        }
        public void Mov_Centro(Vector newcentro)
        {
            foreach (var V in Partes)
            {
                float X = newcentro.X + V.Value.Centro.X;
                float Y = newcentro.Y + V.Value.Centro.Y;
                float Z = newcentro.Z + V.Value.Centro.Z;
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
            foreach (var v in Partes)
            {
                list.Add(v.Value.Centro);
            }
            return list;
        }
    }
}
