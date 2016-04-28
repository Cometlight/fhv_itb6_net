using System.Collections.Generic;
using System.Data;
using Database;
using Database.Broker;
using Domain;

namespace Service
{
    public class CrudService<T> where T : class, IId
    {
        public T Get(int? id)
        {
            IBroker<T> broker = new Broker<T>();
            using (IDbConnection connection = new ConnectionManager().GetDbConnection())
            {
                return broker.Get(connection, id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            IBroker<T> broker = new Broker<T>();
            using (IDbConnection connection = new ConnectionManager().GetDbConnection())
            {
                return broker.GetAll(connection);
            }
        }

        public void Delete(int? id)
        {
            IBroker<T> broker = new Broker<T>();
            using (IDbConnection connection = new ConnectionManager().GetDbConnection())
            {
                broker.Delete(connection, id);
            }
        }

        public void Save(ref T obj)
        {
            IBroker<T> broker = new Broker<T>();
            using (IDbConnection connection = new ConnectionManager().GetDbConnection())
            {
                broker.Save(connection, ref obj);
            }
        }
    }
}
