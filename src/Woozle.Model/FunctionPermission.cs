//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace Woozle.Model
{
    [Serializable]
    public partial class FunctionPermission : WoozleObject
    {
        public FunctionPermission()
        {
            this.MandatorRoles = new ObservableCollection<MandatorRole>();
        }
    
        private int functionid;
        private int permissionid;
    
        public int FunctionId 
    	{ 
    		get { return this.functionid;} 
    		set { 
    			if(this.functionid != value)
    			{
    				this.functionid = value;
    			}
    		}
    	}
        public int PermissionId 
    	{ 
    		get { return this.permissionid;} 
    		set { 
    			if(this.permissionid != value)
    			{
    				this.permissionid = value;
    			}
    		}
    	}
    
    
    public virtual Function Function { get; set; }
    
    
    public virtual Permission Permission { get; set; }
    
    
    private ObservableCollection<MandatorRole> mandatorroles;
    
    public virtual ObservableCollection<MandatorRole> MandatorRoles 
    { 
    	get { return mandatorroles; } 
    	set
    	{
    		mandatorroles = value;
    	}
    }
    
    
    
    public override bool Equals(object obj)
    {
        if (this == obj)
            return true;
        if (obj == null)
            return false;
        if (GetType() != obj.GetType())
            return false;
    	//objects are equal when they are not new (Id != 0) and the Ids are equal
        WoozleObject other = (WoozleObject)obj;
        if (Id == 0 || Id != other.Id)
            return false;
        return true;
    }
    
    public override int GetHashCode()
    {
        int prime = 31;
    	int result = 1;
    	result = prime * result + Id;
    	return result;
    }
    }
    
}
