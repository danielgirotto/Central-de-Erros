using Monitor.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly MonitorContext _context;

        public EnvironmentService(MonitorContext context)
        {
            _context = context;
        }

        public Environment Save(Environment environment)
        {
            _context.Add(environment);
            _context.SaveChanges();

            return environment;
        }

        public IList<Environment> SelectAll()
        {
            return _context.Environments.ToList();
        }
    }
}
