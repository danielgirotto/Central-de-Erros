using Monitor.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Services
{
    public class ErrorService : IErrorService
    {
        private readonly MonitorContext _context;

        public ErrorService(MonitorContext context)
        {
            _context = context;
        }

        public IList<Error> FindByEnvironmentId(int environmentId)
        {
            return _context.Errors
                .Where(x => x.EnvironmentId == environmentId)
                .ToList();
        }

        public IList<Error> FindByEnvironmentIdAndDescription(int environmentId, string description)
        {
            return _context.Errors
                .Where(x => x.EnvironmentId == environmentId && x.Description == description)
                .ToList();
        }

        public IList<Error> FindByEnvironmentIdAndLevelName(int environmentId, string levelName)
        {
            return
                (from erro in _context.Errors
                 join level in _context.Levels on erro.LevelId equals level.Id
                 where level.Name == levelName
                 select erro).ToList();
        }

        public IList<Error> FindByEnvironmentIdAndOrigin(int environmentId, string origin)
        {
            return _context.Errors
                .Where(x => x.EnvironmentId == environmentId && x.Origin == origin)
                .ToList();
        }

        public Error FindById(int id)
        {
            return _context.Errors.Find(id);
        }

        public Error Save(Error error)
        {
            _context.Add(error);
            _context.SaveChanges();

            return error;
        }
    }
}
