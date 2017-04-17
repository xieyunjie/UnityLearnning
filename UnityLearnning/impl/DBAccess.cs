using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnityLearnning.impl
{
    public class DBAccess
    {
        private string _conn = "";
        public DBAccess(string conn)
        {

            this._conn = conn;
        }

        public void PrintConn()
        {
            Console.WriteLine(this._conn);
        }
    }
}
