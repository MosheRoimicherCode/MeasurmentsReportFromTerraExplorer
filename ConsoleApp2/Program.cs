using GeneratePdf;

internal class Program
{
    private static void Main(string[] args)
    {
        GenerateReport generateReport = new GenerateReport();
        Console.WriteLine("Hello, World!");
        generateReport.GenerateFakeDataReport();
    }
}