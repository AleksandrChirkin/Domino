using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    partial class PlayControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.userControl = new Domino_Chirkin.Views.AssetControl();
            this.fieldControl = new Domino_Chirkin.Views.FieldControl();
            this.deckControl = new Domino_Chirkin.Views.DeckControl();
            this.aiControl = new Domino_Chirkin.Views.AssetControl();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.BackColor = System.Drawing.Color.Green;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.Controls.Add(this.userControl, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.fieldControl, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.deckControl, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.aiControl, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1326, 540);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // userControl
            // 
            this.userControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userControl.Location = new System.Drawing.Point(5, 383);
            this.userControl.Margin = new System.Windows.Forms.Padding(5);
            this.userControl.Name = "userControl";
            this.userControl.Size = new System.Drawing.Size(1050, 152);
            this.userControl.TabIndex = 0;
            // 
            // fieldControl
            // 
            this.fieldControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fieldControl.Location = new System.Drawing.Point(5, 59);
            this.fieldControl.Margin = new System.Windows.Forms.Padding(5);
            this.fieldControl.Name = "fieldControl";
            this.fieldControl.Size = new System.Drawing.Size(1050, 314);
            this.fieldControl.TabIndex = 1;
            // 
            // deckControl
            // 
            this.deckControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deckControl.Location = new System.Drawing.Point(1063, 57);
            this.deckControl.Name = "deckControl";
            this.deckControl.Size = new System.Drawing.Size(260, 318);
            this.deckControl.TabIndex = 2;
            // 
            // aiControl
            // 
            this.aiControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.aiControl.Location = new System.Drawing.Point(3, 3);
            this.aiControl.Name = "aiControl";
            this.aiControl.Size = new System.Drawing.Size(1054, 48);
            this.aiControl.TabIndex = 3;
            // 
            // PlayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "PlayControl";
            this.Size = new System.Drawing.Size(1326, 540);
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private Domino_Chirkin.Views.AssetControl aiControl;
        private Domino_Chirkin.Views.DeckControl deckControl;
        private Domino_Chirkin.Views.FieldControl fieldControl;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private Domino_Chirkin.Views.AssetControl userControl;

        #endregion
    }
}
