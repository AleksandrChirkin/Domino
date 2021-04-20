using System;
using Domino_Chirkin.Domain;
using System.Windows.Forms;

namespace Domino_Chirkin.Views
{
    public partial class MainForm : Form
    {
        private readonly Game _game;
        public MainForm()
        {
            InitializeComponent();
            _game = new Game();
            _game.StageChanged += Game_OnStageChanged;
            ShowStartScreen();
        }

        private void Game_OnStageChanged(GameStage stage)
        {
            switch (stage)
            {
                case GameStage.NotStarted:
                    ShowStartScreen();
                    break;
                case GameStage.Play:
                    ShowPlayScreen();
                    break;
                case GameStage.Finished:
                    ShowFinishedScreen();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stage), stage, null);
            }
        }

        private void ShowStartScreen()
        {
            HideScreens();
            startControl.Configure(_game);
            startControl.Show();
        }
        private void ShowPlayScreen()
        {
            HideScreens();
            playControl.Configure(_game);
            playControl.Show();
        }

        private void ShowFinishedScreen()
        {
            HideScreens();
            finishedControl.Configure(_game);
            finishedControl.Show();
        }

        private void HideScreens()
        {
            startControl.Hide();
            playControl.Hide();
            finishedControl.Hide();
        }
    }
}
