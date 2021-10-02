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
    public class EthnicityService : IEthnicityService
    {
        private readonly IEthnicityRepository ethnicityRepository;

        public EthnicityService(IEthnicityRepository ethnicityRepository)
        {
            this.ethnicityRepository = ethnicityRepository;
        }

        public async Task<List<Ethnicity>> GetAll()
        {
            var res = ethnicityRepository.GetAllAsync();
            if (!res.Any())
            {
                return new List<Ethnicity> { };
            }
            return res.ToList();
        }
    }
}
