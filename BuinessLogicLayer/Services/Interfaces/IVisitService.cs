using BusinessLogicLayer.DTOs;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IVisitService
    {
        Task<IEnumerable<VisitDto>> GetVisits();
        Task<IEnumerable<VisitDto>> GetVisitsByBarberId(string fk_BarberId);
        Task<VisitDto?> GetVisitByID(int visitId);
        Task InsertVisit(VisitDto visitDto);
        Task DeleteVisit(int visitId);
        Task UpdateVisit(VisitDto visitDto);
    }
}
