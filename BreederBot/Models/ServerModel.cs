using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Models
{
   public class ServerModel
   {
        [LiteDB.BsonId]
        public ulong ServerID { get; set; }
        public List<DinoModel> dinos { get; set;} 
   }
}
