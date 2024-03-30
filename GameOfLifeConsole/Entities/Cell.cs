namespace GameOfLifeConsole.Entities
{
    internal class Cell
    {
        public bool Alive { get; private set; }

        public bool? WillLive { get; private set; }

        public readonly int Row;

        public readonly int Column;

        public Cell(int x, int y, bool alive)
        {
            Column = x;
            Row = y;
            Alive = alive;
        }


    }
}
