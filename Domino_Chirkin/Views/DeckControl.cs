using System.Drawing;
using System.Windows.Forms;
using Domino_Chirkin.Domain;

namespace Domino_Chirkin.Views
{
    public partial class DeckControl : UserControl
    {
        private Game _game;
        public DeckControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var stonesCount = _game.GameDeck.PassiveStones.Count;
            if (stonesCount <= 0) return;
            var label = new Label
            {
                BackColor = Color.White,
                Location = new Point(Width / 2 - 20, Height / 2 - 10),
                Size = new Size(40, 20),
                Text = $@"{stonesCount}"
            };
            Controls.Add(label);
        }
    }
}
