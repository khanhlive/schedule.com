using schedule.data.designPatterns.adapters;
using schedule.data.erpExtensions;
using schedule.data.erps.systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.businessObject
{
    public class MenuProvider
    {
        public IEnumerable<SYS_SUBSYSTEM_EXTEND> GetMainMenu(string moduleid)
        {
            using (SYS_SUBSYSTEM sys_subsystem=new SYS_SUBSYSTEM())
            {
                var data = sys_subsystem.GetSubSystemBySystemId(moduleid);
                List<SYS_SUBSYSTEM_EXTEND> _EXTENDs = new List<SYS_SUBSYSTEM_EXTEND>();
                foreach (SYS_SUBSYSTEM sub in data)
                {
                    if (string.IsNullOrEmpty(sub.ParentID)||string.IsNullOrWhiteSpace(sub.ParentID))
                    {
                        SysSubSystemToSysSubSystemExtendAdapter sysSubSystemToSys = new SysSubSystemToSysSubSystemExtendAdapter(sub); 
                        _EXTENDs.Add(sysSubSystemToSys.GetSYS_SUBSYSTEM_EXTEND());
                    }
                }
                foreach (SYS_SUBSYSTEM_EXTEND subex in _EXTENDs)
                {
                    subex.Sys_SubSystems.AddRange(data.Where(p => p.ParentID == subex.SubSystemID.ToString()));
                }
                return _EXTENDs;
            }
        }
        public IEnumerable<SYS_SUBSYSTEM_EXTEND> GetMainMenu(List<SYS_SUBSYSTEM> data)
        {
            using (SYS_SUBSYSTEM sys_subsystem = new SYS_SUBSYSTEM())
            {
               // var data = new  //sys_subsystem.GetSubSystemBySystemId(moduleid);
                List<SYS_SUBSYSTEM_EXTEND> _EXTENDs = new List<SYS_SUBSYSTEM_EXTEND>();
                foreach (SYS_SUBSYSTEM sub in data.Where(p=> string.IsNullOrEmpty(p.ParentID) || string.IsNullOrWhiteSpace(p.ParentID)))
                {
                        SysSubSystemToSysSubSystemExtendAdapter sysSubSystemToSys = new SysSubSystemToSysSubSystemExtendAdapter(sub);
                        _EXTENDs.Add(sysSubSystemToSys.GetSYS_SUBSYSTEM_EXTEND());
                }
                foreach (SYS_SUBSYSTEM_EXTEND subex in _EXTENDs)
                {
                    subex.Sys_SubSystems.AddRange(data.Where(p => p.ParentID == subex.SubSystemID.ToString()));
                }
                return _EXTENDs;
            }
        }
        public IEnumerable<SYS_SUBSYSTEM_EXTEND> GetMainMenu2(List<SYS_SUBSYSTEM> data)
        {
            using (SYS_SUBSYSTEM sys_subsystem = new SYS_SUBSYSTEM())
            {
                // var data = new  //sys_subsystem.GetSubSystemBySystemId(moduleid);
                List<SYS_SUBSYSTEM_EXTEND> _EXTENDs = new List<SYS_SUBSYSTEM_EXTEND>();
                foreach (SYS_SUBSYSTEM sub in data.Where(p => string.IsNullOrEmpty(p.ParentID) || string.IsNullOrWhiteSpace(p.ParentID)))
                {
                    if (string.IsNullOrEmpty(sub.ParentID) || string.IsNullOrWhiteSpace(sub.ParentID))
                    {
                        SysSubSystemToSysSubSystemExtendAdapter sysSubSystemToSys = new SysSubSystemToSysSubSystemExtendAdapter(sub);
                        _EXTENDs.Add(sysSubSystemToSys.GetSYS_SUBSYSTEM_EXTEND2());
                    }
                }
                foreach (SYS_SUBSYSTEM_EXTEND subex in _EXTENDs)
                {
                    subex.Sys_SubSystems.AddRange(data.Where(p => p.ParentID == subex.SubSystemID.ToString()));
                }
                return _EXTENDs;
            }
        }
    }
}
