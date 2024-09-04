using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using System.IO;

namespace centro_relativo
{
    public class Window : GameWindow
    {                                                                     
        private readonly Escenario1 EscenarioA = new();

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }
        public void Crear_Archivo(String filePath)
        {
            float[] vertice = EscenarioA.GetVertices();
            uint[] indice = EscenarioA.GetIndices();
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine("# Vértices");
                for (int i = 0; i < vertice.Length; i += 3)
                {
                    writer.WriteLine($"v {vertice[i]} {vertice[i + 1]} {vertice[i + 2]}");
                }

                writer.WriteLine(); // Espacio entre secciones

                // Escribir los datos de los índices (caras)
                writer.WriteLine("# Caras");
                for (int i = 0; i < indice.Length; i += 3)
                {
                    
                    writer.WriteLine($"f {indice[i] } {indice[i + 1] } {indice[i + 2] }");
                }
            }
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            EscenarioA.Cargar_Buffer(Size.X,(float)Size.Y);
            string filePath = @"C:\Users\CASA\prog-graf\open\clase poligono\centro relativo\vertices+indices.txt"; 
            Crear_Archivo(filePath);
            
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            

            EscenarioA.Dibujar(e);

            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }

}
