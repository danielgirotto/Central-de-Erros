using Monitor.Models;
using System.Collections.Generic;
using System.Linq;

namespace Monitor.Services
{
    public class LevelService : ILevelService
    {
        private readonly MonitorContext _context;

        public LevelService(MonitorContext context)
        {
            _context = context;
        }

        public Level Save(Level level)
        {
            _context.Add(level);
            _context.SaveChanges();

            return level;
        }

        public IList<Level> SelectAll()
        {
            return _context.Levels.ToList();
        }
    }
}
