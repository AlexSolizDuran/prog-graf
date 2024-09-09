using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using OpenTK.Mathematics;

namespace Graficar
{
    internal class Game : GameWindow
    {
        public float[] Vertices { get; private set; } =
        {
            0.0f, 0.0f, 0.0f,
            0.5f, 0.0f, 0.0f,
            0.5f, 0.3f, 0.0f,
            0.0f, 0.3f, 0.0f
        };
        public int VBO {  get; private set; }
        public int VAO { get; private set; }
        public List<CEscenario> EscenarioList { get; private set; }
        

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings)
        {
            EscenarioList = new List<CEscenario>
                {
                    //ESCENARIO 1
                    new CEscenario(new List<CObjeto>
                    {
                        //EL OBJETO T
                        new CObjeto(new List<CPartes>
                        {
                            //PARTE DE ARRIBA - CUBO
                            new CPartes(new List<CPoligono>
                            {
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.5f,0.0f,0.0f),
                                    new (0.5f,0.3f,0.0f),
                                    new (0.0f,0.3f,0.0f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,-0.3f),
                                    new (0.5f,0.0f,-0.3f),
                                    new (0.5f,0.3f,-0.3f),
                                    new (0.0f,0.3f,-0.3f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.5f,0.0f,0.0f),
                                    new (0.5f,0.0f,-0.3f),
                                    new (0.5f,0.3f,-0.3f),
                                    new (0.5f,0.3f,0.0f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,-0.3f),
                                    new (0.0f,0.3f,-0.3f),
                                    new (0.0f,0.3f,0.0f)
                                })
                            })
                            {
                                Centro = new Vector3 (0.0f,0.0f,0.0f)
                            },
                            //PARTE DE ABAJO - CUBO
                            new CPartes(new List<CPoligono>{
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f)
                                }),
                                new CPoligono(new List<Vector3>
                                {
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f),
                                    new (0.0f,0.0f,0.0f)
                                }),
                            })
                            {
                                Centro = new Vector3(0.0f,0.0f,0.0f)
                            }
                        })
                        {
                            Centro = new Vector3 (0.0f,0.0f,0.0f)
                        }

                    })

                };
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

            VBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, Vertices.Length * sizeof(float), Vertices, BufferUsageHint.StaticDraw);
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

        }
        protected override void OnRenderFrame (FrameEventArgs e)
        {
            base.OnRenderFrame (e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.BindVertexArray(VAO);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, Vertices.Length);
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
