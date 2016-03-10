using Dapper;
using Domain;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Database.Broker
{
    public class AddressBroker
    {
        /// <summary>
        /// Returns the address with the specified id from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="id">The id of the address which is to be returned.</param>
        /// <returns></returns>
        public Address Get(IDbConnection connection, int id)
        {
            return connection.Query<Address>("SELECT * FROM address WHERE address_id = @id",
                new { id = id }).FirstOrDefault();
        }

        /// <summary>
        /// Returns all addresses from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <returns>All addresses currently stored in the database.</returns>
        public IEnumerable<Address> GetAll(IDbConnection connection)
        {
            return connection.Query<Address>("SELECT * FROM address").ToList();
        }

        /// <summary>
        /// Removes the object with the specified id from the database.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="id">The id of the object which is to be removed.</param>
        public void Delete(IDbConnection connection, int id)
        {
            connection.Query<Address>("DELETE FROM address WHERE id = @id",
                new { id = id });
        }

        private void Insert(IDbConnection connection, ref Address address)
        {
            int id = connection.Query<int>(@"INSERT address 
                VALUES (@id, @street, @housenumber, @zipcode, @city, @country); 
                SELECT LAST_INSERT_ID();", address).FirstOrDefault();
            address.Id = id;
        }

        private void Update(IDbConnection connection, Address address)
        {
            connection.Execute(@"UPDATE address SET 
                address_street = @street,
                address_housenumber = @housenumber,
                address_zipcode = @zipcode,
                address_city = @city,
                address_country = @country
                WHERE address_id = @id", address);
        }

        /// <summary>
        /// Either updates or inserts address into the database, depending if address.Id is
        /// set or not.
        /// </summary>
        /// <param name="connection">The database connection</param>
        /// <param name="address">The address to persist. If the address has not been persisted before, its Id is automatically set.</param>
        public void Save(IDbConnection connection, ref Address address)
        {
            if (address.Id == null)
            {
                Insert(connection, ref address);
            } else
            {
                Update(connection, address);
            }
        }
    }
}
