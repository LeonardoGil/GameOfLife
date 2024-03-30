using System.Diagnostics;

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

        public void ProcessCell(List<Cell> cells)
        {
            if (Alive)
                ProcessLivingCell(cells);
            else
                ProcessDeadCell(cells);
        }

        public void ProcessLivingCell(List<Cell> cells)
        {
            if (!cells.Any(x => x.Alive))
                WillLive = false;

            if (cells.Where(x => x.Alive).Count() >= 3)
                WillLive = false;

            WillLive = true;
        }

        public void ProcessDeadCell(List<Cell> cells)
        {
            if (cells.Where(x => x.Alive).Count() == 3)
                WillLive = true;

            WillLive = false;
        }

        public void NextGeneration()
        {
            if (WillLive.HasValue)
            {
                Alive = WillLive.Value;
                WillLive = default;
            }
        }
    }
}
