using Monitor.Models;
using System.Collections.Generic;

namespace Monitor.Services
{
    public interface IEnvironmentService
    {
        IList<Environment> SelectAll();
        Environment Save(Environment environment);
    }
}
