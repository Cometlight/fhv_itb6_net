using System.Collections.Generic;
using System.Data;
using Domain;

namespace Database.Broker
{
    public interface IBroker<T> where T : class, IId
    {
        void Delete(IDbConnection connection, T obj);
        void Delete(IDbConnection connection, int? id);
        T Get(IDbConnection connection, int? id);
        IEnumerable<T> GetAll(IDbConnection connection);
        void Save(IDbConnection connection, ref T obj);
    }
}