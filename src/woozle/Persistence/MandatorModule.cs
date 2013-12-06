//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Woozle.Model;

namespace Woozle.Persistence.Impl.Core
{
    public partial class MandatorModule
    {
        #region Primitive Properties
    
        public virtual int Id
        {
            get;
            set;
        }
    
        public virtual int ModuleId
        {
            get { return _moduleId; }
            set
            {
                if (_moduleId != value)
                {
                    if (Module != null && Module.Id != value)
                    {
                        Module = null;
                    }
                    _moduleId = value;
                }
            }
        }
        private int _moduleId;
    
        public virtual int MandatorId
        {
            get { return _mandatorId; }
            set
            {
                if (_mandatorId != value)
                {
                    if (Mandator != null && Mandator.Id != value)
                    {
                        Mandator = null;
                    }
                    _mandatorId = value;
                }
            }
        }
        private int _mandatorId;
    
        public virtual bool Activated
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual Mandator Mandator
        {
            get { return _mandator; }
            set
            {
                if (!ReferenceEquals(_mandator, value))
                {
                    var previousValue = _mandator;
                    _mandator = value;
                //    FixupMandator(previousValue);
                }
            }
        }
        private Mandator _mandator;
    
        public virtual Module Module
        {
            get { return _module; }
            set
            {
                if (!ReferenceEquals(_module, value))
                {
                    var previousValue = _module;
                    _module = value;
                //    FixupModule(previousValue);
                }
            }
        }
        private Module _module;

        #endregion
        #region Association Fixup
    
        //private void FixupMandator(Mandator previousValue)
        //{
        //    if (previousValue != null && previousValue.MandatorModules.Contains(this))
        //    {
        //        previousValue.MandatorModules.Remove(this);
        //    }
    
        //    if (Mandator != null)
        //    {
        //        if (!Mandator.MandatorModules.Contains(this))
        //        {
        //            Mandator.MandatorModules.Add(this);
        //        }
        //        if (MandatorId != Mandator.Id)
        //        {
        //            MandatorId = Mandator.Id;
        //        }
        //    }
        //}
    
        //private void FixupModule(Module previousValue)
        //{
        //    if (previousValue != null && previousValue.MandatorModules.Contains(this))
        //    {
        //        previousValue.MandatorModules.Remove(this);
        //    }
    
        //    if (Module != null)
        //    {
        //        if (!Module.MandatorModules.Contains(this))
        //        {
        //            Module.MandatorModules.Add(this);
        //        }
        //        if (ModuleId != Module.Id)
        //        {
        //            ModuleId = Module.Id;
        //        }
        //    }
        //}

        #endregion
    }
}
