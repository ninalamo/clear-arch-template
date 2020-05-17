using lib.common.interfaces;

namespace application
{
    public abstract class BaseAuditor : ITakeCredit
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}