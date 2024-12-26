using DataAccessLayer.Entities;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IVisitRepository
    {
        Task<IEnumerable<Visit>> GetVisits();
        Task<IEnumerable<Visit>> GetVisitsByBarberId(string fk_BarberId);
        Task<Visit?> GetVisitByID(int visitId);
        Task InsertVisit(Visit visit);
        Task DeleteVisit(int visitId);
        Task UpdateVisit(Visit visit);
        Task Save();
    }
}
