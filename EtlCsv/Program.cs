using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using EtlCsv.Extractors;
using EtlCsv.Loaders;
using Microsoft.Data.SqlClient;

namespace EtlCsv;

class Program
{
    // TODO store in configuration files
    private const string TransportationsFilePath = "../../../sample-cab-data.csv";
    private const string DuplicatesFilePath = "../../../duplicates.csv";
    private const string ConnectionString = "Server=localhost;Database=TransportationsDB;Trusted_Connection=Yes;Encrypt=false;";
    
    static void Main(string[] args)
    {
        using var streamReader = new StreamReader(TransportationsFilePath);
        using var csvReader = new CsvReader(streamReader, new CsvConfiguration(CultureInfo.InvariantCulture) { TrimOptions = TrimOptions.Trim});
        
        var extractor = new CsvTransportationExtractor(streamReader, csvReader, DuplicatesFilePath);
        var loader = new SqlTransportationLoader(ConnectionString);

        var workflow = new EtlBuilder<Transportation>()
            .WithExtractor(extractor)
            .WithLoader(loader)
            .Build();

        workflow.Run();
    }
}