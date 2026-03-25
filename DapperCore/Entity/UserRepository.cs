using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using EFP48.DapperCore.Entity;

public class UserRepository : IRepository<User>
{
    private readonly DapperContext _context;

    public UserRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "SELECT * FROM Users";
        return await db.QueryAsync<User>(sql);
    }

    public async Task<User> GetByIdAsync(int id)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "SELECT * FROM Users WHERE Id = @Id";
        return await db.QueryFirstOrDefaultAsync<User>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(User user)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = @"
            INSERT INTO Users (Username, Email)
            VALUES (@Username, @Email);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await db.ExecuteScalarAsync<int>(sql, user);
    }

    public async Task<int> UpdateAsync(User user)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = @"
            UPDATE Users
            SET Username = @Username,
                Email = @Email
            WHERE Id = @Id";

        return await db.ExecuteAsync(sql, user);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "DELETE FROM Users WHERE Id = @Id";
        return await db.ExecuteAsync(sql, new { Id = id });
    }
}