namespace SimulatorEventStream;
public class EventRecord
{
    public long Identifier { get; set; }
    public long EventTs { get; set; }
    public string Payload { get; set; }
    public int Checksum { get; set; }
}