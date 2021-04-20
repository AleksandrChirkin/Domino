using System;
using Domino_Chirkin.Domain;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    public partial class FinishedControl : UserControl
    {
        private Game _game;
        public FinishedControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;

            _game = game;
            fieldControl.Configure(game);
            var pointsText = PointsText(game.UserPlayer.CountPoints(), game.BotPlayer.CountPoints());
            if (game.UserPlayer.Stones.Count == 0)
                winnerLabel.Text = @"Победил человек";
            else if (game.BotPlayer.Stones.Count == 0)
                winnerLabel.Text = @"Победил AI";
            else if (game.UserPlayer.CountPoints() < game.BotPlayer.CountPoints())
                winnerLabel.Text = $@"Победил человек (по очкам): {pointsText}";
            else if (game.UserPlayer.CountPoints() > game.BotPlayer.CountPoints())
                winnerLabel.Text = $@"Победил AI (по очкам): {pointsText}";
            else
                winnerLabel.Text = $@"Ничья: {pointsText}";
        }

        private string PointsText(int first, int second) =>
            $"{Math.Min(first,second)}:{Math.Max(first,second)}";
    }
}
