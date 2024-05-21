using Client.Model.DatabaseViews;
using Client.Model.Entities;
using Client.SQLServer.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Client.Service
{
    public class ClientService
    {
        private readonly WebDbContext _db;
        public ClientService(WebDbContext db) { 
           this._db = db;
        }

       
        public long? LastInsertedClientId { get => this._db.Clients.OrderByDescending(x => x.Id).FirstOrDefault()?.Id; }
        public int AddClientAddress(AddressEntity address)
        {
            try
            {
               
               var clientAddressExists = this._db.Addresses.AsNoTracking().FirstOrDefault(x => x.Id == address.Id && x.ClientUniqueId == address.ClientUniqueId);
                if(clientAddressExists == null)
                {
                    var storeProcResult = this._db.Database.ExecuteSqlRaw(
                     "exec AddClientAddress @clientId, @addressDescription",
                      new SqlParameter("@clientId", address.ClientUniqueId),
                      new SqlParameter("@addressDescription", address.Description)
                     );
                    return  storeProcResult;
                }
                else
                {
                    this._db.Addresses.Update(address);
                    return this._db.SaveChanges();

                }
                

            }
            catch {
                return 0;
            }
        }

        public AddressEntity? GetClientAddress(long clientId)
        {
            try
            {
                return this._db.Addresses.FirstOrDefault(x => x.ClientUniqueId == clientId);
            }
            catch {
                return null;
            }
        }

        /// <summary>
        /// Create new or modify existing client
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int AddClient(ClientEntity client)
        {
            try
            {
                var storeProcResult = this._db.Database.ExecuteSqlRaw(
                    "exec CreateOrEditClient @clientId, @firstName, @lastName, @gender, @contact",
                     new SqlParameter("@clientId", client.Id),
                     new SqlParameter("@firstName", client.FirstName),
                     new SqlParameter("@lastName", client.LastName),
                     new SqlParameter("@gender", client.Gender),
                     new SqlParameter("@contact", client.ContactNumber)
                    );
               return storeProcResult;
               
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IEnumerable<ClientDetailsViewItem> GetAllClients()
        {
            try
            {
                
                var list  = this._db.ClientDetailsViewItems;
                return list.ToList() ?? new List<ClientDetailsViewItem>();
                
            }
            catch(Exception ex)
            {
                return Enumerable.Empty<ClientDetailsViewItem>();
            }
        }

        public ClientDetailsViewItem? GetClient(long clientId)
        {
            try
            {
                return this._db.Set<ClientDetailsViewItem>().FirstOrDefault(x => x.ClientUniqueId == clientId);
            }
            catch
            {
                return null;
            }
        }

        public int DeleteClient(long clientId)
        {
            try
            {
                var removedClientAddressLinks = this._db.Addresses.Where(x => x.ClientUniqueId == clientId);
                this._db.Addresses.RemoveRange(removedClientAddressLinks.ToList());
                var removedClient = this._db.Clients.FirstOrDefault(x => x.Id == clientId);
                if (removedClient != null)
                {
                    this._db.Clients.Remove(removedClient);
                }
                return this._db.SaveChanges();
            }
            catch
            {
                return 0;
            }
        }

    }
}
