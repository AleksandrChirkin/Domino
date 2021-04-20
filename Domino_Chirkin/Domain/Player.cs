using System.Collections.Generic;
using System.Linq;

namespace Domino_Chirkin.Domain
{
    public class Player
    {
        public Player(string name, HashSet<Stone> stones)
        {
            Name = name;
            Stones = stones;
        }

        public string Name { get; }
        public HashSet<Stone> Stones { get; }

        public int CountPoints() => Stones.Sum(stone => stone.First + stone.Second);
    }
}

