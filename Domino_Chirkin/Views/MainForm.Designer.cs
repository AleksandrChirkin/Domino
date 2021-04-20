using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startControl = new Domino_Chirkin.Views.StartControl();
            this.playControl = new Domino_Chirkin.Views.PlayControl();
            this.finishedControl = new Domino_Chirkin.Views.FinishedControl();
            this.SuspendLayout();
            // 
            // startControl
            // 
            this.startControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startControl.Location = new System.Drawing.Point(0, 0);
            this.startControl.Name = "startControl";
            this.startControl.Size = new System.Drawing.Size(1310, 501);
            this.startControl.TabIndex = 0;
            // 
            // playControl
            // 
            this.playControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playControl.Location = new System.Drawing.Point(0, 0);
            this.playControl.Name = "playControl";
            this.playControl.Size = new System.Drawing.Size(1310, 501);
            this.playControl.TabIndex = 1;
            // 
            // finishedControl
            // 
            this.finishedControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.finishedControl.Location = new System.Drawing.Point(0, 0);
            this.finishedControl.Name = "finishedControl";
            this.finishedControl.Size = new System.Drawing.Size(1310, 501);
            this.finishedControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 501);
            this.Controls.Add(this.startControl);
            this.Controls.Add(this.playControl);
            this.Controls.Add(this.finishedControl);
            this.MaximumSize = new System.Drawing.Size(1326, 540);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "MainForm";
            this.Text = "Домино";
            this.ResumeLayout(false);
        }

        private Domino_Chirkin.Views.FinishedControl finishedControl;
        private Domino_Chirkin.Views.PlayControl playControl;
        private Domino_Chirkin.Views.StartControl startControl;

        #endregion
    }
}