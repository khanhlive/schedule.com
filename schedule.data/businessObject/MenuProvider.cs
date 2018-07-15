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
            using (SYS_SUBSYSTEM sys_subsystem = new SYS_SUBSYSTEM())
            {
                var data = sys_subsystem.GetSubSystemBySystemId(moduleid);
                if (data!=null)
                {
                    List<SYS_SUBSYSTEM_EXTEND> _EXTENDs = new List<SYS_SUBSYSTEM_EXTEND>();
                    foreach (SYS_SUBSYSTEM sub in data)
                    {
                        if (string.IsNullOrEmpty(sub.ParentID) || string.IsNullOrWhiteSpace(sub.ParentID))
                        {
                            SysSubSystemToSysSubSystemExtendAdapter sysSubSystemToSys = new SysSubSystemToSysSubSystemExtendAdapter(sub);
                            _EXTENDs.Add(sysSubSystemToSys.GetSYS_SUBSYSTEM_EXTEND());
                        }
                    }
                    foreach (SYS_SUBSYSTEM_EXTEND subex in _EXTENDs)
                    {
                        subex.Sys_SubSystems.AddRange(this.GetSYS_SUBSYSTEMs(subex.SubSystemID.ToString(), data));
                    }
                    return _EXTENDs;
                }
                else
                {
                    return new List<SYS_SUBSYSTEM_EXTEND>();
                }
            }
        }
        private IEnumerable<SYS_SUBSYSTEM_EXTEND> GetSYS_SUBSYSTEMs(string parentId, IEnumerable<SYS_SUBSYSTEM> source)
        {
            List<SYS_SUBSYSTEM_EXTEND> _EXTENDs = new List<SYS_SUBSYSTEM_EXTEND>();
            SysSubSystemToSysSubSystemExtendAdapter sysSubSystemToSys = new SysSubSystemToSysSubSystemExtendAdapter();
            foreach (SYS_SUBSYSTEM item in source.Where(p => p.ParentID == parentId))
            {
                sysSubSystemToSys.SetSubSystem(item);
                _EXTENDs.Add(sysSubSystemToSys.GetSYS_SUBSYSTEM_EXTEND());
            }
            if (_EXTENDs.Count() > 0)
            {
                foreach (SYS_SUBSYSTEM_EXTEND item in _EXTENDs)
                {
                    item.Sys_SubSystems.AddRange(this.GetSYS_SUBSYSTEMs(item.SubSystemID.ToString(), source));
                }
            }
            return _EXTENDs;

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
