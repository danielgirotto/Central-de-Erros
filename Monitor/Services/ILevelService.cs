using Monitor.Models;
using System.Collections.Generic;

namespace Monitor.Services
{
    public interface ILevelService
    {
        IList<Level> SelectAll();
        Level Save(Level level);
    }
}
