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
using ImGuiNET;

namespace Graficar
{
    internal class Game : GameWindow
    {
        
        public List<CEscenario> EscenarioList { get; private set; }
        private int _elementBufferObject;

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        private Shader _shader;

        private Texture _texture;

        private Texture _texture2;
        private double _time;
        private Matrix4 _view;
        private Matrix4 _projection;


        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings)
        {
            EscenarioList = new List<CEscenario>();
            List<Vector> list1 = new List<Vector>()
            {
                new(0.0f, 0.0f, 0.0f),
                new(0.6f, 0.0f, 0.0f),
                new(0.6f, 0.3f, 0.0f),
                new(0.0f, 0.3f, 0.0f)
            };
            List<Vector> list2 = new List<Vector>()
            {
                new (0.0f,0.0f,-0.3f),
                new (0.6f,0.0f,-0.3f),
                new (0.6f,0.3f,-0.3f),
                new (0.0f,0.3f,-0.3f)
            };
            List<Vector> list3 = new List<Vector>()
            {
                new (0.6f,0.0f,0.0f),
                new (0.6f,0.0f,-0.3f),
                new (0.6f,0.3f,-0.3f),
                new (0.6f,0.3f,0.0f)
            };
            List<Vector> list4 = new List<Vector>()
            {
                new (0.0f,0.0f,0.0f),
                new (0.0f,0.0f,-0.3f),
                new (0.0f,0.3f,-0.3f),
                new (0.0f,0.3f,0.0f)
            };
            List<Vector> list5 = new List<Vector>()
            {
                new (0.0f,0.3f,0.0f),
                new (0.6f,0.3f,0.0f),
                new (0.6f,0.3f,-0.3f),
                new (0.0f,0.3f,-0.3f)
            };
            List<Vector> list6 = new List<Vector>()
            {
                new (0.0f,0.0f,0.0f),
                new (0.6f,0.0f,0.0f),
                new (0.6f,0.0f,-0.3f),
                new (0.0f,0.0f,-0.3f)
            };
            List<Vector> list7 = new List<Vector>()
            {
                new (0.0f,0.0f,0.0f),
                new (0.3f,0.0f,0.0f),
                new (0.3f,0.6f,0.0f),
                new (0.0f,0.6f,0.0f)
            };
            List<Vector> list8 = new List<Vector>()
            {
                new (0.0f,0.0f,-0.3f),
                new (0.3f,0.0f,-0.3f),
                new (0.3f,0.6f,-0.3f),
                new (0.0f,0.6f,-0.3f)
            };
            List<Vector> list9 = new List<Vector>()
            {
                new (0.3f,0.0f,0.0f),
                new (0.3f,0.0f,-0.3f),
                new (0.3f,0.6f,-0.3f),
                new (0.3f,0.6f,0.0f)
            };
            List<Vector> list10 = new List<Vector>()
            {
                new (0.0f,0.0f,0.0f),
                new (0.0f,0.0f,-0.3f),
                new (0.0f,0.6f,-0.3f),
                new (0.0f,0.6f,0.0f)
            };
            List<Vector> list11 = new List<Vector>()
            {
                new (0.0f,0.6f,0.0f),
                new (0.3f,0.6f,0.0f),
                new (0.3f,0.6f,-0.3f),
                new (0.0f,0.6f,-0.3f)
            };
            List<Vector> list12 = new List<Vector>()
            {
                new (0.0f,0.0f,0.0f),
                new (0.3f,0.0f,0.0f),
                new (0.3f,0.0f,-0.3f),
                new (0.0f,0.0f,-0.3f)
            };

            CPoligono pol1 = new CPoligono(list1);
            CPoligono pol2 = new CPoligono(list2);
            CPoligono pol3 = new CPoligono(list3);
            CPoligono pol4 = new CPoligono(list4);
            CPoligono pol5 = new CPoligono(list5);
            CPoligono pol6 = new CPoligono(list6);

            CPoligono pol7 = new CPoligono(list7);
            CPoligono pol8 = new CPoligono(list8);
            CPoligono pol9 = new CPoligono(list9);
            CPoligono pol10 = new CPoligono(list10);
            CPoligono pol11 = new CPoligono(list11);
            CPoligono pol12 = new CPoligono(list12);

            List<CPoligono> listp1 = new List<CPoligono>();
            listp1.Add(pol1);
            listp1.Add(pol2);
            listp1.Add(pol3);
            listp1.Add(pol4);
            listp1.Add(pol5);
            listp1.Add(pol6);
            List<CPoligono> listp2 = new List<CPoligono>();
            listp2.Add(pol7);
            listp2.Add(pol8);
            listp2.Add(pol9);
            listp2.Add(pol10);
            listp2.Add(pol11);
            listp2.Add(pol12);

            //cubo superior
            CPartes parte1 = new CPartes(listp1);
            Vector centro1 = new Vector(0.0f, 0.0f, 0.0f);
            Vector centro2 = new Vector(0.0f, 0.45f, 0.0f);

            parte1.Mov_Centro(centro2);
            //cubo inferior
            CPartes parte2 = new CPartes(listp2);
            parte2.Mov_Centro(centro1);
            List<CPartes> listpar = new List<CPartes>();
            listpar.Add(parte1);
            listpar.Add(parte2);
            //figura T
            CObjeto objeto1 = new CObjeto(listpar);
            Vector centro3 = new Vector(0.5f, 0.5f, 0.0f);
            objeto1.Mov_Centro(centro3);
            List<CObjeto> listob = new List<CObjeto>();
            listob.Add(objeto1);
            //primer escenario
            CEscenario escenario1 = new CEscenario(listob);
            Vector centro4 = new Vector(-0.5f, -0.5f, 0.0f);
            escenario1.Mov_Centro(centro4);

            EscenarioList.Add(escenario1);

            string lugar = @"..\..\..\vertices.json";
            Metodo.Serializacion(escenario1, lugar);
            //CEscenario escenario2 = Metodo.Deserializacion<CEscenario>(lugar);
            //escenario2.ObjetoList[0].Mov_Centro(new Vector(0.0f, 0.2f, 0.0f));
            //EscenarioList.Add(escenario2);
            
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            //GL.Enable(EnableCap.DepthTest);
            foreach (CEscenario escenario in EscenarioList)
            {
                escenario.Cargar();
            }

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
       
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);

        }
        protected override void OnRenderFrame (FrameEventArgs e)
        {
            base.OnRenderFrame (e);
            _time += 10.0 * e.Time;
            
            _shader.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));
            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);

            GL.Clear(ClearBufferMask.ColorBufferBit);
            ImGui.NewFrame();
            ImGui.Begin("Example Window");
            if (ImGui.Button("Click Me"))
            {
                // Acción cuando se hace clic en el botón
            }
            ImGui.End();
            ImGui.Render();
            foreach (CEscenario escenario in EscenarioList)
            {
                escenario.Dibujar();
            }
            
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
