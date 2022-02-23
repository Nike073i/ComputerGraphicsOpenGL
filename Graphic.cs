using SharpGL;
using SharpGL.SceneGraph;
using System.Drawing;

namespace ComputerGraphicsOpenGL
{
    public class Graphic
    {
        private readonly OpenGL _openGl;

        public Graphic(OpenGL openGl)
        {
            if (openGl == null) return;
            _openGl = openGl;
        }


        public void DrawAxes(Color clrXAxis, Color clrYAxis, Color clrZAxis)
        {
            // Отрисовка оси X
            DrawLine(clrXAxis, new Point3D(0, 0, 0), new Point3D(10, 0, 0));
            // Отрисовка оси Y
            DrawLine(clrYAxis, new Point3D(0, 0, 0), new Point3D(0, 10, 0));
            // Отрисовка оси Z
            DrawLine(clrZAxis, new Point3D(0, 0, 0), new Point3D(0, 0, 10));
        }

        public void DrawLine(Color color, Point3D start, Point3D end)
        {
            _openGl.Color(color);
            _openGl.Begin(OpenGL.GL_LINES);
            _openGl.Vertex(start.X, start.Y, start.Z);
            _openGl.Vertex(end.X, end.Y, end.Z);
            _openGl.End();
        }

        public void DrawTriangle(Color color, Point3D start, Point3D middle, Point3D end)
        {
            _openGl.Begin(OpenGL.GL_TRIANGLES);
            _openGl.Color(color);
            _openGl.Vertex(start.X, start.Y, start.Z);
            _openGl.Vertex(middle.X, middle.Y, middle.Z);
            _openGl.Vertex(end.X, end.Y, end.Z);
            _openGl.End();
        }

        public void DrawPolygon(Color color, params Point3D[] points)
        {
            if (points.Length == 0) return;
            _openGl.Begin(OpenGL.GL_POLYGON);
            _openGl.Color(color);
            foreach (var point in points)
            {
                _openGl.Vertex(point.X, point.Y, point.Z);
            }
            _openGl.End();
        }
    }
}
