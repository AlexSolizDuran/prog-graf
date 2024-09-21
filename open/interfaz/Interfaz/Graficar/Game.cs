
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.GLControl;
using Newtonsoft.Json;


namespace Graficar
{
    internal class Game 
    {
        private GLControl _glcontrol;
        [JsonProperty]
        
        public Dictionary<string,CEscenario> Escenarios { get; private set; }

        private Vector3 trasnlacion = new Vector3(0.0f,0.0f,0.0f);
        private Vector3 escalacion = new Vector3(1.0f,1.0f,1.0f);
        private Vector3 rotacion = new Vector3(0.0f,0.0f,0.0f);
        
        public Game(GLControl gLControl) 
        {
            _glcontrol = gLControl;

            Escenarios = new Dictionary<string, CEscenario>();

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
            Dictionary<string, CPartes> listpar = new Dictionary<string, CPartes>();
            listpar.Add("Cubo 1", parte1);
            listpar.Add("Cubo 2", parte2);
            //figura T
            CObjeto objeto1 = new CObjeto(listpar);
            Vector centro3 = new Vector(0.0f, 0.0f, 0.0f);
            objeto1.Mov_Centro(centro3);
            Dictionary<string, CObjeto> listob = new Dictionary<string, CObjeto>();
            listob.Add("Figura T",objeto1);
            //primer escenario
            CEscenario escenario1 = new CEscenario(listob);
            Vector centro4 = new Vector(0.0f, 0.0f, 0.0f);
            escenario1.Mov_Centro(centro4);

            Escenarios.Add("Escenario 1",escenario1);
            
            string lugar = @"..\..\..\vertices.json";
            Metodo.Serializacion(escenario1, lugar);
            //CEscenario escenario2 = Metodo.Deserializacion<CEscenario>(lugar);
            //escenario2.Objetos["Figura T"].Mov_Centro(new Vector(0.0f, 0.2f, 0.0f));
            //Escenarios.Add("Escenario 2",escenario2);
        }
        public void Nuevocentro(Vector centro)
        {
            Escenarios["Escenario 1"].Mov_Centro(centro);
            OnLoad();
        }
        public void OnLoad()
        {
            
            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
            GL.Enable(EnableCap.DepthTest);
            foreach (var escenario in Escenarios)
            {
                escenario.Value.Cargar();
                escenario.Value.shader();
            }
            
        }
        public void OnPaint()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (var escenario in Escenarios)
            {
                escenario.Value.transformaciones();
                escenario.Value.Dibujar();
            }
            
            _glcontrol.SwapBuffers();
        }
        public void trasnformacion(Vector3 trasl,Vector3 esca,Vector3 rota)
        {
            foreach (var escenario in Escenarios)
            {
                escenario.Value.transformacion(trasl, esca, rota);
            }
        }
        public void trasnformacionparte(Vector3 trasl, Vector3 esca, Vector3 rota,string parte)
        {
            //Escenarios["Escenario 1"].Objetos["Figura T"].Partes[parte].transformacion(trasl, esca, rota);
        }
       

        public void OnResize()
        {
            GL.Viewport(0, 0, _glcontrol.Width, _glcontrol.Height);
        }

        
    }
}
