using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace statisticsOOP.DanielGuariglia
{
    public class StatisticsWriter : IStatisticsWriter
    {
        private Stopwatch watch = null;
        private MapType mapPlayed;
        private long timePlayed;
        private int round;
        private bool isStarted = false;
        private bool isFinished = false;
        public void GameStarted(MapType map)
        {
            if (isStarted)
            {
                throw new InvalidOperationException("Already started or finished");
            }
            this.isStarted = true;
            this.watch = System.Diagnostics.Stopwatch.StartNew();
            this.mapPlayed = map;

        }
        public void GameFinished(int round)
        {
            if(!isStarted || isFinished)
            {
                throw new InvalidOperationException("Missing start or already finished");
            }
            this.isFinished = true;
            this.round = round;
            this.watch.Stop();
            this.timePlayed = this.watch.ElapsedMilliseconds;

        }
        public void ResetAllStatistics()
        {
            File.WriteAllText(FileInformation.STATFILE.FilePath +
                Path.DirectorySeparatorChar +
                FileInformation.STATFILE.FileName, String.Empty);
            
        }
        public void SaveStatistics()
        {
            char sep = FileInformation.STATFILE.FileSeparator;
            if(!this.isStarted || !this.isFinished)
            {
                throw new InvalidOperationException("Missing start or stop");
            }
            File.AppendAllText(FileInformation.STATFILE.FilePath + Path.DirectorySeparatorChar + FileInformation.STATFILE.FileName,
                this.mapPlayed.Name + sep + this.timePlayed + sep + this.round + "\n"); 
        }
    }
}
