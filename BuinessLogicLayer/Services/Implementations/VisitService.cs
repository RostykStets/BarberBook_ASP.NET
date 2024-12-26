using BusinessLogicLayer.DTOs;
using BusinessLogicLayer.Services.Interfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessLogicLayer.Services.Implementations
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;

        public VisitService(IVisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public async Task<IEnumerable<VisitDto>> GetVisits()
        {
            var visits = await _visitRepository.GetVisits();
            var visitsDtos = from visit in visits
                             select new VisitDto(visit);
            return visitsDtos.ToList();
        }

        public async Task<IEnumerable<VisitDto>> GetVisitsByBarberId(string fk_BarberId)
        {
            var visits = await _visitRepository.GetVisitsByBarberId(fk_BarberId);
            var visitsDtos = from visit in visits
                             select new VisitDto(visit);
            return visitsDtos.ToList();
        }

        public async Task<VisitDto?> GetVisitByID(int visitId)
        {
            Visit? visit = await _visitRepository.GetVisitByID(visitId);
            VisitDto? visitDto = null;
            if (visit != null)
            {
                visitDto = new VisitDto(visit);
            }
            return visitDto;
        }

        public async Task InsertVisit(VisitDto visitDto)
        {
            Visit visit = visitDto.ToEntity();
            await _visitRepository.InsertVisit(visit);
        }

        public async Task DeleteVisit(int visitId)
        {
            await _visitRepository.DeleteVisit(visitId);
        }

        public async Task UpdateVisit(VisitDto visitDto)
        {
            Visit visit = visitDto.ToEntity();
            await _visitRepository.UpdateVisit(visit);
        }
    }
}
