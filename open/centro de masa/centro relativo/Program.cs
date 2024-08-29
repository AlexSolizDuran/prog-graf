
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;


namespace centro_relativo 
{
    public static class  Program
    {
        private static void Main()
        {
            

            var NWS = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(1200,600),
                Title = "ventana 1",
                Flags = ContextFlags.ForwardCompatible,
            };
            using (var Window = new Window(GameWindowSettings.Default, NWS))
            {
                Window.Run();
            }
           
        }
            
    }


}