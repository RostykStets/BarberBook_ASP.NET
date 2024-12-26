using BusinessLogicLayer.DTOs;
using DataAccessLayer.Entities;

namespace BarberLayered.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string? fk_ClientId { get; set; }
        public string fk_BarberId { get; set; }
        public int fk_ServiceId { get; set; }
        public string VisitorFullName { get; set; }
        public string ServiceTitle { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public Visit()
        {
            Id = 0;
            fk_ClientId = "";
            fk_BarberId = "";
            fk_ServiceId = 0;
            Date = new DateOnly();
            VisitorFullName = "";
            ServiceTitle = "";
            StartTime = new TimeOnly();
            EndTime = new TimeOnly();
        }

        public Visit(VisitExtDto visitExtDto)
        {
            Id = visitExtDto.Id;
            fk_ClientId = visitExtDto.fk_ClientId;
            fk_BarberId = visitExtDto.fk_BarberId;
            fk_ServiceId = visitExtDto.fk_ServiceId;
            VisitorFullName = visitExtDto.VisitorFullName;
            ServiceTitle = visitExtDto.ServiceTitle;
            Date = visitExtDto.Date;
            StartTime = visitExtDto.StartTime;
            EndTime = visitExtDto.EndTime;
        }
    }
}
