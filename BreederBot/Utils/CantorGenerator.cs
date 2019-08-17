using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BreederBot.Utils
{
   public class CantorGenerator
    {
        public readonly int CantorPair;
        public CantorGenerator(int x, int y)
        {
            CantorPair = (((x + y) * (x + y + 1)) / 2) + y;
        }

    }
}
