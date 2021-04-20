using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Domino_Chirkin.AI;

namespace Domino_Chirkin.Domain
{
    public class Game
    {
        private bool _isUserCurrent;
        
        public event Action<Player, bool> PlayerChanged;
        public event Action<GameStage> StageChanged;
        
        public Field GameField { get; private set; }
        public Deck GameDeck { get; private set; }
        public GameStage Stage { get; private set; } = GameStage.NotStarted;
        public Player UserPlayer { get; private set; }
        public Player BotPlayer { get; private set; }
        public Player CurrentPlayer => _isUserCurrent ? UserPlayer : BotPlayer;

        public Game(bool toPlay = true)
        {
            if (toPlay)
                PlayerChanged += Player_Changed;
        }
        
        private void Player_Changed(Player player, bool firstStep)
        {
            if (firstStep)
            {
                var first = GetFirstStone();
                Step(first, true);
            }

            if (Stage != GameStage.Play) return;
            GetNewStones();
            if (GameDeck.Count == 0 && CurrentPlayer.Stones.All(item =>
                !GameField.Matches(item)))
                MoveToNextPlayer();
            if (!CurrentPlayer.Equals(BotPlayer)) return;
            try
            {
                var stone = CurrentPlayer.GenerateStep(GameField);
                Step(stone, firstStep);
            }
            catch
            {
                MoveToNextPlayer();
            }
        }

        public void Start(string firstPlayerName, string secondPlayerName)
        {
            GameField = new Field();
            GameDeck = new Deck();
            UserPlayer = CreatePlayer(firstPlayerName);
            BotPlayer = CreatePlayer(secondPlayerName);            
            _isUserCurrent = UserIsFirst();
            var wordForm = _isUserCurrent ? "ходишь ты" : "ходит AI";
            MessageBox.Show($@"Первым {wordForm}");
            ChangeStage(GameStage.Play);
            PlayerChanged?.Invoke(CurrentPlayer, true);                                  
        }

        private Player CreatePlayer(string name)
        {
            var asset = new HashSet<Stone>();
            foreach (var stone in FillAsset())
                asset.Add(stone);
            return new Player(name, asset);
        }

        private IEnumerable<Stone> FillAsset()
        {
            for (var i = 0; i < 6; i++)
                yield return GameDeck.GetStone();
        }


        private bool UserIsFirst()
        {
            for (var i = 1; i < 6; i++)
            {
                if (UserPlayer.Stones.Contains(new Stone(i, i)))
                    return true;
                if (BotPlayer.Stones.Contains(new Stone(i, i)))
                    return false;
            }
            return true;
        }

        public Stone GetFirstStone()
        {
            for (var i = 1; i < 6; i++)
                if (CurrentPlayer.Stones.Contains(new Stone(i, i)))
                    return new Stone(i, i);
            return CurrentPlayer.Stones.FirstOrDefault();
        }

        private void ChangeStage(GameStage stage)
        {
            Stage = stage;
            StageChanged?.Invoke(stage);
        }

        public void Step(Stone stone, bool isFirst = false)
        {
            if (Stage != GameStage.Play)
                throw new InvalidOperationException();           
            var stepResult = GameField.Step(stone, _isUserCurrent, isFirst);
            switch (stepResult)
            {
                case StepResult.InvalidStep:
                    return;
                case StepResult.ValidStep:
                    CurrentPlayer.Stones.Remove(stone);
                    if (GameOver())
                        ChangeStage(GameStage.Finished);
                    else
                        MoveToNextPlayer();
                    return;
            }
        }

        public void MoveToNextPlayer()
        {
            _isUserCurrent = !_isUserCurrent;
            PlayerChanged?.Invoke(CurrentPlayer, false);
        }

        public void GetNewStones(bool demonstrateWindow = true)
        {
            var counter = 0;
            while (GameDeck.Count > 0 && CurrentPlayer.Stones.All(stone =>
                !GameField.Matches(stone)))
            {
                CurrentPlayer.Stones.Add(GameDeck.GetStone());
                counter++;
            }

            if (demonstrateWindow)
                DemonstrateMessage(counter);
        }

        private void DemonstrateMessage(int counter)
        {
            var playerName = _isUserCurrent ? "Ты" : "AI";
            if (counter > 0)
                MessageBox.Show($@"{playerName} взял {counter} {OnWordForm(counter)}");
        }

        private static string OnWordForm(int number)
        {
            if (number % 10 == 1 && number % 100 / 10 != 1) return "камень";
            return number % 10 >= 2 && number % 10 <= 4 && number % 100 / 10 != 1 
                ? "камня" 
                : "камней";
        }

        private bool GameOver() => CurrentPlayer.Stones.Count == 0 || GameDeck.Count == 0 &&
            CurrentPlayer.Stones.All(stone => !GameField.Matches(stone)) &&
            GetNextPlayer().Stones.All(stone => !GameField.Matches(stone));

        public Player GetNextPlayer() => _isUserCurrent ? BotPlayer : UserPlayer;
    }
}
