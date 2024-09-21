using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

using Newtonsoft.Json;
using LearnOpenTK.Common;
namespace Graficar
{
    public struct Transform
    {
        public Vector3 trasnlacion;
        public Vector3 escalacion;
        public Vector3 rotacion;

    }
    internal class CObjeto
    {
        [JsonProperty]
        public Dictionary<string,CPartes> Partes {  get; private set; }
        [JsonProperty]
        public Vector Centro {  get; private set; }
        private Shader _shader;
        private Transform[] _transform;

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
        public void transformaciones()
        {
            Matrix4 transform = Matrix4.Identity;
            transform = Matrix4.Identity * Matrix4.CreateTranslation(_transform[0].trasnlacion) * 
                        Matrix4.CreateRotationY(MathHelper.DegreesToRadians( _transform[0].rotacion.Y));
            _shader.SetMatrix4("transform",transform);
            _shader.Use();

        }
        public void transformacion(Vector3 trasl, Vector3 esca, Vector3 rota)
        {
            _transform[0].trasnlacion = trasl;
            _transform[0].escalacion = esca;
            _transform[0].rotacion = rota;
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
            transformaciones();
            foreach (var partes in Partes)
            {
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
