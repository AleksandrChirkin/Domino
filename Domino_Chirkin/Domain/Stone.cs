namespace Domino_Chirkin.Domain
{
    public readonly struct Stone
    {
        public int First { get; }
        public int Second { get; }

        public Stone(int first, int second)
        {
            First = first;
            Second = second;
        }

        public override int GetHashCode() => 10 * First + Second;

        public override string ToString() => $"{First} {Second}";
    }
}
