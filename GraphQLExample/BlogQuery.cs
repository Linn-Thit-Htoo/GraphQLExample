using GraphQLExample.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLExample
{
    public class BlogQuery
    {
        public async Task<List<BlogDataModel>> GetBlogs([Service] AppDbContext _appDbContext, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                List<BlogDataModel> lst = await _appDbContext.Blogs
                    .OrderByDescending(x => x.Blog_Id)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
                return lst;
            }
            catch
            {
                throw;
            }
        }

        public async Task<string> CreateBlog([Service] AppDbContext _appDbContext, BlogDataModel blog)
        {
            try
            {
                await _appDbContext.Blogs.AddAsync(blog);
                int result = await _appDbContext.SaveChangesAsync();

                return result > 0 ? "Creating Successful." : "Creating Fail.";
            }
            catch
            {
                throw;
            }
        }
    }
}
