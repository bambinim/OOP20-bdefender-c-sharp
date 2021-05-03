using System;
namespace OOP20bdefender.MatteoBambini.Map
{
    public class Coordinates : Pair<Double, Double>
    {
        private static readonly int TILE_SIZE = 32;

        public Coordinates(double x, double y) : base(x, y) { }

        public int GetLeftPixel()
        {
            return (int)Math.Round(base.X * TILE_SIZE);
        }

        public int GetCenterPixelX()
        {
            return (int)Math.Round(base.X * TILE_SIZE) + TILE_SIZE / 2;
        }

        public int GetRightPixel()
        {
            return (int)Math.Round(base.X * TILE_SIZE) + TILE_SIZE;
        }

        public int GetTopPixel()
        {
            return (int)Math.Round(base.Y * TILE_SIZE);
        }

        public int GetCenterPixelY()
        {
            return (int)Math.Round(base.Y * TILE_SIZE) + TILE_SIZE / 2;
        }

        public int GetBottomPixel()
        {
            return (int)Math.Round(base.Y * TILE_SIZE) + TILE_SIZE;
        }
    }
}
