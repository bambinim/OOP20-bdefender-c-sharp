using System;
using System.IO;
using Gtk;
using OOP20bdefender.MatteoBambini.Map;

namespace OOP20bdefender
{
    class App
    {
        public static readonly int APP_WIDTH = 1280;
        public static readonly int APP_HEIGHT = 736;

        public static void Main(string[] args)
        {
            Application.Init();
            MainWindow win = new MainWindow();
            win.Show();
            win.WidthRequest = APP_WIDTH;
            win.HeightRequest = APP_HEIGHT;
            Map map = MapLoader.Instance.LoadMap(0);
            Console.WriteLine(String.Format("Path length: {0}", map.Path.Count));
            Console.WriteLine(String.Format("TowerBoxes length: {0}", map.TowerBoxes.Count));
            foreach (var i in Directory.EnumerateFileSystemEntries("./"))
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(Path.GetFullPath("./"));
            Application.Run();
        }
    }
}
