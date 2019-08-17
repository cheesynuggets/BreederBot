using BreederBot.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Services
{
    public class DataHandlingService
    {
        const string Dbfile = "BreederBot.db";
        private readonly LiteDatabase _db;
        public DataHandlingService()
        {
            _db = new LiteDatabase(@"" + Dbfile);
        }
        ~DataHandlingService()
        {
            _db.Dispose();
        }

        Task<ServerModel> GetServer(ulong id)
        {
            var servers = _db.GetCollection<ServerModel>();

            var server = servers.FindOne(c => c.ServerID == id);

            if(server == null)
            {
                server = new ServerModel { ServerID = id, dinos = new List<DinoModel>() };
                servers.Insert(server);
            }

            return Task.FromResult<ServerModel>(server);
        }
        
        Task UpdateServer(ulong id, ServerModel updatedServerModel)
        {
            var servers = _db.GetCollection<ServerModel>();
            servers.Upsert(id, updatedServerModel);

            return Task.CompletedTask;
        }

      public async Task AddDinoAsync(ulong serverId, DinoModel dinoModel)
        {
            var server = await GetServer(serverId);

           if (server.dinos.Exists(c => c.uniqueID == dinoModel.uniqueID))
           {
                server.dinos.RemoveAll(c => c.uniqueID == dinoModel.uniqueID);
                server.dinos.Add(dinoModel);
                return;
           }

            server.dinos.Add(dinoModel);

            UpdateServer(serverId, server);

            return;
        }

       public async Task<Task> RemoveDinoAsync (ulong serverId, int dinoId)
        {
            var server = await GetServer(serverId);

            server.dinos.RemoveAll(c => c.uniqueID == dinoId);
            UpdateServer(serverId, server);

            return Task.CompletedTask;
        }

    }
}
