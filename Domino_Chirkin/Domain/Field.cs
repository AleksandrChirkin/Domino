using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Domino_Chirkin.Domain
{
    public class Field
    {
        private int _left, _right, _lastFoundSide;

        public readonly List<Stone> ActiveStones;

        public int Count => ActiveStones.Count;

        public Field()
        {
            ActiveStones = new List<Stone>();
        }

        public StepResult Step(Stone stone, bool user, bool isFirst = false)
        {
            if (isFirst)
            {
                ActiveStones.Add(stone);
                _left = stone.First;
                _right = stone.Second;
                return StepResult.ValidStep;
            }
            if (!Matches(stone))
                return StepResult.InvalidStep;
            if (SelectMatchingSide(stone, user) == _left)
            {
                ActiveStones.Insert(0, stone);
                _left = GetAnotherSide(stone);
                return StepResult.ValidStep;
            }
            ActiveStones.Add(stone);
            _right = GetAnotherSide(stone);
            return StepResult.ValidStep;
        }

        public bool Matches(Stone stone) => _left == stone.First || _left == stone.Second ||
                                            _right == stone.First || _right == stone.Second;

        private int SelectMatchingSide(Stone stone, bool user)
        {
            if (stone.First == stone.Second || stone.Second != _left && stone.Second != _right)
                return ModifyLast(stone.First);
            if (stone.First != _left && stone.First != _right)
                return ModifyLast(stone.Second);
            return user ? Deconfliction(stone) : ModifyLast(stone.First);
        }

        private int ModifyLast(int newLast)
        {
            _lastFoundSide = newLast;
            return newLast;
        }

        private int GetAnotherSide(Stone stone) => _lastFoundSide == stone.First
            ? stone.Second
            : stone.First;

        private static int Deconfliction(Stone stone)
        {
            var minimum = Math.Min(stone.First, stone.Second);
            var maximum = Math.Max(stone.First, stone.Second);
            var message = "Конфликт. Обе части кости могут быть подставлены.\n" +
                $"Чтобы поставить на место {minimum}, нажмите Да\n" +
                $"Чтобы поставить на место {maximum}, нажмите Нет";
            var result = MessageBox.Show(message, @"Conflict", MessageBoxButtons.YesNo);
            return result == DialogResult.Yes ? minimum : maximum;
        }
    }
}
