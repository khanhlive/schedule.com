using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.models
{
    public abstract class EntityBase
    {
        protected string _ConnectionString = ConfigurationManager.ConnectionStrings["ThoiKhoaBieu"].ConnectionString;
    }
}
