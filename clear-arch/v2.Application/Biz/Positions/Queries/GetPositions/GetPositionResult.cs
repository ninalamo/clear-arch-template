using System.Collections.Generic;

namespace Core.Application
{
    public class PositionsDTO
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public class GetPositionResult
        {
            public IEnumerable<PositionsDTO> Positions { get; set; }
        }
    }
}