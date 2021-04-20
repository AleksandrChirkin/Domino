using System.Linq;
using Domino_Chirkin.AI;
using Domino_Chirkin.Domain;
using NUnit.Framework;

namespace Tests
{
    public class PlayTests
    {
        private Game _game;
        
        [SetUp]
        public void Setup()
        {
            _game = new Game(false);
            _game.Start("Human", "AI");
        }

        [Test]
        public void NumberOfCurrentPlayerStonesDecreasedByOneAfterStep()
        {
            var currentPlayer = GetCurrentPlayer();
            if (currentPlayer == null) 
                Assert.Ignore();
            var initialNumber = currentPlayer.Stones.Count;
            var step = currentPlayer.Stones.FirstOrDefault(_game.GameField.Matches);
            _game.Step(step);
            Assert.AreEqual(initialNumber - 1, currentPlayer.Stones.Count);
        }
        
        [Test]
        public void NumberOfFieldStonesIncreasedByOneAfterStep()
        {
            var currentPlayer = GetCurrentPlayer();
            if (currentPlayer == null)
                Assert.Ignore();
            var initialNumber = _game.GameField.Count;
            var step = currentPlayer.Stones.FirstOrDefault(_game.GameField.Matches);
            _game.Step(step);
            Assert.AreEqual(initialNumber + 1, _game.GameField.Count);
        }
        
        [Test]
        public void CurrentPlayerChangedAfterStep()
        {
            var currentPlayer = GetCurrentPlayer();
            if (currentPlayer == null)
                Assert.Ignore();
            var step = currentPlayer.Stones.FirstOrDefault(_game.GameField.Matches);
            _game.Step(step);
            Assert.AreSame(currentPlayer, _game.GetNextPlayer());
        }

        private Player GetCurrentPlayer()
        {
            var currentPlayer = _game.CurrentPlayer;
            if (currentPlayer.Stones.All(stone =>
                !_game.GameField.Matches(stone)))
            {
                currentPlayer = _game.GetNextPlayer();
                if (currentPlayer.Stones.All(stone =>
                    !_game.GameField.Matches(stone)))
                    return null;
            }

            return currentPlayer;
        }
        
        [Test]
        public void OneStoneOnFieldIncreasedAfterFirstStep()
        {
            var stone = _game.GetFirstStone();
            _game.Step(stone, true);
            Assert.AreEqual(1, _game.GameField.Count);
        }

        [Test]
        public void GeneratedStepMatchesField()
        {
            if (_game.BotPlayer.Stones.All(item => !_game.GameField.Matches(item)))
                Assert.Ignore();
            var stone = _game.BotPlayer.GenerateStep(_game.GameField);
            Assert.IsTrue(_game.GameField.Matches(stone));
        }

        [Test]
        public void CurrentPlayerAssetIncreasedOrNotChangedOnGettingNewStones()
        {
            var initialNumber = _game.CurrentPlayer.Stones.Count;
            _game.GetNewStones(false);
            Assert.GreaterOrEqual(_game.CurrentPlayer.Stones.Count, initialNumber);
        }

        [Test]
        public void DeckDecreasedOrNotChangedOnGettingNewStones()
        {
            var initialNumber = _game.GameDeck.Count;
            _game.GetNewStones(false);
            Assert.LessOrEqual(_game.GameDeck.Count, initialNumber);
        }

        [Test]
        public void CurrentPlayerAssetIncreasedWhenHeHasNoRelevantStones()
        {
            CreateGettingNewStonesSituation();
            var initialNumber = _game.CurrentPlayer.Stones.Count;
            _game.GetNewStones(false);
            Assert.Greater(_game.CurrentPlayer.Stones.Count, initialNumber);
        }
        
        [Test]
        public void DeckDecreasedWhenPlayerHasNoRelevantStones()
        {
            CreateGettingNewStonesSituation();
            var initialNumber = _game.GameDeck.Count;
            _game.GetNewStones(false);
            Assert.Less(_game.GameDeck.Count, initialNumber);
        }

        private void CreateGettingNewStonesSituation()
        {
            var matchingStones = _game.CurrentPlayer.Stones.Where(stone =>
                _game.GameField.Matches(stone)).ToList();
            foreach (var matchingStone in matchingStones)
                _game.CurrentPlayer.Stones.Remove(matchingStone);
        }
    }
}