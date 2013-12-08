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
    public partial class City : WoozleObject
    {
        public City()
        {
            this.Locations = new FixupCollection<Location>();
            this.Mandators = new FixupCollection<Mandator>();
            this.People = new FixupCollection<Person>();
        }
    
        private string zipcode;
        private string name;
        private int countryid;
    
        public string ZipCode 
    	{ 
    		get { return this.zipcode;} 
    		set { 
    			if(this.zipcode != value)
    			{
    				this.zipcode = value;
    				OnPropertyChanged("ZipCode");
    			}
    		}
    	}
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
        public int CountryId 
    	{ 
    		get { return this.countryid;} 
    		set { 
    			if(this.countryid != value)
    			{
    				this.countryid = value;
    				OnPropertyChanged("CountryId");
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
    
    
    private FixupCollection<Mandator> mandators;
    
    public virtual FixupCollection<Mandator> Mandators 
    { 
    	get { return mandators; } 
    	set
    	{
    		mandators = value;
    		if(value != null)
    		{
    			Mandators.CollectionChanged += OnCollectionChanged;
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
    		if(Locations != null)
    		{
    			foreach(var n in Locations) 
    			{
    				n.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    			}
    		}
    	
    
    		if(Mandators != null)
    		{
    			foreach(var n in Mandators) 
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
    	
    
    	}
    }
    
    public override void DeactivatePropertyChangedEvent()
    {
    	if(this.LocalPropertyChanged != null && this.AnyPropertyChanged != null) 
    	{
    		this.LocalPropertyChanged = null;
    		this.AnyPropertyChanged = null;
    		foreach(var n in Locations) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in Mandators) 
    		{
    			n.DeactivatePropertyChangedEvent();
    		}
    		foreach(var n in People) 
    		{
    			n.DeactivatePropertyChangedEvent();
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
