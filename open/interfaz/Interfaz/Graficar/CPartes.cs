using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;

using Newtonsoft.Json;
namespace Graficar
{
    internal class CPartes
    {
        [JsonProperty]
        public List<CPoligono> PoligonoList {  get; private  set; }
        [JsonProperty]
        public Vector Centro { get; private set; }

        private Vector3 translacion { get;  set; } = new Vector3(0, 0, 0);
        private Vector3 escala { get;  set; } = new Vector3(1, 1, 1);
        private Vector3 rotacion { get;  set; } = new Vector3(0, 0, 0);
        
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
        public void SetTransformacion(Vector3 trans,Vector3 esca, Vector3 rota)
        {
            translacion = trans;
            escala = esca;
            rotacion = rota;
        }
        public Matrix4 matrixtra()
        {
            Matrix4 matrix = Matrix4.Identity * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X * Metodo.Time)) *
                                                Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y * Metodo.Time)) * 
                                                Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z * Metodo.Time)) *
                                                Matrix4.CreateTranslation(translacion) *
                                                Matrix4.CreateScale(escala);
            return matrix;
            
        }
        public Vector3 GetTranslacion() {  return translacion; }
        public Vector3 GetEscala() {  return escala; }
        public Vector3 GetRotacion() {  return rotacion; }
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
