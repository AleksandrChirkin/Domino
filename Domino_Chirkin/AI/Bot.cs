using System;
using System.Collections.Generic;
using Domino_Chirkin.Domain;
using System.Linq;

namespace Domino_Chirkin.AI
{
    public static class Bot
    {
        //Тут применяется динпрог, так как вычисление хода для бота - нетривиальная штука.
        public static Stone GenerateStep(this Player player, Field field)
        {
            var otherStones = new Dictionary<int, int>();
            for (var i = 0; i <= 6; i++)
                otherStones[i] = 7 - field.ActiveStones.Count(item =>
                                      item.First == i || item.Second == i) - 
                                  player.Stones.Count(item =>
                                      item.First == i || item.Second == i);
            otherStones = otherStones.OrderByDescending(pair => pair.Value)
                .ToDictionary(pair => pair.Key, 
                    pair => pair.Value);
            var possibleSteps = player.Stones.Where(field.Matches).ToList();
            foreach (var value in otherStones)
            {
                if (possibleSteps.Any(stone =>
                    stone.First == value.Key || stone.Second == value.Key))
                    return possibleSteps.FirstOrDefault(stone =>
                        stone.First == value.Key || stone.Second == value.Key);
            }
            throw new InvalidOperationException();
        }
    }
}
