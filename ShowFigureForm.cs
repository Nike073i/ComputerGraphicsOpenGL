using SharpGL;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphicsOpenGL
{
    public partial class ShowFigureForm : Form
    {
        private readonly double _camR = 10;
        private readonly double _degToRads = 0.0174533;
        private readonly double _camAngleStep = 3.0;
        private readonly double _xStep = 1;

        private readonly OpenGL _openGl;
        private readonly Graphic _graphic;
        private readonly FigureGraphic _figure;

        private double _camAngle = 28;
        private double _camX;
        private double _camZ;

        public ShowFigureForm()
        {
            InitializeComponent();
            _openGl = openGLControlFigure.OpenGL;
            _graphic = new Graphic(_openGl);
            _figure = new FigureGraphic(_graphic);
            _camZ = Math.Sin(_camAngle * _degToRads) * _camR;
            _camX = Math.Cos(_camAngle * _degToRads) * _camR;
        }

        private void OpenGLControlFigure_OnOpenGLDraw(object sender, RenderEventArgs args)
        {
            _graphic.DrawAxes(Color.Red, Color.Yellow, Color.Blue);
            _figure.Draw();
        }

        private void LoadCamSetting()
        {
            _openGl.MatrixMode(OpenGL.GL_PROJECTION);
            _openGl.LoadIdentity();
            _openGl.Perspective(90, 16 / 9, 0.1, 200);

            _openGl.LookAt(_camX, 10, _camZ, 0, 0, 0, 0, 1, 0);
            _openGl.MatrixMode(OpenGL.GL_MODELVIEW);
            _openGl.LoadIdentity();

            _openGl.ClearColor(0.1f, 1f, 0.3f, 1);
            _openGl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void OpenGLControlFigure_OnLoad(object sender, EventArgs e)
        {
            LoadCamSetting();
        }

        private void RotateCamera(DirectionRotate direction)
        {
            _camAngle -= _camAngleStep * Convert.ToInt32(direction); ;
            _camX = _camR * Math.Cos(_camAngle * _degToRads);
            _camZ = _camR * Math.Sin(_camAngle * _degToRads);
            LoadCamSetting();
        }

        private void MoveFigure(DirectionRotate direction)
        {
            _figure.X += _xStep * Convert.ToInt32(direction);
            _openGl.ClearColor(0.1f, 1f, 0.3f, 1);
            _openGl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
        }

        private void OpenGLControlFigure_OnPreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    RotateCamera(DirectionRotate.RIGHT);
                    break;
                case Keys.Left:
                    RotateCamera(DirectionRotate.LEFT);
                    break;
                case Keys.A:
                    MoveFigure(DirectionRotate.LEFT);
                    break;
                case Keys.D:
                    MoveFigure(DirectionRotate.RIGHT);
                    break;
            }
        }
    }
}
