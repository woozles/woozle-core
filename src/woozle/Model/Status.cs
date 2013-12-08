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
    public partial class Status : WoozleObject
    {
        public Status()
        {
            this.People = new FixupCollection<Person>();
        }
    
        private string value;
        private int statusfieldid;
        private int translationid;
    
        public string Value 
    	{ 
    		get { return this.value;} 
    		set { 
    			if(this.value != value)
    			{
    				this.value = value;
    				OnPropertyChanged("Value");
    			}
    		}
    	}
        public int StatusFieldId 
    	{ 
    		get { return this.statusfieldid;} 
    		set { 
    			if(this.statusfieldid != value)
    			{
    				this.statusfieldid = value;
    				OnPropertyChanged("StatusFieldId");
    			}
    		}
    	}
        public int TranslationId 
    	{ 
    		get { return this.translationid;} 
    		set { 
    			if(this.translationid != value)
    			{
    				this.translationid = value;
    				OnPropertyChanged("TranslationId");
    			}
    		}
    	}
    	
    	/// <summary>
        /// To use the translated value directly it needs to be filled explicit
        /// </summary>
        public string TranslatedValue 	{ get; set; }
    
    
    
    public virtual StatusField StatusField { get; set; }
    
    
    public virtual Translation Translation { get; set; }
    
    
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
    
    		if(StatusField != null)
    		{
    			StatusField.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
    		}
    
    
    		if(Translation != null)
    		{
    			Translation.ActivatePropertyChangedEvent(resetPersistenceState, anyPropertyChangedHandler);
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
    		if(StatusField != null)
    		{
    			StatusField.DeactivatePropertyChangedEvent();
    		}
    		if(Translation != null)
    		{
    			Translation.DeactivatePropertyChangedEvent();
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
