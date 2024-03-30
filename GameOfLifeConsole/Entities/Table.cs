namespace GameOfLifeConsole.Entities
{
    internal class Table
    {
        private readonly int rows;
        private readonly int columns;

        public Cell[] Cells { get; set; }

        public Table(int rowLenght, int columnLeght)
        {
            rows = rowLenght;
            columns = columnLeght;

            Cells = new Cell[rows * columns];

            var arrayLenght = Cells.Length;

            var aliveCells = GenerateRandomCells(10);

            for (int x = 0; x < columns; x++)
                for (int y = 0; y < rows; y++)
                {
                    var alive = aliveCells.Any(pos => pos.Item1 == x &&
                                                      pos.Item2 == y);

                    Cells[arrayLenght] = new Cell(x, y, alive);
                    
                    arrayLenght++;
                }
        }

        private (int, int)[] GenerateRandomCells(int count)
        {
            var random = new Random();
            var result = new (int, int)[count];

            for (int i = 0; i < count; i++)
            {
                var x = random.Next(0, rows - 1);
                var y = random.Next(0, columns - 1);

                result[i] = (x, y);
            }

            return result;
        }

        public (int, int)[] GetNeighboringCells()
        {
            throw new NotImplementedException();
        }
    }
}
