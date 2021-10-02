using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service
{
    public class SatService : ISatService
    {
        private readonly ISatService satService;

        public SatService(ISatService satService)
        {
            this.satService = satService;
        }
    }
}
