using Microsoft.VisualBasic.FileIO;

namespace SimulatorEventStream;
public class EventParser
{
    public static List<EventRecord> ParseCSV(string filePath)
    {
        List<EventRecord> records = new();

        using (TextFieldParser parser = new TextFieldParser(filePath))
        {
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");

            // Skip header
            parser.ReadLine();

            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                if(fields ==  null || fields.Length == 0)
                    continue;

                if (fields.Length == 4)
                {
                    EventRecord record = new EventRecord
                    {
                        Identifier = Convert.ToInt64(fields[0]),
                        EventTs = Convert.ToInt64(fields[1]),
                        Payload = fields[2],
                        Checksum = Convert.ToInt32(fields[3])
                    };

                    records.Add(record);
                }
            }
        }

        return records;
    }
}