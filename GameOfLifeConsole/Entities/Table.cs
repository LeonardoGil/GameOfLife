namespace GameOfLifeConsole.Entities
{
    internal class Table
    {
        private readonly int rows;
        private readonly int columns;

        public bool[,] Cells { get; set; }

        public Table(int rowLenght, int columnLeght)
        {
            rows = rowLenght;
            columns = columnLeght;

            Cells = new bool[rows, columns];
        }

        public (int, int)[] GetNeighboringCells()
        {
            throw new NotImplementedException();
        }

        public bool IsAlive(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
