using CsvHelper.Configuration;

namespace v2.Infrastructure.Files
{
    public sealed class ProductFileRecordMap : ClassMap<object>
    {
        public ProductFileRecordMap()
        {
            AutoMap();
            Map(m => m.UnitPrice).Name("Unit Price").ConvertUsing(c => (c.UnitPrice ?? 0).ToString("C"));
        }
    }
}
