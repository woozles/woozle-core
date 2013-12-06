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
using Woozle.Core.Model;

namespace Woozle.Model
{
    [Serializable]
    public partial class Mandator : WoozleObject, IManagedConcurrency
    {
        public Mandator()
        {
            this.Modules = new FixupCollection<Module>();
            this.Locations = new FixupCollection<Location>();
            this.MandatorRoles = new FixupCollection<MandatorRole>();
            this.People = new FixupCollection<Person>();
            this.Settings = new FixupCollection<Setting>();
        }
    
        private string name;
        private string street;
        private string phone;
        private Nullable<int> cityid;
        private byte[] changecounter;
        private string email;
        private byte[] picture;
        private Nullable<int> mandatorgroupid;
    
        public string Name 
    	{ 
    		get { return this.name;} 
    		set { 
    			if(this.name != value)
    			{
    				this.name = value;
    				OnPropertyChanged("Name");
    			}
    		}
    	}
        public string Street 
    	{ 
    		get { return this.street;} 
    		set { 
    			if(this.street != value)
    			{
    				this.street = value;
    				OnPropertyChanged("Street");
    			}
    		}
    	}
        public string Phone 
    	{ 
    		get { return this.phone;} 
    		set { 
    			if(this.phone != value)
    			{
    				this.phone = value;
    				OnPropertyChanged("Phone");
    			}
    		}
    	}
        public Nullable<int> CityId 
    	{ 
    		get { return this.cityid;} 
    		set { 
    			if(this.cityid != value)
    			{
    				this.cityid = value;
    				OnPropertyChanged("CityId");
    			}
    		}
    	}
        public byte[] ChangeCounter 
    	{ 
    		get { return this.changecounter;} 
    		set { 
    			if(this.changecounter != value)
    			{
    				this.changecounter = value;
    				OnPropertyChanged("ChangeCounter");
    			}
    		}
    	}
        public string Email 
    	{ 
    		get { return this.email;} 
    		set { 
    			if(this.email != value)
    			{
    				this.email = value;
    				OnPropertyChanged("Email");
    			}
    		}
    	}
        public byte[] Picture 
    	{ 
    		get { return this.picture;} 
    		set { 
    			if(this.picture != value)
    			{
    				this.picture = value;
    				OnPropertyChanged("Picture");
    			}
    		}
    	}
        public Nullable<int> MandatorGroupId 
    	{ 
    		get { return this.mandatorgroupid;} 
    		set { 
    			if(this.mandatorgroupid != value)
    			{
    				this.mandatorgroupid = value;
    				OnPropertyChanged("MandatorGroupId");
    			}
    		}
    	}
    
    
    private FixupCollection<Module> modules;
    
    public virtual FixupCollection<Module> Modules 
    { 
    	get { return modules; } 
    	set
    	{
    		modules = value;
    		if(value != null)
    		{
    			Modules.CollectionChanged += OnCollectionChanged;
    		}
    	}
    }
    
    
    private FixupCollection<Location> locations;
    
    public virtual FixupCollection<Location> Locations 
    { 
    	get { return locations; } 
    	set
    	{
    		locations = value;
    		if(value != null)
    		{
    			Locations.CollectionChanged += OnCollectionChanged;
    		}
    	}
    }
    
    
    public virtual City City { get; set; }
    
    
    private FixupCollection<MandatorRole> mandatorroles;
    
    public virtual FixupCollection<MandatorRole> MandatorRoles 
    { 
    	get { return mandatorroles; } 
    	set
    	{
    		mandatorroles = value;
    		if(value != null)
    		{
    			MandatorRoles.CollectionChanged += OnCollectionChanged;
    		}
    	}
    }
    
    
    private FixupCollection<Person> people;
    
    public virtual FixupCollection<Person> People 
    { 
    	get { return people; } 
    	set
    	{
    		people = value;
    		if(value != null)
    		{
    			People.CollectionChanged += OnCollectionChanged;
    		}
    	}
    }
    
    
    private FixupCollection<Setting> settings;
    
    public virtual FixupCollection<Setting> Settings 
    { 
    	get { return settings; } 
    	set
    	{
    		settings = value;
    		if(value != null)
    		{
    			Settings.CollectionChanged += OnCollectionChanged;
    		}
    	}
    }
    
    
    public virtual MandatorGroup MandatorGroup { get; set; }
    
    
    public event PropertyChangedEventHandler LocalPropertyChanged;
    private event EventHandler AnyPropertyChanged;
    
    protected void OnPropertyChanged(String propertyName)
    {
    	if (this.LocalPropertyChanged != null)
        {
            this.LocalPropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
    	OnPropertyChanged("Collection");
    }
    
    public void HandleLocalPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    	this.PersistanceState = PState.Modified;
    	AnyPropertyChanged(sender, e);
    }
    
    public void HandleAnyPropertyChanged(object sender, EventArgs e)
    {
    	this.Dirty = true;
    }
    
    public override void ActivatePropertyChangedEvent(bool resetPersistenceState)
    {
    	ActivatePropertyChangedEvent(resetPersistenceState, HandleAnyPropertyChanged);
    }
    
    public void ActivatePropertyChangedEvent(bool resetPersistenceState, EventHandler anyPropertyChangedHandler)
    {
    	if (this.LocalPropertyChanged == null && this.AnyPropertyChanged == null)
    	{
    		if(resetPersistenceState) 
    		{
    			this.PersistanceState = PState.Unchanged;
    			this.Dirty = false;
    		}
    
    		this.LocalPropertyChanged += HandleLocalPropertyChanged;
            this.AnyPropertyChanged += anyPropertyChangedHandler;
    		if(Modules != null)
    		{
    			foreach(var n in Modules) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    		if(Locations != null)
    		{
    			foreach(var n in Locations) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    
    		if(City != null)
    		{
    			City.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    		}
    
    		if(MandatorRoles != null)
    		{
    			foreach(var n in MandatorRoles) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    		if(People != null)
    		{
    			foreach(var n in People) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    		if(Settings != null)
    		{
    			foreach(var n in Settings) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    
    		if(MandatorGroup != null)
    		{
    			MandatorGroup.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    		}
    
    	}
    }
    
    public override void DeactivatePropertyChangedEvent()
    {
    	if(this.LocalPropertyChanged != null && this.AnyPropertyChanged != null) 
    	{
    		this.LocalPropertyChanged = null;
    		this.AnyPropertyChanged = null;
    		foreach(var n in Modules) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in Locations) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		if(City != null)
    		{
    			City.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in MandatorRoles) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in People) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in Settings) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		if(MandatorGroup != null)
    		{
    			MandatorGroup.DeactivatePropertyChangedEvent();
    		}
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
