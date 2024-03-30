namespace GameOfLifeConsole.Entities
{
    internal class Table
    {
        public readonly int maximumGenerations;

        private readonly int rows;
        private readonly int columns;

        public int Generation { get; private set; } = 1;

        public Cell[] Cells { get; set; }

        public Table(int rowLenght, int columnLeght, int maxGen, int start)
        {
            rows = rowLenght;
            columns = columnLeght;
            maximumGenerations = maxGen;

            Cells = new Cell[rows * columns];

            var arrayLenght = 0;

            var aliveCells = GenerateRandomCells(start);

            for (int x = 0; x < columns; x++)
                for (int y = 0; y < rows; y++)
                {
                    var alive = aliveCells.Any(pos => pos.Item1 == x &&
                                                      pos.Item2 == y);

                    Cells[arrayLenght] = new Cell(x, y, alive);

                    if (arrayLenght == Cells.Length - 1)
                        return;

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

        public List<Cell> GetNeighboringCells(Cell cell)
        {
            return new List<Cell>
            {
                // North
                Cells.FirstOrDefault(x => x.Row == (cell.Row - 1) && x.Column == (cell.Column - 1)),
                Cells.FirstOrDefault(x => x.Row == (cell.Row - 1) && x.Column == cell.Column),
                Cells.FirstOrDefault(x => x.Row == (cell.Row - 1) && x.Column == (cell.Column + 1)),
                
                Cells.FirstOrDefault(x => x.Row == cell.Row && x.Column == (cell.Column - 1)),
                Cells.FirstOrDefault(x => x.Row == cell.Row && x.Column == (cell.Column + 1)),
                
                // South
                Cells.FirstOrDefault(x => x.Row == (cell.Row + 1) && x.Column == (cell.Column - 1)),
                Cells.FirstOrDefault(x => x.Row == (cell.Row + 1) && x.Column == cell.Column),
                Cells.FirstOrDefault(x => x.Row == (cell.Row + 1) && x.Column == (cell.Column + 1))
            }
            .Where(c => c is not null)
            .ToList();
        }

        public void ProcessGeneration()
        {
            Cells.ToList().ForEach(cell => cell.ProcessCell(GetNeighboringCells(cell)));
            Cells.ToList().ForEach(cell => cell.NextGeneration());

            Generation++;
        }
    }
}
