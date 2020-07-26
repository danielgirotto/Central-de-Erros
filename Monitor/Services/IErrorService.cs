using Monitor.Models;
using System.Collections.Generic;

namespace Monitor.Services
{
    public interface IErrorService
    {
        Error FindById(int id);
        IList<Error> FindByEnvironmentId(int environmentId);
        IList<Error> FindByEnvironmentIdAndLevelName(int environmentId, string levelName);
        IList<Error> FindByEnvironmentIdAndDescription(int environmentId, string description);
        IList<Error> FindByEnvironmentIdAndOrigin(int environmentId, string origin);
        Error Save(Error error);
    }
}
