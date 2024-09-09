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
        
        public List<CEscenario> EscenarioList { get; private set; }
        

        public Game(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) 
            : base(gameWindowSettings, nativeWindowSettings)
        {
            EscenarioList = new List<CEscenario>();
            //List<Vector> list1 = new List<Vector>()
            //{
            //    new(0.0f, 0.0f, 0.0f),
            //    new(0.6f, 0.0f, 0.0f),
            //    new(0.6f, 0.3f, 0.0f),
            //    new(0.0f, 0.3f, 0.0f)
            //};
            //List<Vector> list2 = new List<Vector>()
            //{
            //    new (0.0f,0.0f,-0.3f),
            //    new (0.6f,0.0f,-0.3f),
            //    new (0.6f,0.3f,-0.3f),
            //    new (0.0f,0.3f,-0.3f)
            //};
            //List<Vector> list3 = new List<Vector>()
            //{
            //    new (0.6f,0.0f,0.0f),
            //    new (0.6f,0.0f,-0.3f),
            //    new (0.6f,0.3f,-0.3f),
            //    new (0.6f,0.3f,0.0f)
            //};
            //List<Vector> list4 = new List<Vector>()
            //{
            //    new (0.0f,0.0f,0.0f),
            //    new (0.0f,0.0f,-0.3f),
            //    new (0.0f,0.3f,-0.3f),
            //    new (0.0f,0.3f,0.0f)
            //};
            //List<Vector> list5 = new List<Vector>()
            //{
            //    new (0.0f,0.0f,0.0f),
            //    new (0.3f,0.0f,0.0f),
            //    new (0.3f,0.6f,0.0f),
            //    new (0.0f,0.6f,0.0f)
            //};
            //List<Vector> list6 = new List<Vector>()
            //{
            //    new (0.0f,0.0f,-0.3f),
            //    new (0.3f,0.0f,-0.3f),
            //    new (0.3f,0.6f,-0.3f),
            //    new (0.0f,0.6f,-0.3f)
            //};
            //List<Vector> list7 = new List<Vector>()
            //{
            //    new (0.3f,0.0f,0.0f),
            //    new (0.3f,0.0f,-0.3f),
            //    new (0.3f,0.6f,-0.3f),
            //    new (0.3f,0.6f,0.0f)
            //};
            //List<Vector> list8 = new List<Vector>()
            //{
            //    new (0.0f,0.0f,0.0f),
            //    new (0.0f,0.0f,-0.3f),
            //    new (0.0f,0.3f,-0.3f),
            //    new (0.0f,0.3f,0.0f)
            //};

            //CPoligono pol1 = new CPoligono(list1);
            //CPoligono pol2 = new CPoligono(list2);
            //CPoligono pol3 = new CPoligono(list3);
            //CPoligono pol4 = new CPoligono(list4);

            //CPoligono pol5 = new CPoligono(list5);
            //CPoligono pol6 = new CPoligono(list6);
            //CPoligono pol7 = new CPoligono(list7);
            //CPoligono pol8 = new CPoligono(list8);

            //List<CPoligono> listp1 = new List<CPoligono>();
            //listp1.Add(pol1);
            //listp1.Add(pol2);
            //listp1.Add(pol3);
            //listp1.Add(pol4);
            //List<CPoligono> listp2 = new List<CPoligono>();
            //listp2.Add(pol5);
            //listp2.Add(pol6);
            //listp2.Add(pol7);
            //listp2.Add(pol8);
            ////cubo superior
            //CPartes parte1 = new CPartes(listp1);
            ////cubo inferior
            //CPartes parte2 = new CPartes(listp2);
            //List<CPartes> listpar = new List<CPartes>();
            //listpar.Add(parte1);
            //listpar.Add(parte2);
            ////figura T
            //CObjeto objeto1 = new CObjeto(listpar);
            //List<CObjeto> listob = new List<CObjeto>();
            //listob.Add(objeto1);
            ////primer escenario
            //CEscenario escenario1 = new CEscenario(listob);

            //EscenarioList.Add(escenario1);

            string lugar = @"..\..\..\vertices.json";
            //Metodo.Serializacion(EscenarioList[0], lugar);
            CEscenario escenario2 = Metodo.Deserializacion<CEscenario>(lugar);
            EscenarioList.Add(escenario2);
            
        }
        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            foreach (CEscenario escenario in EscenarioList)
            {
                escenario.Cargar();
            }
            

        }
        protected override void OnRenderFrame (FrameEventArgs e)
        {
            base.OnRenderFrame (e);

            GL.Clear(ClearBufferMask.ColorBufferBit);
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
