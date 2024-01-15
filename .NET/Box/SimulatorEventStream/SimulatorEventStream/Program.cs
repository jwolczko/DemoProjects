namespace SimulatorEventStream;

internal class Program
{
    static void Main(string[] args)
    {
        string csvFilePath = args[0];

        if(string.IsNullOrEmpty(csvFilePath) ) 
        {
            Console.WriteLine("Path to CSV file cannot be empty!");
            return;
        }

        if(!File.Exists(csvFilePath))
        {
            Console.WriteLine($"File '{csvFilePath}' doesn't exist!");
            return;
        }

        var events = EventParser.ParseCSV(csvFilePath);
        EventProcessor processor = new();

        SimulateEventStream(events, processor);

        Console.ReadLine(); // Keep console open
    }

    static void SimulateEventStream(IEnumerable<EventRecord> events, EventProcessor processor)
    {
        foreach (var record in processor.ProcessEvents(events))
        {
            Console.WriteLine(record);
        }        
    }
}
