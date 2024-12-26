using BusinessLogicLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Interfaces
{
    public interface IBarberHomeService
    {
        public Task<List<VisitExtDto>> GetVisitsByBarberId(string fk_BarberId);
    }
}
