using System;
using Gtk;
using System.IO;
using System.Collections.Generic;

namespace OOP20bdefender.MatteoBambini.Map
{
    public class MapLoader
    {
        private static readonly MapLoader instance = new MapLoader();

        public static MapLoader Instance
        {
            get { return instance; }
        }

        public Map LoadMap(int map)
        {
            return new Map(this.LoadMapImage(String.Format("resources/maps/{0}/map.png", map)),
                this.LoadPath(String.Format("resources/maps/{0}/path.txt", map)),
                this.LoadTowerBoxes(String.Format("resources/maps/{0}/towerboxes.txt", map)));
        }

        private Image LoadMapImage(String imageFile)
        {
            try
            {
                return Image.LoadFromResource(imageFile);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private IList<Coordinates> LoadPath(String filePath)
        {
            IList<Coordinates> path = new List<Coordinates>();
            try
            {
                StreamReader fileReader = new StreamReader(File.OpenRead(filePath));
                String line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    path.Add(this.ParseCoordinates(line));
                }
                fileReader.Close();
            }
            catch (IOException)
            {
                path = new List<Coordinates>();
            }
            return path;
        }

        private IList<TowerBox> LoadTowerBoxes(String towerBoxesFile)
        {
            IList<TowerBox> towerBoxes = new List<TowerBox>();
            try
            {
                StreamReader fileReader = new StreamReader(File.OpenRead(towerBoxesFile));
                String line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    String[] tmp = line.Split('-');
                    if (tmp.Length > 1)
                    {
                        Coordinates start = this.ParseCoordinates(tmp[0]);
                        Coordinates end = this.ParseCoordinates(tmp[1]);
                        for (double i = start.Y; i < end.Y; i += 2)
                        {
                            for (double j = start.X; j < end.X; j += 2)
                            {
                                towerBoxes.Add(new TowerBox(new Coordinates(j, i)));
                            }
                        }
                    }
                    else
                    {
                        towerBoxes.Add(new TowerBox(this.ParseCoordinates(tmp[0])));
                    }
                }
            }
            catch (IOException)
            {
                towerBoxes = new List<TowerBox>();
            }
            return towerBoxes;
        }

        private Coordinates ParseCoordinates(String line)
        {
            String[] tmp = line.Split('|');
            return new Coordinates(Double.Parse(tmp[0]), Double.Parse(tmp[1]));
        }
    }
}
