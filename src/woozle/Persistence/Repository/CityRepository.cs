//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics;
using Woozle.Core.Persistence.Repository;
using Woozle.Core.Model;
using System;
using System.Linq;
using System.Collections.Generic;
using Woozle.Core.Model.SessionHandling;
using Woozle.Core.Persistence.Impl;
using Woozle.Model;

namespace Woozle.Persistence.Repository
{
    public partial class CityRepository  : AbstractRepository<City>
    {
    
    	public CityRepository(IEfUnitOfWork Context) : base(Context)
    	{
    	}
    
    
    	 public override City Synchronize(City entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			
    			//Navigation Property 'Locations'
    			stopwatch.Start();
    			foreach(var n in entity.Locations.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Locations.Contains(n)) attachedObj.Locations.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Locations.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Locations", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'Mandators'
    			stopwatch.Start();
    			foreach(var n in entity.Mandators.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Mandators.Contains(n)) attachedObj.Mandators.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Mandators.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Mandators", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'People'
    			stopwatch.Start();
    			foreach(var n in entity.People.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.People.Contains(n)) attachedObj.People.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.People.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "People", stopwatch.ElapsedMilliseconds));
    			return attachedObj; 
    		}
    	catch (Exception e)
    	{
    		this.Logger.Error(e.Message); 
    		throw new PersistenceException(PersistenceOperation.SYNCHRONIZE, e); 
    	} 
      } 
    	 public override void Delete(City entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			entity.PersistanceState = PState.Unchanged;
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			
    
    			//Navigation Property 'Locations'
    			stopwatch.Start();
    			Context.LoadCollection<City>(attachedObj.Id, "Locations");
    			foreach (var n in attachedObj.Locations.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Locations", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'Mandators'
    			stopwatch.Start();
    			Context.LoadCollection<City>(attachedObj.Id, "Mandators");
    			foreach (var n in attachedObj.Mandators.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Mandators", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'People'
    			stopwatch.Start();
    			Context.LoadCollection<City>(attachedObj.Id, "People");
    			foreach (var n in attachedObj.People.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "People", stopwatch.ElapsedMilliseconds));
    			attachedObj.PersistanceState = PState.Deleted;
    			attachedObj = Context.SynchronizeObject(attachedObj, session);
    			stopwatch.Start();
    			Context.Commit();
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Commit '{0}' Delete, took {1} ms", "City", stopwatch.ElapsedMilliseconds));
    		}
    	catch (Exception e)
    	{
    		this.Logger.Error(e.Message); 
    		throw new PersistenceException(PersistenceOperation.DELETE, e);  
    	} 
      } 
    
    }
    
}
