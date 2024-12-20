# Description
Test task for DevelopsToday

# Setup
1. Clone this repository and change directory
   ```
   git clone https://github.com/9novikoff/TransportationsEtl
   cd TransportationsEtl/EtlCsv
   ```
3. Ensure you have the required .NET SDK
4. Set up the SQL Server database by running the script.sql
5. Run
   ```
   dotnet run
   ```

# Architecture Overview
Application is designed with extensibility in mind.\
To facilitate future enhancements, I created interfaces and abstractions that allow for easy extension. \
For example, the CsvTransportationChunkExtractor should be implemented to handle the chunk-based processing of the CSV file.\

# Approach to handle large files
Since it is not feasible to store all transportation records in RAM,\
the application should process the file in chunks. Each chunk should be loaded, sorted\
individually, and then merged into a single sorted file to eliminate duplicates.\
Once the merged file is prepared, the application can extract and process the data chunk by chunk.\

# Results
Removed 111 duplicates\
Loaded 29840 unique rows
