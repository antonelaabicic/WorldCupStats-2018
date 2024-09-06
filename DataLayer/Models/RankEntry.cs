using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class RankEntry
    {
        public int Rank { get; set; }
        public List<Player> Players { get; set; } = new List<Player>();
    }
}
