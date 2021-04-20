using Domino_Chirkin.Domain;
using NUnit.Framework;

namespace Tests
{
    public class FinishTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game(false);
            _game.Start("Human", "AI");
        }

        [Test]
        public void OnGameOverWhenPlayerHasNoStones()
        {
            CreateNoStoneCase();
            Assert.AreEqual(GameStage.Finished, _game.Stage);
        }

        [Test]
        public void OnCurrentPlayerAssetEmptyWhenGameOverInCaseOne()
        {
            CreateNoStoneCase();
            Assert.AreEqual(0, _game.CurrentPlayer.Stones.Count);
        }

        private void CreateNoStoneCase()
        {
            // Принудительно создается ситуация, когда игрок заведомо выигрывает одним ходом.
            _game.GameField.ActiveStones.Clear();
            _game.GameField.ActiveStones.Add(new Stone(0, 1));
            if (_game.CurrentPlayer == _game.BotPlayer)
                _game.MoveToNextPlayer();
            _game.CurrentPlayer.Stones.Clear();
            var finalStone = new Stone(0, 0);
            _game.CurrentPlayer.Stones.Add(finalStone);
            _game.Step(finalStone);
        }

        [Test]
        public void OnGameOverWhenDeckEmptyAndNoPlayerHasMatchingStone()
        {
            CreateNoRelevantStepsCase();
            Assert.AreEqual(GameStage.Finished, _game.Stage);   
        }

        [Test]
        public void OnBothPlayersHavingStonesWhenGameOverInCaseTwo()
        {
            CreateNoRelevantStepsCase();
            Assert.Greater(_game.UserPlayer.Stones.Count, 0);
            Assert.Greater(_game.BotPlayer.Stones.Count, 0);
        }

        private void CreateNoRelevantStepsCase()
        {
            //Принудительно создается ситуация, когда ни в колоде, ни у обоих игроков нет подходящего камня
            _game.GameField.ActiveStones.Clear();
            _game.GameField.ActiveStones.Add(new Stone(1, 1));
            _game.UserPlayer.Stones.Clear();
            _game.BotPlayer.Stones.Clear();
            var finalStone = new Stone(0, 1);
            _game.CurrentPlayer.Stones.Add(finalStone);
            _game.UserPlayer.Stones.Add(new Stone(2, 2));
            _game.BotPlayer.Stones.Add(new Stone(3, 3));
            _game.GameDeck.PassiveStones.Clear();
            _game.Step(finalStone);
        }
    }
}