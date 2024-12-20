using System.Globalization;
using CsvHelper;

namespace EtlCsv.Extractors;

class CsvTransportationExtractor : IExtractor<Transportation>
{
    private readonly StreamReader _streamReader;
    private readonly CsvReader _reader;
    private readonly string _duplicatesFilePath;

    public CsvTransportationExtractor(StreamReader streamReader, CsvReader reader, string duplicatesFilePath)
    {
        _reader = reader;
        _duplicatesFilePath = duplicatesFilePath;
        _streamReader = streamReader;
    }
    
    public IEnumerable<Transportation> Extract()
    {
        var duplicates = new List<Transportation>();
        var hashSet = new HashSet<Transportation>();
        
        _reader.Read();
        _reader.ReadHeader();
        
        while (_reader.Read())
        {
            Transportation transportation;
            
            try
            {
                transportation = _reader.GetRecord<Transportation>();
                
                transportation.StoreAndFwdFlag = transportation.StoreAndFwdFlag == "N" ? "No" : "Yes";
                transportation.DropoffDateTime = transportation.DropoffDateTime.ToUniversalTime();
                transportation.PickupDateTime = transportation.PickupDateTime.ToUniversalTime();
                
                if (!hashSet.Add(transportation))
                {
                    duplicates.Add(transportation);
                    continue;
                }
            }
            catch (CsvHelper.TypeConversion.TypeConverterException e)
            {
                continue;
            }

            yield return transportation;
        }
        
        WriteDuplicatesToCsv(duplicates);
    }

    public bool HasMoreData()
    {
        return !_streamReader.EndOfStream;
    }
    
    private void WriteDuplicatesToCsv(IEnumerable<Transportation> duplicates)
    {
        using var writer = new StreamWriter(_duplicatesFilePath);
        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
        
        var duplicatesList = duplicates.ToList();
        csv.WriteRecords(duplicatesList);
        
        Console.WriteLine($"Removed {duplicatesList.Count} duplicates");
    }
}