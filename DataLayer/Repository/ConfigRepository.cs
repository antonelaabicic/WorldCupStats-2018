using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class ConfigRepository
    {
        public bool UseApiRepository { get; set; }
        public bool UseFileRepository { get; set; }
    }
}
