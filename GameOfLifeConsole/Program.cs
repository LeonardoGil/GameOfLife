// See https://aka.ms/new-console-template for more information
using GameOfLifeConsole.Entities;
using System.Diagnostics;

var table = new Table(40, 60, 100, 250);
var groupRows = table.Cells.GroupBy(x => x.Row);
var stopWatch = new Stopwatch();

Console.WriteLine("Iniciando Jogo da Vida");
Console.WriteLine("Aperte Enter para começar...");
Console.Read();

do
{
    Console.Clear();
    Console.WriteLine($"Geração: {table.Generation} (Levou {stopWatch.ElapsedMilliseconds}ms){Environment.NewLine}");
    Show();

    stopWatch.Restart();
    stopWatch.Start();
    table.ProcessGeneration();
    stopWatch.Stop();

    Thread.Sleep(150);
} while (table.Generation <= table.maximumGenerations);

void Show()
{
    foreach (var rowGroup in groupRows)
    {
        Console.Write("| ");
        foreach (var row in rowGroup)
        {
            if (row.Alive)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("O");
        }
        Console.ResetColor();
        Console.Write(" |");
        Console.Write(Environment.NewLine);
    }
}