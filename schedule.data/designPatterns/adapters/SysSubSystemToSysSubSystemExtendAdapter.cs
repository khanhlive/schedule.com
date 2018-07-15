using schedule.data.erpExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace schedule.data.designPatterns.adapters
{
    public class SysSubSystemToSysSubSystemExtendAdapter
    {
        private erps.systems.SYS_SUBSYSTEM _subsystem;
        public SysSubSystemToSysSubSystemExtendAdapter(erps.systems.SYS_SUBSYSTEM _subsystem)
        {
            this._subsystem = _subsystem;
        }
        public SysSubSystemToSysSubSystemExtendAdapter()
        {
        }
        public void SetSubSystem(erps.systems.SYS_SUBSYSTEM _subsystem)
        {
            this._subsystem = _subsystem;
        }
        public SYS_SUBSYSTEM_EXTEND GetSYS_SUBSYSTEM_EXTEND()
        {
            SYS_SUBSYSTEM_EXTEND _EXTEND = new SYS_SUBSYSTEM_EXTEND();
            
            foreach (PropertyInfo p in this._subsystem.GetType().GetProperties())
            {
                _EXTEND.GetType().GetProperty(p.Name).SetValue(_EXTEND, p.GetValue(this._subsystem));
            }
            return _EXTEND;
        }
        public SYS_SUBSYSTEM_EXTEND GetSYS_SUBSYSTEM_EXTEND2()
        {
            SYS_SUBSYSTEM_EXTEND _EXTEND = new SYS_SUBSYSTEM_EXTEND();
            _EXTEND.Description = _subsystem.Description;
            _EXTEND.EditVersion = _subsystem.EditVersion;
            _EXTEND.GroupSystem_ID = _subsystem.GroupSystem_ID;
            _EXTEND.ParentID = _subsystem.ParentID;
            _EXTEND.SortOrder= _subsystem.SortOrder;
            _EXTEND.SubSystemCode = _subsystem.SubSystemCode;
            _EXTEND.SubSystemID = _subsystem.SubSystemID;
            _EXTEND.SubSystemName = _subsystem.SubSystemName;
            _EXTEND.SystemType = _subsystem.SystemType;

            return _EXTEND;
        }
    }
}
