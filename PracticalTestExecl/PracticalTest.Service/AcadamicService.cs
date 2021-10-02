using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service
{
    public class AcadamicService : IAcadamicService
    {
        private readonly IAcadamicService acadamicService;

        public AcadamicService(IAcadamicService acadamicService)
        {
            this.acadamicService = acadamicService;
        }

    }
}
