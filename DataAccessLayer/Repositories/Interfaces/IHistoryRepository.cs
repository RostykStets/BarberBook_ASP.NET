using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task<IEnumerable<History>> GetHistorys();
        Task<History?> GetHistoryByID(int historyId);
        Task InsertHistory(History history);
        Task DeleteHistory(int historyId);
        Task UpdateHistory(History history);
        Task Save();
    }
}
