using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ComputerGraphicsOpenGL
{
    public struct TextureStruct
    {
        public uint TextureValue;
        public double[,] X_YText;
        public double[,] CoordX_YText;
    }
    public class Graphic
    {
        private readonly OpenGL _openGl;
        private readonly float[] light0_diffuse3 = { 1f, 1f, 0f };
        private readonly float[] light0_direction3 = { 8f, 8f, 8f, 1.0f };

        public Graphic(OpenGL openGl)
        {
            if (openGl == null)
            {
                return;
            }

            _openGl = openGl;
            _openGl.Light(OpenGL.GL_LIGHT5, OpenGL.GL_DIFFUSE, light0_diffuse3);
            _openGl.Light(OpenGL.GL_LIGHT5, OpenGL.GL_POSITION, light0_direction3);
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
            if (points.Length == 0)
            {
                return;
            }

            _openGl.Begin(OpenGL.GL_POLYGON);
            _openGl.Color(color);
            foreach (Point3D point in points)
            {
                _openGl.Vertex(point.X, point.Y, point.Z);
            }
            _openGl.End();
        }

        public void DrawDumbbell(Color color, int numSegments)
        {
            DrawFillCircle(0, 0, 4, 4, numSegments, color);
            DrawFillCircle(0, 0, 5, 3.5f, numSegments, color);
            DrawFillCircle(0, 0, 6, 2.5f, numSegments, color);
            DrawFillCircle(0, 0, 7, 1.5f, numSegments, color);

            DrawFillCircle(0, 0, -4, 4, numSegments, color);
            DrawFillCircle(0, 0, -5, 3.5f, numSegments, color);
            DrawFillCircle(0, 0, -6, 2.5f, numSegments, color);
            DrawFillCircle(0, 0, -6.7f, 1.5f, numSegments, color);

            _openGl.PushMatrix();
            DrawPartOfDumbbell(numSegments);
            _openGl.PopMatrix();
            _openGl.PushMatrix();
            _openGl.Rotate(0, -180, 0);
            DrawPartOfDumbbell(numSegments);
            _openGl.PopMatrix();
        }

        public void TurnLight()
        {
            _openGl.Enable(OpenGL.GL_LIGHTING);
            _openGl.Enable(OpenGL.GL_LIGHT5);
        }

        public void TurnOffLight()
        {
            _openGl.Disable(OpenGL.GL_LIGHTING);
            _openGl.Disable(OpenGL.GL_LIGHT5);
        }

        private void DrawPartOfDumbbell(int numSegments)
        {
            IntPtr pipeQuadric = _openGl.NewQuadric();
            _openGl.QuadricDrawStyle(pipeQuadric, OpenGL.GLU_FILL);
            _openGl.Cylinder(pipeQuadric, 1, 1, 4, numSegments, numSegments);
            _openGl.Translate(0, 0, 4);
            IntPtr largeDiskQuadric = _openGl.NewQuadric();
            _openGl.QuadricDrawStyle(largeDiskQuadric, OpenGL.GLU_FILL);
            _openGl.Cylinder(largeDiskQuadric, 4, 3.5, 1, numSegments, numSegments);

            _openGl.Translate(0, 0, 1);
            IntPtr mediumDiskQuadric = _openGl.NewQuadric();
            _openGl.QuadricDrawStyle(mediumDiskQuadric, OpenGL.GLU_FILL);
            _openGl.Cylinder(mediumDiskQuadric, 3, 2.5, 1, numSegments, numSegments);

            _openGl.Translate(0, 0, 1);
            IntPtr smallDiskQuadric = _openGl.NewQuadric();
            _openGl.QuadricDrawStyle(smallDiskQuadric, OpenGL.GLU_FILL);
            _openGl.Cylinder(smallDiskQuadric, 2, 1.5, 1, numSegments, numSegments);

        }

        public void DrawFillCircle(float cx, float cy, float cz, float r, int numSegments, Color color)
        {
            _openGl.Begin(OpenGL.GL_POLYGON);
            _openGl.Color(color);
            for (int ii = 0; ii < numSegments; ii++)
            {
                double theta = 2.0 * 3.1415926f * ii / numSegments;//get the current angle 
                double x = r * Math.Cos(theta);//calculate the x component 
                double y = r * Math.Sin(theta);//calculate the y component 
                _openGl.Vertex(x + cx, y + cy, cz);//output vertex 
            }
            _openGl.End();
        }

        public void DrawTexture(string path)
        {
            TextureStruct Textures = new TextureStruct
            {
                CoordX_YText = new double[4, 3] { { -8, 8, 4 }, { -8, 8, -4 }, { -8, 0, -4 }, { -8, 0, 4 } },
                X_YText = new double[4, 2] { { 0, 0 }, { 1, 0 }, { 1, 1 }, { 0, 1 } }
            };
            Bitmap BmpImage = new Bitmap(new Bitmap(path), 256, 256);
            Rectangle rect = new Rectangle(0, 0, BmpImage.Width, BmpImage.Height);
            BitmapData BmpData = BmpImage.LockBits(rect, ImageLockMode.ReadOnly, BmpImage.PixelFormat);
            _openGl.TexImage2D(
                OpenGL.GL_TEXTURE_2D,
                0,
                (int)OpenGL.GL_RGBA,
                BmpImage.Width,
                BmpImage.Height,
                0,
                OpenGL.GL_BGRA,
                OpenGL.GL_UNSIGNED_BYTE,
                BmpData.Scan0
            );
            BmpImage.UnlockBits(BmpData);
            _openGl.BindTexture(OpenGL.GL_TEXTURE_2D, Textures.TextureValue);
            _openGl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
            _openGl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            _openGl.Enable(OpenGL.GL_TEXTURE_2D);
            _openGl.Begin(OpenGL.GL_QUADS);
            for (int i = 0; i < 4; i++)
            {
                _openGl.TexCoord(Textures.X_YText[i, 0], Textures.X_YText[i, 1]);
                _openGl.Vertex(Textures.CoordX_YText[i, 0], Textures.CoordX_YText[i, 1], Textures.CoordX_YText[i, 2]);
            }
            _openGl.End();
            _openGl.Disable(OpenGL.GL_TEXTURE_2D);
        }
    }
}
