using System.Drawing;

namespace ComputerGraphicsOpenGL
{
    internal class FigureGraphic
    {
        private readonly Graphic _graphic;

        #region properties
        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;

        public Color ClrSide1 { get; set; } = Color.Red;
        public Color ClrSide2 { get; set; } = Color.DarkRed;
        public Color ClrSide3 { get; set; } = Color.IndianRed;
        public Color ClrSide4 { get; set; } = Color.MediumVioletRed;
        public Color ClrSide5 { get; set; } = Color.OrangeRed;
        public Color ClrSide6 { get; set; } = Color.PaleVioletRed;
        public Color ClrSide7 { get; set; } = Color.Orange;
        public Color ClrSide8 { get; set;} = Color.DarkGreen;
        public Color ClrSide9 { get; set; } = Color.DarkKhaki;
        public Color ClrSide10 { get; set; } = Color.DarkSeaGreen;
        public Color ClrSide11 { get; set; } = Color.DarkTurquoise;

        #endregion properties

        public FigureGraphic(Graphic graphic)
        {
            if (graphic == null)
            {
                return;
            }
            _graphic = graphic;
        }

        public void Draw()
        {

            Point3D pointA = new Point3D(X + 5, Y, Z);
            Point3D pointB = new Point3D(X + 2, Y + 3.5, Z - 1);
            Point3D pointC = new Point3D(X + 2, Y + 4, Z + 1.3);

            Point3D pointE = new Point3D(X + 4, Y + 9, Z - 1);
            Point3D pointF = new Point3D(X - 1, Y + 7, Z + 2);

            Point3D pointG = new Point3D(X + 3, Y + 8, Z);
            Point3D pointX = new Point3D(X + 4, Y + 7.5, Z + 2);

            Point3D pointD = new Point3D(X, Y, Z + 1.5);
            Point3D pointK = new Point3D(X + 1.8, Y + 5.3, Z + 0.5);
            Point3D pointO = new Point3D(X, Y, Z);
            Point3D pointZ = new Point3D(X, Y + 7, Z);

            // Отрисовка переднего треугольника
            _graphic.DrawPolygon(ClrSide1, pointA, pointB, pointK, pointC);
            _graphic.DrawPolygon(ClrSide2, pointB, pointK, pointF, pointE);
            _graphic.DrawTriangle(ClrSide3, pointF, pointX, pointG);
            _graphic.DrawTriangle(ClrSide4, pointF, pointX, pointD);
            _graphic.DrawTriangle(ClrSide5, pointD, pointC, pointA);
            _graphic.DrawPolygon(ClrSide6, pointD, pointK, pointG, pointX);
            _graphic.DrawPolygon(ClrSide7, pointA, pointB, pointO);
            _graphic.DrawTriangle(ClrSide8, pointE, pointZ, pointF);
            _graphic.DrawPolygon(ClrSide9, pointE, pointB, pointZ);
            _graphic.DrawTriangle(ClrSide10, pointB, pointO, pointZ);
            _graphic.DrawPolygon(ClrSide11, pointO, pointD, pointF, pointZ);
        }
    }
}
