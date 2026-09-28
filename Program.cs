using System;
using System.Data;
using System.Data.OleDb;

// TODO: Refactor to a ConverterHostPlugin (see ChromaImporter/README.md).
// This is a standalone prototype that reads Chroma ATE Access DB (.mdb) files
// and prints their content to stdout. It uses the legacy Microsoft.Jet.OLEDB.4.0
// provider which requires a 32-bit process and .NET Framework.

namespace Virinco.WATS.Converter.Chroma.Importer
{
    class Program
    {
        // Replace with the actual path to a Chroma ATE .mdb file.
        const string DefaultFilePath = @"Data\chroma-sample.mdb";

        static void Main(string[] args)
        {
            string filePath = args.Length > 0 ? args[0] : DefaultFilePath;
            string connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={filePath};";

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("Connection successful!");

                    DataSet dataSet = new DataSet();
                    string query = "SELECT * FROM HeadInfoSet";
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    adapter.Fill(dataSet, "HeadInfoSet");

                    foreach (DataRow row in dataSet.Tables["HeadInfoSet"].Rows)
                    {
                        Console.WriteLine(string.Join(", ", row.ItemArray));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
