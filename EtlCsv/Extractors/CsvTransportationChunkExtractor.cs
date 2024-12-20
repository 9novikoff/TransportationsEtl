namespace EtlCsv.Extractors;

/* TODO implement for chunk extraction
    Proposed approach: Since it is not feasible to store all transportation records in RAM,
    the application should process the file in chunks. Each chunk should be loaded, sorted
    individually, and then merged into a single sorted file to eliminate duplicates.
    Once the merged file is prepared, the application can extract and process the data chunk by chunk.
*/

public class CsvTransportationChunkExtractor : IExtractor<Transportation>
{
    public IEnumerable<Transportation> Extract()
    {
        throw new NotImplementedException();
    }

    public bool HasMoreData()
    {
        throw new NotImplementedException();
    }
}