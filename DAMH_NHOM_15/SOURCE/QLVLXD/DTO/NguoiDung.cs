using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public NguoiDung()
        {
            this.User = string.Empty;
            this.Pass = string.Empty;
        }
        public NguoiDung(string user, string pass)
        {
            this.Pass = pass;
            this.User = user;
        }
    }
}
