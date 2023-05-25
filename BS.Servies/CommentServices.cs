using BS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BS.Repository;

namespace BS.Servies
{
    public class CommentServices
    {
        private IComment db;
        public CommentServices()
        {
            db = new CommentRepository(new DataAccessLayer.BookDbContext());
        }
        public int Insert(Comment t)
        {
            db.Insert(t);
            return db.Save();
        }
        public ICollection<Comment> GetAll()
        {
            return db.GetAll();
        }
        public IEnumerable<Comment> ListCommentByBookId(int id)
        {
            return db.ListCommentByBookId(id);
        }
    }
}
