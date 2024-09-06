using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace centro_relativo
{
    internal class Escenario1 
    {   
        private CfiguraT figura1 = new CfiguraT();
        private float[] _Vertices;
        private uint[] _Indices;
        private List<IDibujable> _Dibujable= new List<IDibujable>();

        private Shader _shader;

        private double _time;
        private Matrix4 _view;
        private Matrix4 _projection;
        public Escenario1()
        {
            _Dibujable.Add(new CfiguraT());
            _Dibujable.Add(new CCubo(0.5f, 0.5f, 0.5f));
            _Dibujable[0].Mov_Centroide(-0.5f, 0.2f, 0.0f);
            _Dibujable[1].Mov_Centroide(0.5f, 0.2f, 0.0f);
            VecToVert();
            Juntar_Indices();


        }
        
        private void Juntar_Indices()
        {
            List<uint> listemp = new List<uint>();
            uint max = listemp.Any() ? listemp.Max() : 0;
            foreach (IDibujable dibujo in _Dibujable)
            {
                List<uint> indices = dibujo.GetIndices();
                foreach (uint indice in indices)
                {
                    listemp.Add(indice + max);
                }
                
                max = listemp.Max() + 1;
            }
            _Indices = listemp.ToArray();
        }
        public void Cargar_Buffer(float X, float Y)
        {
            foreach (IDibujable dibujo in _Dibujable)
            {
                dibujo.Cargar_Buffer();
            }
            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            var texCoordLocation = _shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 3 * sizeof(float));

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);

            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), X / Y, 0.1f, 100.0f);
        }
        public void Dibujar(FrameEventArgs e)
        {
            _time += 10.0 * e.Time;

            _shader.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);
            foreach (IDibujable dibujo in _Dibujable)
            {
                dibujo.Dibujar();
            }
        }
        private void VecToVert()
        {
            List<float> listemp = new List<float>();
            foreach (IDibujable dibujo in _Dibujable)
            {
                List<Vector3> vectemp = dibujo.GetVertices();
                foreach (Vector3 vec in vectemp)
                {
                    listemp.Add(vec.X);
                    listemp.Add(vec.Y);
                    listemp.Add(vec.Z);
                }
            }
            _Vertices = listemp.ToArray();
        }
        public float[] GetVertices() {  return _Vertices; }
        public uint[] GetIndices() { return _Indices; }
    }
}
