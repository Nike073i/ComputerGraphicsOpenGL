using System.Drawing;

namespace ComputerGraphicsOpenGL
{
    internal class HouseGraphic
    {
        private readonly Graphic _graphic;

        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;
        public double WidthWall { get; set; } = 5;
        public double HeightWall { get; set; } = 3;
        public double HeightRoof { get; set; } = 2.5;

        public Color ClrRoof { get; set; } = Color.Red;
        public Color ClrWall { get; set; } = Color.SandyBrown;

        public HouseGraphic(Graphic graphic)
        {
            if (graphic == null)
            {
                return;
            }
            _graphic = graphic;
        }

        private void DrawRoof()
        {
            double indentRoof = WidthWall / 2;
            _graphic.DrawTriangle(ClrRoof, new Point3D(X, Y + HeightWall, Z),
                new Point3D(X + indentRoof, Y + HeightRoof + HeightWall, Z + indentRoof),
                new Point3D(X, Y + HeightWall, Z + WidthWall));

            Point3D[] pointsFrontRoof = new[]
            {
                new Point3D(X, Y + HeightWall, Z + WidthWall),
                new Point3D(X + indentRoof, Y + HeightWall + HeightRoof, Z - indentRoof + WidthWall),
                new Point3D(X + WidthWall - indentRoof, Y + HeightWall + HeightRoof, Z - indentRoof + WidthWall),
                new Point3D(X + WidthWall, Y + HeightWall, Z + WidthWall),
            };
            _graphic.DrawPolygon(ClrRoof, pointsFrontRoof);

            _graphic.DrawTriangle(ClrRoof, new Point3D(X + WidthWall, Y + HeightWall, Z + WidthWall),
                new Point3D(X + WidthWall - indentRoof, Y + HeightRoof + HeightWall, Z + WidthWall - indentRoof),
                new Point3D(X + WidthWall, Y + HeightWall, Z));

            Point3D[] pointsBackRoof = new[]
            {
                new Point3D(X, Y + HeightWall, Z),
                new Point3D(X + indentRoof, Y + HeightWall + HeightRoof, Z + indentRoof),
                new Point3D(X + WidthWall - indentRoof, Y + HeightWall + HeightRoof, Z + indentRoof ),
                new Point3D(X + WidthWall, Y + HeightWall, Z),
            };
            _graphic.DrawPolygon(ClrRoof, pointsBackRoof);
        }

        private void DrawWalls()
        {
            Point3D[] pointsFrontWall = new[]
            {
                new Point3D(X, Y, Z + WidthWall),
                new Point3D(X, Y + HeightWall, Z + WidthWall),
                new Point3D(X + WidthWall, Y + HeightWall, Z + WidthWall),
                new Point3D(X + WidthWall, Y, Z + WidthWall)
            };
            _graphic.DrawPolygon(ClrWall, pointsFrontWall);

            Point3D[] pointsBackWall = new[]
            {
                new Point3D(X, Y, Z),
                new Point3D(X, Y + HeightWall, Z),
                new Point3D(X + WidthWall, Y + HeightWall, Z),
                new Point3D(X + WidthWall, Y, Z)
            };
            _graphic.DrawPolygon(ClrWall, pointsBackWall);

            Point3D[] pointsLeftWall = new[]
            {
                new Point3D(X, Y, Z),
                new Point3D(X, Y + HeightWall, Z),
                new Point3D(X, Y + HeightWall, Z + WidthWall),
                new Point3D(X, Y, Z + WidthWall)
            };
            _graphic.DrawPolygon(ClrWall, pointsLeftWall);

            Point3D[] pointsRightWall = new[]
            {
                new Point3D(X + WidthWall, Y, Z),
                new Point3D(X + WidthWall, Y + HeightWall, Z),
                new Point3D(X + WidthWall, Y + HeightWall, Z + WidthWall),
                new Point3D(X + WidthWall, Y, Z + WidthWall)
            };
            _graphic.DrawPolygon(ClrWall, pointsRightWall);
        }

        public void Draw()
        {
            DrawWalls();
            DrawRoof();
        }
    }
}
