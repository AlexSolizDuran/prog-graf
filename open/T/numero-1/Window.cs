
using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;


namespace numero_1
{
    // We can now move around objects. However, how can we move our "camera", or modify our perspective?
    // In this tutorial, I'll show you how to setup a full projection/view/model (PVM) matrix.
    // In addition, we'll make the rectangle rotate over time.
    public class Window : GameWindow
    {
        private readonly float[] _vertices =
        {
            // Position         Texture coordinates
             0.5f,  0.5f, 0.0f,  // top right
             0.5f, -0.0f, 0.0f,  // bottom right
            -0.5f, -0.0f, 0.0f,  // bottom left
            -0.5f,  0.5f, 0.0f,   // top left

             0.5f,  0.5f, -0.3f,  // top right
             0.5f, -0.0f, -0.3f,  // bottom right
            -0.5f, -0.0f, -0.3f,  // bottom left
            -0.5f,  0.5f, -0.3f,   // top left

             0.3f, 0.0f, 0.0f,
            -0.3f, 0.0f, 0.0f,
            -0.3f, -0.6f, 0.0f,
            0.3f, -0.6f, 0.0f,

            0.3f, 0.0f, -0.3f,
            -0.3f, 0.0f, -0.3f,
            -0.3f, -0.6f, -0.3f,
            0.3f, -0.6f, -0.3f




        };

        private readonly uint[] _indices =
        {
            0, 1, 3,
            1, 2, 3,
            4, 5, 7,
            5, 6, 7,
            4, 5, 1,
            0, 1, 4,
            0, 3, 4,
            3, 7 ,4,
            6, 5, 1,
            6, 2, 1,
            6, 7, 3,
            6, 2, 3,

            8, 9, 10,
            8, 11 ,10,
            12, 13, 14,
            12, 15, 14,
            8, 11, 15,
            8, 12, 15,
            9, 13, 14,
            9, 10, 14


        };

        private int _elementBufferObject;

        private int _vertexBufferObject;

        private int _vertexArrayObject;

        private Shader _shader;

        private double _time;
        private Matrix4 _view;
        private Matrix4 _projection;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

             GL.Enable(EnableCap.DepthTest);

            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);

            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            _shader = new Shader("Shaders/shader.vert", "Shaders/shader.frag");
            _shader.Use();

            var vertexLocation = _shader.GetAttribLocation("aPosition");
            GL.EnableVertexAttribArray(vertexLocation);
            GL.VertexAttribPointer(vertexLocation, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            var texCoordLocation = _shader.GetAttribLocation("aTexCoord");
            GL.EnableVertexAttribArray(texCoordLocation);
            GL.VertexAttribPointer(texCoordLocation, 2, VertexAttribPointerType.Float, false, 3 * sizeof(float), 3 * sizeof(float));

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);

            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
         
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            _time += 10.0 * e.Time;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            GL.BindVertexArray(_vertexArrayObject);

            _shader.Use();

            var model = Matrix4.Identity * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(_time));

            _shader.SetMatrix4("model", model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);

            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

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