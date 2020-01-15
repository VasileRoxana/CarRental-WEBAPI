using System.Threading.Tasks;

namespace CarRental.Services.Interfaces
{
    public interface IBaseServices
    {
        Task CommitChanges();
    }
}
