using schedule.data.erps.systems;
using System.Collections.Generic;

namespace schedule.data.erpExtensions
{
    public class SYS_SUBSYSTEM_EXTEND : SYS_SUBSYSTEM
    {
        public SYS_SUBSYSTEM_EXTEND()
        {
            this.Sys_SubSystems = new List<SYS_SUBSYSTEM>();
        }
        public IEnumerable<SYS_SUBSYSTEM> Sys_SubSystems;
    }
}
