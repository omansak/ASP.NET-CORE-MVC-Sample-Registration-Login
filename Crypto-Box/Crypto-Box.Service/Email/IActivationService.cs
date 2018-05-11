using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CryptoBox.Service.Email
{
    public interface IActivationService
    {
        Data.Models.EmailValid GetByFilter(Expression<Func<Data.Models.EmailValid, bool>> filter);
        void Insert(Data.Models.EmailValid entity);
        void Delete(Data.Models.EmailValid entity);
    }
}
