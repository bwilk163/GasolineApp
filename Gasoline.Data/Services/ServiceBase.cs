using Gasoline.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gasoline.Data.Services
{
    public abstract class ServiceBase
    {
        protected readonly GasolineContext _context;

        public ServiceBase(GasolineContext context)
        {
            _context = context;
        }
    }
}