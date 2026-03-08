using DomeGym.Domain.SessionAggregate;

namespace DomeGym.Domain.Common.Interfaces
{
    public interface ISessionRepository
    {
        Task AddSessionAsync(Session session);

        Task UpdateSessionAsync(Session session);
    }
}
