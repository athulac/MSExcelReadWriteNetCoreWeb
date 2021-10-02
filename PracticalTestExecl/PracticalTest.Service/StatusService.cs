using PracticalTest.Domain.Entity;
using PracticalTest.Repositoy.Repositories.Interfaces;
using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            this.statusRepository = statusRepository;
        }

        public async Task<List<Status>> GetAll()
        {
            var res = statusRepository.GetAllAsync();
            if (!res.Any())
            {
                return new List<Status> { };
            }
            return res.ToList();
        }
    }
}
