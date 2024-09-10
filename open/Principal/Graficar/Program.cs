using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace Graficar
{
    public static class Program
    {
        private static void Main()
        {
            var NWS = new NativeWindowSettings()
            {
                ClientSize = new Vector2i(800, 800),
                Title = "Graficar",
                Flags = ContextFlags.ForwardCompatible,
            };
            using (var Game = new Game(GameWindowSettings.Default, NWS))
            {
                Game.Run();
            }
                Console.WriteLine("Hello, World!");
        }
        
    }

    
}

