using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Domino_Chirkin.Domain;

namespace Domino_Chirkin.Views
{
    public partial class FieldControl : UserControl
    {
        private bool _configured;
        private Game _game;

        public FieldControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_configured)
                throw new InvalidOperationException();
            _game = game;
            _configured = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            Controls.Clear();
            var field = _game.GameField;
            var currentX = 10;
            var currentY = Height / 2;
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (!_configured)
                return;
            for (var i = 0; i < field.Count; i++)
            {
                if (field.ActiveStones[i].First == field.ActiveStones[i].Second)
                {
                    var label = new Label
                    {
                        BackColor = Color.White,
                        Location = new Point(currentX, currentY - 20),
                        Size = new Size(20, 40),
                        Text = $@"{field.ActiveStones[i].First} {field.ActiveStones[i].Second}"
                    };
                    Controls.Add(label);
                    currentX += 20;
                    continue;
                }
                var stone = new Label
                {
                    BackColor = Color.White,
                    Location = new Point(currentX, currentY - 10),
                    Size = new Size(40, 20),
                    Text = ToReverse(i, field.ActiveStones) 
                        ? $"{field.ActiveStones[i].Second} {field.ActiveStones[i].First}"
                        : $"{field.ActiveStones[i].First} {field.ActiveStones[i].Second}"
                };
                Controls.Add(stone);
                currentX += 40;
            }
        }

        private bool ToReverse(int i, List<Stone> stones) =>
            i<stones.Count - 1 && 
            (stones[i].First == stones[i+1].First ||
             stones[i].First == stones[i+1].Second) ||
            i>0 &&
            (stones[i].Second == stones[i-1].Second ||
             stones[i].Second == stones[i-1].First);
    }
}
