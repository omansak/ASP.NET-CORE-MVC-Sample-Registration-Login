using System;
using System.Linq.Expressions;

namespace CryptoBox.Service.Users
{
    public interface IUserService
    {
        
        Data.Models.Users GetById(int id);
        Data.Models.Users GetByFilter(Expression<Func<Data.Models.Users, bool>> filter);
        void InsertUser(Data.Models.Users users);
        void UpdateUser(Data.Models.Users users);
        void DeleteUser(Data.Models.Users users);
    }

}
