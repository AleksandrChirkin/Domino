namespace Domino_Chirkin.Views
{
    partial class FinishedControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.winnerLabel = new System.Windows.Forms.Label();
            this.fieldControl = new Domino_Chirkin.Views.FieldControl();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.winnerLabel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.fieldControl, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1352, 419);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // winnerLabel
            // 
            this.winnerLabel.AutoSize = true;
            this.winnerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.winnerLabel.Location = new System.Drawing.Point(3, 0);
            this.winnerLabel.Name = "winnerLabel";
            this.winnerLabel.Size = new System.Drawing.Size(1346, 125);
            this.winnerLabel.TabIndex = 0;
            this.winnerLabel.Text = "Победил";
            this.winnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fieldControl
            // 
            this.fieldControl.BackColor = System.Drawing.Color.Green;
            this.fieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldControl.Location = new System.Drawing.Point(5, 130);
            this.fieldControl.Margin = new System.Windows.Forms.Padding(5);
            this.fieldControl.Name = "fieldControl";
            this.fieldControl.Size = new System.Drawing.Size(1342, 284);
            this.fieldControl.TabIndex = 0;
            // 
            // FinishedControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "FinishedControl";
            this.Size = new System.Drawing.Size(1352, 419);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
        }

        private Domino_Chirkin.Views.FieldControl fieldControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label winnerLabel;

        #endregion
    }
}