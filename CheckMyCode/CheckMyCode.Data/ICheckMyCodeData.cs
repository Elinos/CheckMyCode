using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckMyCode.Data
{
    public interface ICheckMyCodeData
    {
        //TODO: Add Repositories
        //IRepository<Comment> Comments { get; }
        int SaveChanges();
    }
}