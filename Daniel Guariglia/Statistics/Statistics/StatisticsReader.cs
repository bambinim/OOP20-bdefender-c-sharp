using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statisticsOOP.DanielGuariglia
{
    public class StatisticsReader : IStatisticsReader
    {
        private List<Game> gameList;

        private string completeFilePath = FileInformation.STATFILE.FilePath +
            Path.DirectorySeparatorChar +
            FileInformation.STATFILE.FileName;

        private static StatisticsReader instance = null;

        public static StatisticsReader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StatisticsReader();
                }
                return instance;
            }
        }
        private StatisticsReader()
        {
            gameList = new List<Game>();
            this.ReadGameFromFile();
        }

        public void Reload()
        {
            gameList = new List<Game>();
            ReadGameFromFile();
        }
        private void ReadGameFromFile()
        {
            string line;
            if (!File.Exists(completeFilePath))
            {
                var f = File.Create(completeFilePath);
                f.Close();
            }
            StreamReader file = new System.IO.StreamReader(completeFilePath);
            while ((line = file.ReadLine()) != null)
            {
                string[] gameInfo = line.Split(FileInformation.STATFILE.FileSeparator);
                long time = (long) Convert.ToInt32(gameInfo[1]);
                int round = Convert.ToInt32(gameInfo[2]);
                gameList.Add(new Game(FindMapTypeFromName(gameInfo[0]), time, round));
            }

            file.Close();
        }
        private MapType FindMapTypeFromName(string name)
        {
            MapType map = null;
            foreach(MapType m in MapType.Values)
            {
                if (m.Name.Equals(name))
                {
                    map = m;
                }
            }
            return map;
        }

        public int GetHigherstRoundEver()
        {
            Game higherstGame = new Game(MapType.COUNTRYSIDE, 0, 0);

            foreach(Game game in gameList)
            {
                if (game.GetRound > higherstGame.GetRound)
                {
                    higherstGame = game;
                }
            }
            return higherstGame.GetRound;
        }

        public MapType GetMostPlayedMap()
        {
            //default values
            Pair<MapType, int> mostPlayed = new Pair<MapType, int>(MapType.COUNTRYSIDE, 0);
            //fetch most played map
            Dictionary<MapType, int> counterDic = new Dictionary<MapType, int>();
            foreach(MapType type in MapType.Values)
            {
                counterDic.Add(type, 0);
            }
            gameList.ForEach((game) => counterDic[game.GetMap] = counterDic[game.GetMap] + 1);
            foreach (KeyValuePair<MapType, int> kv in counterDic)
            {
                if (kv.Value > mostPlayed.Y)
                {
                    mostPlayed = new Pair<MapType, int>(kv.Key, kv.Value);
                }
            }
            return mostPlayed.X;
        }

        public long GetTotTimePlayed()
        {
            long totTime = 0;
            foreach(Game game in gameList)
            {
                totTime += game.GetTime;
            }
            return totTime;
        }

        private class Game
        {
            public Game(MapType map, long time, int round) => 
                (GetMap, GetTime, GetRound) = (map, time, round);
            public int GetRound { get; private set; }
            public long GetTime { get; private set; }
            public MapType GetMap { get; private set; }

        }
    }
    
}
