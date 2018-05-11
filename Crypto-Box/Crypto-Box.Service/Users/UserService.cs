using CryptoBox.Repo;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CryptoBox.Service.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<Data.Models.Users> _repositoryUser;

        public UserService(IRepositoryBase<Data.Models.Users> repositoryUser)
        {
            _repositoryUser = repositoryUser;
        }

        public Data.Models.Users GetById(int id)
        {
            return _repositoryUser.GetById(id);
        }

        public Data.Models.Users GetByFilter(Expression<Func<Data.Models.Users, bool>> filter)
        {
            return _repositoryUser.GetByFilter(filter);
        }

        public void InsertUser(Data.Models.Users users)
        {
            _repositoryUser.Insert(users);
        }

        public void UpdateUser(Data.Models.Users users)
        {
            _repositoryUser.Update(users);
        }

        public void DeleteUser(Data.Models.Users users)
        {
            _repositoryUser.Remove(users);
        }
    }
}
