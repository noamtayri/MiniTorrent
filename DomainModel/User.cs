using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public List<TransferFile> OwnedFiles { get; set; }
        public bool EnableDisable { get; set; }        
    }
}
