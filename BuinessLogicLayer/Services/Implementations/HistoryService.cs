using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }

        public async Task<List<HistoryDto>> GetHistorys()
        {
            var histories = await _historyRepository.GetHistorys();
            var historiesDtos = from history in histories
                                select new HistoryDto(history);
            return historiesDtos.ToList();
        }

        public async Task<HistoryDto?> GetHistoryByID(int historyId)
        {
            History? history = await _historyRepository.GetHistoryByID(historyId);
            HistoryDto? historyDto = null;
            if (history != null)
            {
                historyDto = new HistoryDto(history);
            }
            return historyDto;
        }

        public async Task InsertHistory(HistoryDto historyDto)
        {
            History history = historyDto.ToEntity();
            await _historyRepository.InsertHistory(history);
        }

        public async Task DeleteHistory(int historyId)
        {
            await _historyRepository.DeleteHistory(historyId);
        }

        public async Task UpdateHistory(HistoryDto historyDto)
        {
            History history = historyDto.ToEntity();
            await _historyRepository.UpdateHistory(history);
        }
    }
}
