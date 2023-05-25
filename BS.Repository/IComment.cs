
namespace BS.Repository
{

    using BS.Models;
    using System.Collections.Generic;

    public interface IComment : IRepository<Comment>
    {
        IEnumerable<Comment> ListCommentByBookId(int id);
    }
}
