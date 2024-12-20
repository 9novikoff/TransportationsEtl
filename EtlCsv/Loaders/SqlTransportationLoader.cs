using System.Data;
using Microsoft.Data.SqlClient;

namespace EtlCsv.Loaders;

public class SqlTransportationLoader : ILoader<Transportation>
{
    private readonly string _connectionString;

    public SqlTransportationLoader(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void Load(IEnumerable<Transportation> data)
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();

        using var bulkCopy = new SqlBulkCopy(connection);
        bulkCopy.DestinationTableName = "Transportation";

        var table = new DataTable();
        table.Columns.Add("PickupDateTime", typeof(DateTime));
        table.Columns.Add("DropoffDateTime", typeof(DateTime));
        table.Columns.Add("PassengerCount", typeof(int));
        table.Columns.Add("TripDistance", typeof(double));
        table.Columns.Add("StoreAndFwdFlag", typeof(string));
        table.Columns.Add("PULocationID", typeof(int));
        table.Columns.Add("DOLocationID", typeof(int));
        table.Columns.Add("FareAmount", typeof(decimal));
        table.Columns.Add("TipAmount", typeof(decimal));

        foreach (var record in data)
        {
            table.Rows.Add(
                record.PickupDateTime,
                record.DropoffDateTime,
                record.PassengerCount,
                record.TripDistance,
                record.StoreAndFwdFlag,
                record.PULocationID,
                record.DOLocationID,
                record.FareAmount,
                record.TipAmount
            );
        }
        
        bulkCopy.WriteToServer(table);
        
        Console.WriteLine($"Loaded {table.Rows.Count} unique rows");
    }
}