using DataAccessLayer.Entities;

namespace BusinessLogicLayer.DTOs
{
    public class VisitDto
    {
        public int Id { get; set; }
        public string? fk_ClientId { get; set; }
        public int? fk_GuestId { get; set; }
        public string fk_BarberId { get; set; }
        public int fk_ServiceId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }

        public VisitDto() 
        {
            Id = 0;
            fk_ClientId = null;
            fk_GuestId = 0;
            fk_BarberId = "";
            fk_ServiceId = 0;
            Date = new DateOnly();
            Time = new TimeOnly();
        }

        public VisitDto(Visit visit) 
        {
            Id = visit.Id;
            fk_ClientId = visit.fk_ClientId;
            fk_GuestId = visit.fk_GuestId;
            fk_BarberId = visit.fk_BarberId;
            fk_ServiceId = visit.fk_ServiceId;
            Date = visit.Date;
            Time = visit.Time;
        }

        public Visit ToEntity()
        {
            Visit visit = new Visit()
            {
                Id = this.Id,
                fk_ClientId = this.fk_ClientId,
                fk_GuestId = this.fk_GuestId,
                fk_BarberId = this.fk_BarberId,
                fk_ServiceId = this.fk_ServiceId,
                Date = this.Date,
                Time = this.Time
            };

            return visit;
        }
    }
}
