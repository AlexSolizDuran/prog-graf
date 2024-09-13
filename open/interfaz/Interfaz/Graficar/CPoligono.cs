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

namespace Graficar
{
    internal class CPoligono
    {
        [JsonProperty]
        public List<Vector> VectorList { get; private set; }
        [JsonProperty]
        public Vector Centro { get; private set ; }
        private float[] Vertices;
        private int VBO;
        private int VAO;
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
