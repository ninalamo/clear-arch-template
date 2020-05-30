using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using v2.Application.Common.Interfaces;

namespace v2.Infrastructure.Files
{
    public class CsvFileBuilder : ICsvFileBuilder
    {
        //public byte[] BuildProductsFile(IEnumerable<object> records)
        //{
        //    using var memoryStream = new MemoryStream();
        //    using (var streamWriter = new StreamWriter(memoryStream))
        //    {
        //        using var csvWriter = new CsvWriter(streamWriter);
        //        csvWriter.Configuration.RegisterClassMap<ProductFileRecordMap>();
        //        csvWriter.WriteRecords(records);
        //    }

        //    return memoryStream.ToArray();
        //}
    }
}
