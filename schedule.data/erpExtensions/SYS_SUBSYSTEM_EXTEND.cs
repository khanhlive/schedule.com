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
        public List<SYS_SUBSYSTEM> Sys_SubSystems;

        public bool HasChild()
        {
            return this.Sys_SubSystems.Count > 0;
        }
    }
}
