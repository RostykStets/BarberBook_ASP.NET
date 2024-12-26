using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<HistoryDto>> GetHistorys();
        Task<HistoryDto?> GetHistoryByID(int historyId);
        Task InsertHistory(HistoryDto historyDto);
        Task DeleteHistory(int historyId);
        Task UpdateHistory(HistoryDto historyDto);
    }
}
