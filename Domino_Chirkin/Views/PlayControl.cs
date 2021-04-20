using Domino_Chirkin.Domain;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    public partial class PlayControl : UserControl
    {
        private Game _game;
        public PlayControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
            fieldControl.Configure(game);
            userControl.Configure(game, game.UserPlayer.Stones, true);
            aiControl.Configure(game, game.BotPlayer.Stones, false);
            deckControl.Configure(game);
            game.PlayerChanged += Upgrade_Graphics;
        }

        private void Upgrade_Graphics(Player player, bool firstStep)
        {
            fieldControl.Controls.Clear();
            userControl.Controls.Clear();
            aiControl.Controls.Clear();
            deckControl.Controls.Clear();
        }
    }
}
