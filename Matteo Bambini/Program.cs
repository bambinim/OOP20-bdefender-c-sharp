using System;
using OOP20_bdefender.MatteoBambini.Map;
using System.IO;
using System.Collections.Generic;

namespace OOP20_bdefender
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            IMap map = MapLoader.Instance.LoadMap(0);
            Console.WriteLine(String.Format("Path: {0}", map.Path.Count));
            Console.WriteLine(String.Format("Tower Boxes: {0}", map.TowerBoxes.Count));
            Console.WriteLine(map.MapImage == null);
            File.WriteAllBytes("/Users/matteo/Desktop/image.png", map.MapImage);
            */
            // -- LOAD MAP --
            Console.Write("Seleziona operazione:\n" +
                "1. Carica mappa 0 (COUNTRYSIDE)\n" +
                "2. Carica mappa 1 (ICEPLAIN)\n" +
                "3. Esci\n" +
                "> ");
            Map map = null;
            bool exit = false;
            do
            {
                string line = Console.ReadLine();
                try
                {
                    int cmd = Int32.Parse(line);
                    if (cmd >= 1 && cmd <= 3)
                    {
                        switch (cmd)
                        {
                            case 1:
                                map = MapLoader.Instance.LoadMap(0);
                                break;

                            case 2:
                                map = MapLoader.Instance.LoadMap(1);
                                break;

                            case 3:
                                exit = true;
                                break;
                        }
                        break;
                    }
                }
                catch (FormatException){}
                Console.Write("Operazione non valida\n> ");
            } while (true);

            // -- MAP INTERACTIONS --
            while (!exit)
            {
                Console.Clear();
                Console.Write("Seleziona operazione:\n" +
                    "1. Visualizza percorso nemici\n" +
                    "2. Visualizza box torri\n" +
                    "3. Visualizza box torri vuoti\n" +
                    "4. Visualizza box occupati\n" +
                    "5. Posiziona torri nei box\n" +
                    "6. Salva immagine mappa su file\n" +
                    "7. Esci\n" +
                    "> ");
                do
                {
                    try
                    {
                        int cmd = Int32.Parse(Console.ReadLine());
                        if (cmd >= 1 && cmd <= 7)
                        {
                            switch (cmd)
                            {
                                case 1:
                                    foreach (var i in map.Path)
                                    {
                                        Console.WriteLine(String.Format("({0}, {1})", i.X, i.Y));
                                    }
                                    Console.Write("Premi invio per continuare...");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    PrintTowerBoxes(map.TowerBoxes);
                                    break;

                                case 3:
                                    PrintTowerBoxes(map.GetEmptyTowerBoxes());
                                    break;

                                case 4:
                                    PrintTowerBoxes(map.GetOccupiedTowerBoxes());
                                    break;

                                case 5:
                                    var rand = new Random();
                                    int generated = 0;
                                    while (generated < 10 && map.GetEmptyTowerBoxes().Count > 0)
                                    {
                                        int pos = rand.Next(0, map.TowerBoxes.Count);
                                        if (map.TowerBoxes[pos].Tower == null)
                                        {
                                            map.TowerBoxes[pos].Tower = String.Format("Tower {0}",
                                                map.GetOccupiedTowerBoxes().Count);
                                            generated++;
                                        }
                                    }
                                    Console.Write("Operazione completata!\n" +
                                        "Premi invio per continuare...");
                                    Console.ReadLine();
                                    break;

                                case 6:
                                    Console.Write("Percorso immagine (l'estensione deve essere .png): ");
                                    string filePath = Console.ReadLine();
                                    File.WriteAllBytes(filePath, map.MapImage);
                                    break;

                                case 7:
                                    exit = true;
                                    break;
                            }
                            break;
                        }
                    }
                    catch (FormatException) {}
                    Console.Write("Operazione non valida\n> ");
                } while (true);
            }
        }

        private static void PrintTowerBoxes(IList<TowerBox> towerBoxes)
        {
            foreach (var i in towerBoxes)
            {
                Console.WriteLine(String.Format("({0}, {1}) -> Tower: {2}",
                    i.GetCentralCoordinate().X, i.GetCentralCoordinate().Y,
                    i.Tower == null ? "NULL" : i.Tower));
            }
            Console.Write("Premi invio per continuare...");
            Console.ReadLine();
        }
    }
}