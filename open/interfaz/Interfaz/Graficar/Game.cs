
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.GLControl;


namespace Graficar
{
    internal class Game 
    {
        private GLControl _glcontrol;
        public List<CEscenario> EscenarioList { get; private set; }
        private Shader _shader;
        private float Time;
        private float _time;
        private float _timeX;
        private Vector3 trasnlacion = new Vector3(0.0f,0.0f,0.0f);
        private Vector3 escalacion = new Vector3(1.0f,1.0f,1.0f);
        private Vector3 rotacion = new Vector3(0.0f,0.0f,0.0f);
        
        public Game(GLControl gLControl) 
        {
            _glcontrol = gLControl;
            
            EscenarioList = new List<CEscenario>();

            IniciarEscenarios();
        }
        public void IniciarEscenarios()
        {
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
            Vector centro3 = new Vector(0.0f, 0.0f, 0.0f);
            objeto1.Mov_Centro(centro3);
            List<CObjeto> listob = new List<CObjeto>();
            listob.Add(objeto1);
            //primer escenario
            CEscenario escenario1 = new CEscenario(listob);
            Vector centro4 = new Vector(0.0f, 0.0f, 0.0f);
            escenario1.Mov_Centro(centro4);

            EscenarioList.Add(escenario1);

            string lugar = @"..\..\..\vertices.json";
            Metodo.Serializacion(escenario1, lugar);
            //CEscenario escenario2 = Metodo.Deserializacion<CEscenario>(lugar);
            //escenario2.ObjetoList[0].Mov_Centro(new Vector(0.0f, 0.2f, 0.0f));
            //EscenarioList.Add(escenario2);
        }
        public void Nuevocentro(Vector centro)
        {
            EscenarioList[0].Mov_Centro(centro);
            OnLoad();
        }
        public void OnLoad()
        {
            
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            foreach (CEscenario escenario in EscenarioList)
            {
                escenario.Cargar();
            }

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            
        }
        public void OnPaint()
        {
            _timeX = Time;
            _time = 0.05f*Time;

            var transform = Matrix4.Identity;
            transform = transform * Matrix4.CreateRotationX(MathHelper.DegreesToRadians(rotacion.X)* _timeX);
            transform = transform * Matrix4.CreateRotationY(MathHelper.DegreesToRadians(rotacion.Y)* _timeX);
            transform = transform * Matrix4.CreateRotationZ(MathHelper.DegreesToRadians(rotacion.Z)* _timeX);
            transform = transform * Matrix4.CreateTranslation(trasnlacion*_time);
            transform = transform * Matrix4.CreateScale(escalacion);
            
            _shader.SetMatrix4("transform", transform);
            _shader.Use();


            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            foreach (CEscenario escenario in EscenarioList)
            {
                escenario.Dibujar();
            }
            
            _glcontrol.SwapBuffers();
        }
        public void trasnformacion(Vector3 trasl,Vector3 esca,Vector3 rota)
        {
            trasnlacion = trasl;
            escalacion = esca;
            rotacion = rota;
        }
        public void reiniciar()
        {
            Time = 1;
        }
        public void tiempo()
        {
            Time += 1;
        }

        public void OnResize()
        {
            GL.Viewport(0, 0, _glcontrol.Width, _glcontrol.Height);
        }

        
    }
}
