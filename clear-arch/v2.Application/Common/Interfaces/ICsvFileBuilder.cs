using System.Collections.Generic;

namespace Core.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildProductsFile(IEnumerable<object> records);
    }
}