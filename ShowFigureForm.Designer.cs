namespace ComputerGraphicsOpenGL
{
    partial class ShowFigureForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.openGLControlFigure = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlFigure)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControlFigure
            // 
            this.openGLControlFigure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControlFigure.DrawFPS = false;
            this.openGLControlFigure.Location = new System.Drawing.Point(0, 0);
            this.openGLControlFigure.Name = "openGLControlFigure";
            this.openGLControlFigure.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControlFigure.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControlFigure.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControlFigure.Size = new System.Drawing.Size(800, 450);
            this.openGLControlFigure.TabIndex = 0;
            this.openGLControlFigure.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControlFigure_OpenGLDraw);
            this.openGLControlFigure.Load += new System.EventHandler(this.openGLControlFigure_Load);
            // 
            // ShowFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.openGLControlFigure);
            this.Name = "ShowFigureForm";
            this.Text = "Фигура 3D lab_3";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControlFigure)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControlFigure;
    }
}

