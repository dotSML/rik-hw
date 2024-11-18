using api.Domain.Repositories;

namespace api.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAttendeeRepository AttendeeRepository { get; }
        IEventRepository EventRepository { get; }
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task<int> SaveChangesAsync();
    }
}