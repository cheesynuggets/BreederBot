using BreederBot.Models;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BreederBot.Services
{
    public unsafe class DataHandlingService
    {
        const string Dbfile = "BreederBot.db";
        const int CacheSaveIntervalMin = (1 * 1000) * 60;

        private readonly LiteDatabase _db;
        private System.Timers.Timer _timer;
        private Dictionary<ulong, Dictionary<string, List<DinoModel>>> cache;
        public DataHandlingService()
        {
            _db = new LiteDatabase(@"" + Dbfile);
            cache = new Dictionary<ulong, Dictionary<string, List<DinoModel>>>();
            loadCache();
            setTimer();

        }
        ~DataHandlingService()
        {
            _db.Dispose();

        }

        public void AddDino(ulong serverId, DinoModel dino) => addDino(ref cache, serverId, dino);

        private void addDino(ref Dictionary<ulong, Dictionary<string, List<DinoModel>>> cache, ulong serverId, DinoModel dino)
        {
            if(!cache.ContainsKey(serverId))
            {
                cache.Add(serverId, new Dictionary<string, List<DinoModel>>());
            }

            if(!cache[serverId].ContainsKey(dino.DinoType))
            {
                cache[serverId].Add(dino.DinoType, new List<DinoModel>() {dino});
            }

           
           if (!cache[serverId][dino.DinoType].Exists(c => c.uniqueID == dino.uniqueID))
           {
                cache[serverId][dino.DinoType].Add(dino);
                Console.WriteLine("adding");
           } else
            {
                var id = cache[serverId][dino.DinoType].FindIndex(c => c.uniqueID == dino.uniqueID);
                cache[serverId][dino.DinoType].Add(dino);
                cache[serverId][dino.DinoType].RemoveAt(id);
            }
            Console.WriteLine(cache[serverId].Count());
        }

        public void RemoveDino(ulong serverId, DinoModel dino) => removeDino(ref cache, serverId, dino);

        private void removeDino(ref Dictionary<ulong, Dictionary<string, List<DinoModel>>> cache, ulong serverId, DinoModel dino)
        {
            var index = cache[serverId][dino.DinoType].FindIndex(c => c.uniqueID == dino.uniqueID);

            if(index == -1)
            {
                return;
            }

            cache[serverId][dino.DinoType].RemoveAt(index);
        }
              

        Task<ServerModel> getServer(ulong id)
        {
          
        }

        void loadCache()
        {
            var servers = _db.GetCollection<ServerModel>();

           var allServers = servers.FindAll();

            foreach (var server in allServers)
            {
                var tempCache = new Dictionary<string, List<DinoModel>>();

                foreach (var dino in server.dinos)
                {
                    if(!tempCache.ContainsKey(dino.DinoType))
                    {
                        tempCache.Add(dino.DinoType, new List<DinoModel>() { dino });
                    } else
                    {
                        tempCache[dino.DinoType].Add(dino);
                    }
                }
                cache.Add(server.ServerID, tempCache);
                Console.WriteLine(cache.Count());
            }
            
        }
        Task saveCache()
        {
            var servers = _db.GetCollection<ServerModel>();

            foreach (var server in cache)
            {
                var tempServerModel = new ServerModel();
                tempServerModel.dinos = new List<DinoModel>();
                tempServerModel.ServerID = server.Key;

                foreach (var col in server.Value)
                {
                    foreach (var dino in col.Value)
                    {
                        tempServerModel.dinos.Add(dino);
                    }
                }

                servers.Upsert(tempServerModel);
            }
            Console.WriteLine("Cache stored into the database...");
            return Task.CompletedTask;
        }

        void setTimer()
        {
            _timer = new System.Timers.Timer();
            _timer.Elapsed += _timer_Elapsed;
            _timer.Interval = CacheSaveIntervalMin;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Task.Run(saveCache);
        }
    }
}
