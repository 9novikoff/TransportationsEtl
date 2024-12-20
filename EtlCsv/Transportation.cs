namespace EtlCsv;

public class Transportation
{
    [CsvHelper.Configuration.Attributes.Name("tpep_pickup_datetime")]
    public DateTime PickupDateTime { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("tpep_dropoff_datetime")]
    public DateTime DropoffDateTime { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("passenger_count")]
    public int PassengerCount { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("trip_distance")]
    public double TripDistance { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("store_and_fwd_flag")]
    public string StoreAndFwdFlag { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("PULocationID")]
    public int PULocationID { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("DOLocationID")]
    public int DOLocationID { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("fare_amount")]
    public decimal FareAmount { get; set; }
    
    [CsvHelper.Configuration.Attributes.Name("tip_amount")]
    public decimal TipAmount { get; set; }
    
    public override bool Equals(object? obj)
    {
        if (obj is Transportation other)
        {
            return PickupDateTime == other.PickupDateTime &&
                   DropoffDateTime == other.DropoffDateTime &&
                   PassengerCount == other.PassengerCount;
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(PickupDateTime, DropoffDateTime, PassengerCount);
    }
}