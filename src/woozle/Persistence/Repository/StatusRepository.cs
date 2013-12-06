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
    public partial class StatusRepository  : AbstractRepository<Status>
    {
    
    	public StatusRepository(IEfUnitOfWork Context) : base(Context)
    	{
    	}
    
    
    	 public override Status Synchronize(Status entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			attachedObj.StatusField = Context.SynchronizeObject(entity.StatusField, session); 
    
    			attachedObj.Translation = Context.SynchronizeObject(entity.Translation, session); 
    
    			
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
    	 public override void Delete(Status entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			entity.PersistanceState = PState.Unchanged;
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			Context.SynchronizeObject(attachedObj.StatusField, session); 
    
    			Context.SynchronizeObject(attachedObj.Translation, session); 
    
    			
    
    			//Navigation Property 'People'
    			stopwatch.Start();
    			Context.LoadCollection<Status>(attachedObj.Id, "People");
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
    			this.Logger.Info(string.Format("Commit '{0}' Delete, took {1} ms", "Status", stopwatch.ElapsedMilliseconds));
    		}
    	catch (Exception e)
    	{
    		this.Logger.Error(e.Message); 
    		throw new PersistenceException(PersistenceOperation.DELETE, e);  
    	} 
      } 
    
    }
    
}
