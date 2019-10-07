using System;
using System.Collections.Generic;
using System.Text;

namespace domain.interfaces
{
    public interface ICreditable
    {
        string CreatedBy { get; set; }
        string ModifiedBy { get; set; }
    }
}
