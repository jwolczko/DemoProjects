namespace SimulatorEventStream;

public class ProcessedEventRecord
{
    public long Identifier { get; set; }
    public long WindowEnds { get; set; }
    public double Average { get; set; }
    public long Max { get; set; }
    public bool ChecksumValid { get; set; }

    public override string ToString() => 
        ChecksumValid ? $"Event {Identifier}: average {Average:F2}, max {Max}, window ends {WindowEnds}" 
                      : $"Event {Identifier}: Invalid checksum";
    
}
