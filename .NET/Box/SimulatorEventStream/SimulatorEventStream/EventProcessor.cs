namespace SimulatorEventStream;
public class EventProcessor
{
    private readonly int windowSize = 60; // 1 minute window size in seconds
    private List<EventRecord> Events { get; set; } = [];

    public IEnumerable<ProcessedEventRecord> ProcessEvents(IEnumerable<EventRecord> events)
    {
        foreach (var record in events)
        {
            // Validate checksum
            if (!ValidateChecksum(record))
            {
                yield return new ProcessedEventRecord {Identifier = record.Identifier, ChecksumValid = false };
            }

            Events.Add(record);
            Events.RemoveAll(e => e.EventTs < record.EventTs - windowSize);

            double average = Events.Average(e => e.Payload.Length);
            int max = Events.Max(e => e.Payload.Length);
            long windowEnd = Events.Max(e => e.EventTs);

            if (Events.Count == 0)
                continue;

            yield return new ProcessedEventRecord
            {
                Identifier = record.Identifier,
                Average = average,
                Max = max,
                WindowEnds = windowEnd,
                ChecksumValid = true
            };
        }
    }

    private bool ValidateChecksum(EventRecord newEvent)
    {
        int checksum = 0;

        foreach (char character in newEvent.Payload)
        {
            checksum += (int)character;
        }
        checksum %= 10;

        return checksum == newEvent.Checksum;
    }
}
