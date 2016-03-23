using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Domain;
using Dommel;
using Dapper;

namespace Database.Broker
{
    public class Broker<T> : IBroker<T> where T : class, IID
    {
        /// <summary>
        /// Returns the object with the specified id from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="id">The id of the address which is to be returned.</param>
        /// <returns></returns>
        public T Get(IDbConnection connection, int id)
        {
            return connection.Get<T>(id);
        }

        /// <summary>
        /// Returns all objects of type T from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <returns>All objects of type T currently stored in the database.</returns>
        public IEnumerable<T> GetAll(IDbConnection connection)
        {
            return connection.GetAll<T>().ToList();
        }

        /// <summary>
        /// Removes the object with the specified id from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="id">The id of the object which is to be removed.</param>
        public void Delete(IDbConnection connection, int id)
        {
            T obj = connection.Get<T>(id);
            Delete(connection, obj);
        }

        /// <summary>
        /// Removes the objectfrom the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="obj">The object to be removed.</param>
        public void Delete(IDbConnection connection, T obj)
        {
            connection.Delete(obj);
        }

        private void Insert(IDbConnection connection, ref T obj)
        {
            // Domel has no valid implementation of MySQL of Insert() as of version 1.5
            // Hence, the following line does not work:
            // obj.Id = connection.Insert(obj);
            
            Type type = obj.GetType();
            string tableName = DommelMapper.Resolvers.Table(type);
            PropertyInfo keyProperty = DommelMapper.Resolvers.KeyProperty(type);
            List<PropertyInfo> typeProperties = DommelMapper.Resolvers.Properties(type).Where(p => p != keyProperty).ToList();

            string[] columnNames = typeProperties.Select(DommelMapper.Resolvers.Column).ToArray();
            string[] paramNames = typeProperties.Select(p => "@" + p.Name).ToArray();

            string sql = string.Format("INSERT {0} ({1}) VALUES ({2}); SELECT LAST_INSERT_ID();",
                tableName,
                string.Join(", ", columnNames),
                string.Join(", ", paramNames));

            obj.Id = connection.Query<int>(sql, obj).Single();
        }

        private void Update(IDbConnection connection, T obj)
        {
            connection.Update(obj);
        }

        /// <summary>
        /// Either updates or inserts address into the database, depending if address.Id is
        /// set or not.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="obj">The object to persist. If the object has not been persisted before, its Id is automatically set.</param>
        public void Save(IDbConnection connection, ref T obj)
        {
            if (obj.Id == null)
            {
                Insert(connection, ref obj);
            }
            else
            {
                Update(connection, obj);
            }
        }
    }
}
