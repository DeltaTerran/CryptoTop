using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTop.Classes
{
    public class Configuration
    {
        public string AppKey { get; set; }
    }
    public class ConfigRoot
    {
        public Configuration configuration;
    }
}
