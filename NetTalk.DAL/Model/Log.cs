using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Data.Objects;

namespace NetTalk.DAL.Model
{
    public class Log: ModelBase<TbLogs>
    {
        public ObjectQuery<VwLog> FindVw(string search, ObjectParameter[] param)
        {
            return ((IObjectContextAdapter) DB).ObjectContext.CreateObjectSet<VwLog>().Where(search, param);
        }
    }
}
