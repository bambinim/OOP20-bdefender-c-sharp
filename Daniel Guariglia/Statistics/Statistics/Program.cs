using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using statisticsOOP.DanielGuariglia;

namespace Statistics
{
    class Program
    {
        static void Main(string[] args)
        {
           string completePath = FileInformation.STATFILE.FilePath + Path.DirectorySeparatorChar + FileInformation.STATFILE.FileName;
            StatisticsWriter writer = new StatisticsWriter();
            writer.GameStarted(MapType.COUNTRYSIDE);
            writer.GameFinished(666);
            writer.SaveStatistics();
            Console.WriteLine("Creato clicca per cancellare");
            Console.ReadLine();
            writer.ResetAllStatistics();
            Console.WriteLine(completePath);
            Console.ReadLine();
        }
    }
}
