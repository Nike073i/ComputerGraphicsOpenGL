using SharpGL;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicsOpenGL
{
    public partial class ShowFigureForm : Form
    {
        private readonly OpenGL _openGl;
        private readonly Graphic _graphic;
        public ShowFigureForm()
        {
            InitializeComponent();
            _openGl = openGLControlFigure.OpenGL;
            _graphic = new Graphic(_openGl);
        }


        private void openGLControlFigure_OpenGLDraw(object sender, RenderEventArgs args)
        {
            _graphic.DrawAxes(Color.Red, Color.Yellow, Color.Blue);

            _graphic.DrawTriangle(Color.Violet, new Point3D(0, 2.5, 0), new Point3D(0, 2.5, 2.5), new Point3D(0.5, 5, 1.25));
            _graphic.DrawPolygon(Color.Violet, new Point3D(0, 0, 2.5), 
                new Point3D(5, 0, 2.5), new Point3D(5, 2.5, 2.5), new Point3D(0, 2.5, 2.5));
        }

        private void openGLControlFigure_Load(object sender, EventArgs e)
        {
            _openGl.MatrixMode(OpenGL.GL_PROJECTION);
            _openGl.LoadIdentity();
            // Угол обзора, соотношение экрана, Расстояние до А, до B
            _openGl.Perspective(90, 16 / 9, 0.1, 200);

            // Положение камеры x,y,z, Точка направления x,y,z, Поворот "Головы" x,y,z
            _openGl.LookAt(10, 10, 10, 0, 1, 0, 0, 1, 0);
            _openGl.MatrixMode(OpenGL.GL_MODELVIEW);
            _openGl.LoadIdentity();

            // RGBA float
            _openGl.ClearColor(0.1f, 1f, 0.3f, 1);

            // подготавливаем сцену для вывода изображений(очищаем ее)
            _openGl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }
    }
}
