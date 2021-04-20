using Domino_Chirkin.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    public partial class AssetControl : UserControl
    {
        private bool _configured;
        private bool _demonstration;
        private HashSet<Stone> _stones;
        private Game _game;

        public AssetControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game, HashSet<Stone> stones, bool toDemonstrate)
        {
            if (_configured)
                throw new InvalidOperationException();
            _game = game;
            _demonstration = toDemonstrate;
            _stones = stones;
            _configured = true;
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            Controls.Clear();
            var currentX = 10;
            var currentY = Height / 2;
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            if (!_configured)
                return;
            foreach (var label in _stones.Select(stone => new Label
            {
                BackColor = Color.White,
                Font = new Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold),
                Location = new Point(currentX, currentY - 50),
                Size = _demonstration 
                    ? new Size(30, 60) 
                    : new Size(20, 40),
                Text = _demonstration ? $"{stone.First}{stone.Second}" : ""
            }))
            {
                Controls.Add(label);
                if (_demonstration)
                    label.Click += UserControl_OnClickStone;
                currentX += 40;
            }
        }

        private void UserControl_OnClickStone(object sender, EventArgs args)
        {
            if (!(args is MouseEventArgs arg) || arg.Button != MouseButtons.Left ||
                !_game.CurrentPlayer.Equals(_game.UserPlayer) || !(sender is Label stone))
                return;
            var first = int.Parse(stone.Text[0].ToString());
            var second = int.Parse(stone.Text[1].ToString());
            _game.Step(new Stone(first, second));
        }
    }
}
