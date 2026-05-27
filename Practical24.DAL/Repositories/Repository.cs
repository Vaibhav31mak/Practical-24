namespace Practical24.DAL.Repositories;

// Sealed Generic Repository class Implementation
public sealed class Repository<T>(DbContext context) : IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        //var entity = await _dbSet.FindAsync(id, cancellationToken);
        var entity = await _dbSet.FirstOrDefaultAsync
            (e => EF.Property<int>(e, "Id") == id
            && EF.Property<bool>(e, "Status"), cancellationToken);

        return entity;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync
        (CancellationToken cancellationToken = default)
    {
        var query = _dbSet.AsNoTracking();
        if (typeof(IStatusCheck).IsAssignableFrom(typeof(T)))
        {
            query = query.Where(entity => EF.Property<bool>
                        (entity, nameof(IStatusCheck.Status)));
        }
        return await query.ToListAsync(cancellationToken);
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        => await _dbSet.AddAsync(entity, cancellationToken);

    public void Update(T entity)
        => _dbSet.Update(entity);

    public void Remove(T entity)
    {
        if (entity is IStatusCheck statusCheck)
        {
            statusCheck.Status = false;
            _dbSet.Update(entity);
            return;
        }

        _dbSet.Remove(entity);
    }
}
