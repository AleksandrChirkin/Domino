using Domino_Chirkin.Domain;
using NUnit.Framework;

namespace Tests
{
    public class StartTests
    {
        private Game _game;

        [SetUp]
        public void Setup()
        {
            _game = new Game(false);
        }
        
        [Test]
        public void OnNotStarted()
        {
            Assert.IsNull(_game.BotPlayer);
            Assert.IsNull(_game.GameDeck);
            Assert.IsNull(_game.GameField);
            Assert.IsNull(_game.UserPlayer);
        }

        [Test]
        public void GameStageChangedOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.AreEqual(GameStage.Play, _game.Stage);
        }

        [Test]
        public void DeckDecreasedOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.AreEqual(16, _game.GameDeck.PassiveStones.Count);
        }

        [Test]
        public void FieldEmptyOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.AreEqual(0, _game.GameField.Count);
        }

        [Test]
        public void PlayersNotNullOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.IsNotNull(_game.UserPlayer);
            Assert.IsNotNull(_game.BotPlayer);
        }

        [Test]
        public void PlayersHaveRelevantNamesOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.AreEqual("Human", _game.UserPlayer.Name);
            Assert.AreEqual("AI", _game.BotPlayer.Name);
        }
        
        [Test]
        public void PlayersHaveSixStonesOnStarted()
        {
            _game.Start("Human", "AI");
            Assert.AreEqual(6,_game.UserPlayer.Stones.Count);
            Assert.AreEqual(6,_game.BotPlayer.Stones.Count);
        }
    }
}