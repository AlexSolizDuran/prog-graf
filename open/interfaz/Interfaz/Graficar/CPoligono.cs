using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.VisualBasic;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System.Text.Json;
using Newtonsoft.Json;
using LearnOpenTK.Common;

namespace Graficar
{
    internal class CPoligono
    {
        [JsonProperty]
        public List<Vector> VectorList { get; private set; }
        [JsonProperty]
        public Vector Centro { get; private set; }
        private float[] Vertices;
        private int VBO;
        private int VAO;
        private Shader _shader;
        private Vector3 trasnlacion = new Vector3(0.0f, 0.0f, 0.0f);
        private Vector3 escalacion = new Vector3(1.0f, 1.0f, 1.0f);
        private Vector3 rotacion = new Vector3(0.0f, 0.0f, 0.0f);
        
        
        public CPoligono() { }
        public CPoligono(List<Vector> list)
        {
            VectorList = list;
            Centro = Metodo.centro(VectorList);
        }
        
        public void SetVector(Vector elem)
        {
            VectorList.Add(elem);
        }
        public void shader()
        {
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();
        }
         public void transformaciones(float Time)
        {
            float _timeX= Time;
            float _time = Time * 0.1f;
            var transform = Matrix4.Identity;
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X) * _timeX);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y) * _timeX);
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z) * _timeX);
            transform = transform * Matrix4.CreateTranslation(trasnlacion * _time);
            transform = transform * Matrix4.CreateScale(escalacion);

            _shader.SetMatrix4("transform", transform);
            _shader.Use();
        }
        public void transformacion(Vector3 trasl, Vector3 esca, Vector3 rota)
        {
            trasnlacion = trasl;
            escalacion = esca;
            rotacion = rota;
        }
        public void Cargar()
        {
            Vertices = Metodo.VectorToVertice(VectorList);
            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.StaticDraw);
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);


            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }
        public void Dibujar()
        {
            GL.BindVertexArray(VAO);
            
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, VectorList.Count);
        }
        public void Mov_Centro(Vector newcentro)
        {
            for (int i = 0; i < VectorList.Count; i++)
            {
                float X1 = VectorList[i].X + newcentro.X;
                float Y1 = VectorList[i].Y + newcentro.Y;
                float Z1 = VectorList[i].Z + newcentro.Z;
                Vector vector = new Vector(X1, Y1, Z1);
                VectorList[i] = vector;
            }
            Centro = Metodo.centro(VectorList);
        }
        public void SetCentro(Vector vector)
        {
            Centro=vector;
        }
        

    }
}
