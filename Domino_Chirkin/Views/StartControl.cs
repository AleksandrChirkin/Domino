using System;
using Domino_Chirkin.Domain;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    public partial class StartControl : UserControl
    {
        private Game _game;

        public StartControl()
        {
            InitializeComponent();
        }

        public void Configure(Game game)
        {
            if (_game != null)
                return;
            _game = game;
            startButton.Click += StartButton_Click;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            _game.Start("Human", "AI");
        }
    }
}
