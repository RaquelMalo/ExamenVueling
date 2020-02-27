using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiBusinessMen.Services.CheckConnection
{
    public interface ICheckConnection
    {
        Task<bool> Check(string url);
    }
}
