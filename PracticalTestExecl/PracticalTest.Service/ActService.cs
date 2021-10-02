using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service
{
    public class ActService : IActService
    {
        private readonly IActService actService;

        public ActService(IActService actService)
        {
            this.actService = actService;
        }
    }
}
