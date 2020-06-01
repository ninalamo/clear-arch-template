namespace Core.Domain.Common.Interfaces
{
    public interface IActive
    {
        bool IsActive { get; set; }
        void Deactivate();
    }
}
