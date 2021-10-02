using PracticalTest.Domain;
using PracticalTest.Domain.Entity;
using PracticalTest.Repositoy.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Repositoy.Repositories
{
    public class EthnicityRepository : GenericRepository<Ethnicity>, IEthnicityRepository
    {
        public EthnicityRepository(ApplicaitonDbContext context) : base(context)
        {

        }
    }
}
