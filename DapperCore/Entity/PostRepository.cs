using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using EFP48.DapperCore.Entity;

public class PostRepository : IRepository<Post>
{
    private readonly DapperContext _context;

    public PostRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Post>> GetAllAsync()
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "SELECT * FROM Posts";
        return await db.QueryAsync<Post>(sql);
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "SELECT * FROM Posts WHERE Id = @Id";
        return await db.QueryFirstOrDefaultAsync<Post>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(Post post)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = @"
            INSERT INTO Posts (Title, Content, UserId)
            VALUES (@Title, @Content, @UserId);
            SELECT CAST(SCOPE_IDENTITY() as int);";

        return await db.ExecuteScalarAsync<int>(sql, post);
    }

    public async Task<int> UpdateAsync(Post post)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = @"
            UPDATE Posts
            SET Title = @Title,
                Content = @Content,
                UserId = @UserId
            WHERE Id = @Id";

        return await db.ExecuteAsync(sql, post);
    }

    public async Task<int> DeleteAsync(int id)
    {
        using IDbConnection db = _context.CreateConnection();
        string sql = "DELETE FROM Posts WHERE Id = @Id";
        return await db.ExecuteAsync(sql, new { Id = id });
    }
}
