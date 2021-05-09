
using System;
using System.IO;
using statisticsOOP.DanielGuariglia;
using Xunit;

namespace StatisticsTest
{
       
    public class StatWriterReaderTest
    {

        private string completeFilePath = FileInformation.STATFILE.FilePath +
            Path.DirectorySeparatorChar +
            FileInformation.STATFILE.FileName;

//Reader
        [Fact]
        private void ReaderTest()
        {
            IStatisticsWriter writer;
            //reset
            writer = new StatisticsWriter();
            writer.ResetAllStatistics();

            //Default values 
            IStatisticsReader reader = StatisticsReader.Instance;
            Assert.Equal(0, reader.GetHigherstRoundEver());
            Assert.Equal(MapType.COUNTRYSIDE, reader.GetMostPlayedMap());
            Assert.Equal(0, reader.GetTotTimePlayed());

            
        }

        [Fact]
        public void StatisticTest()
        {
            IStatisticsWriter writer;
            IStatisticsReader reader = StatisticsReader.Instance;
            //reset
            writer = new StatisticsWriter();
            writer.ResetAllStatistics();


            // load 10 values
            for (int i = 0; i < 10; i++)
            {
                writer = new StatisticsWriter();
                writer.GameStarted(MapType.ICEPLAIN);
                writer.GameFinished(i);
                writer.SaveStatistics();
            }
            reader.Reload();

            //test most played map
            Assert.Equal(MapType.ICEPLAIN, reader.GetMostPlayedMap());
            //test higherst round
            Assert.Equal(9, reader.GetHigherstRoundEver());


        }

//Writer
        [Fact]
        public void WriterTest()
        {
            //test write value
            Assert.True(WriteValuesTest());
        }
        private bool WriteValuesTest()
        {
            //writeValueTest
            IStatisticsWriter writer = new StatisticsWriter();
            writer.GameStarted(MapType.COUNTRYSIDE);
            writer.GameFinished(12345);
            writer.SaveStatistics();
            //read all value 

            StreamReader file = new System.IO.StreamReader(completeFilePath);
            string line, savedString = null;
            while ((line = file.ReadLine()) != null)
            {
                savedString = line;
            }
            string[] gameInfo = savedString.Split(FileInformation.STATFILE.FileSeparator);
            //test correct map
            if (MapType.COUNTRYSIDE.Name != gameInfo[0])
            {
                return false;
            }

            //test corret round
            int round = Convert.ToInt32(gameInfo[2]);
            if (12345 != round)
            {
                return false;
            }

            file.Close();
            return true;
        }

        [Fact]
        public void WriterExceptionTest()
        {
            //finish without start
            IStatisticsWriter writer = new StatisticsWriter();
            Assert.Throws<InvalidOperationException>(() => writer.GameFinished(0));

            //2 time start
            writer = new StatisticsWriter();
            Assert.Throws<InvalidOperationException>(() => {
                writer.GameStarted(MapType.COUNTRYSIDE);
                writer.GameStarted(MapType.COUNTRYSIDE);
            });

            //2 time finish
            writer = new StatisticsWriter();
            Assert.Throws<InvalidOperationException>(() => {
                writer.GameStarted(MapType.COUNTRYSIDE);
                writer.GameFinished(0);
                writer.GameFinished(0);
            });

            //missing value
            writer = new StatisticsWriter();
            Assert.Throws<InvalidOperationException>(() => {
                writer.GameStarted(MapType.COUNTRYSIDE);
                writer.SaveStatistics();
            });

        }
    }
}
