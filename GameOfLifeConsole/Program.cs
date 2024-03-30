// See https://aka.ms/new-console-template for more information
using GameOfLifeConsole.Entities;

var table = new Table(8, 8, 5);
var groupRows = table.Cells.GroupBy(x => x.Row);

do
{
    Show();

    table.ProcessGeneration();

} while (table.Generation <= table.maximumGenerations);

void Show()
{
    foreach (var row in groupRows)
    {
        var cells = row.Select(x => x.Alive ? "X" : "O");
        var line = "| " + string.Join(" | ", cells) + " |";

        Console.WriteLine(line);
    }
}