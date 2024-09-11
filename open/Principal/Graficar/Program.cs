using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using System.Drawing;
using System.Windows;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Graficar
{
    public static class Program
    {
        private static void Main()
        {
            var NWS = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800,600),
                //WindowState = WindowState.Maximized,
                Title = "Graficar",
                Flags = ContextFlags.ForwardCompatible,
            };
            using (var Game = new Game(GameWindowSettings.Default, NWS))
            {
                Game.Run();
            }
                
        }
        
    }

    
}

