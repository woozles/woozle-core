//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Diagnostics;
using System;
using System.Linq;
using System.Collections.Generic;
using Woozle.Model;
using Woozle.Model.SessionHandling;

namespace Woozle.Persistence.Repository
{
    public partial class TranslationRepository  : AbstractRepository<Translation>
    {
    
    	public TranslationRepository(IEfUnitOfWork Context) : base(Context)
    	{
    	}
    
    
    	 public override Translation Synchronize(Translation entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			
    			//Navigation Property 'Countries'
    			stopwatch.Start();
    			foreach(var n in entity.Countries.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Countries.Contains(n)) attachedObj.Countries.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Countries.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Countries", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'Functions'
    			stopwatch.Start();
    			foreach(var n in entity.Functions.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Functions.Contains(n)) attachedObj.Functions.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Functions.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Functions", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'Modules'
    			stopwatch.Start();
    			foreach(var n in entity.Modules.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Modules.Contains(n)) attachedObj.Modules.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Modules.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Modules", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'Status'
    			stopwatch.Start();
    			foreach(var n in entity.Status.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.Status.Contains(n)) attachedObj.Status.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.Status.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Status", stopwatch.ElapsedMilliseconds));
    			//Navigation Property 'TranslationItems'
    			stopwatch.Start();
    			foreach(var n in entity.TranslationItems.Where(n => n.PersistanceState == PState.Added))
    			{ 
    				if (!attachedObj.TranslationItems.Contains(n)) attachedObj.TranslationItems.Add(n);
    				if (n is IMandatorCapable)
    				{
    					n.MandatorId = session.SessionObject.Mandator.Id;
    				}
    			} 
    			foreach(var n in entity.TranslationItems.Where(n => n.PersistanceState == PState.Modified || n.PersistanceState == PState.Deleted))
    			{ 
    					Context.SynchronizeObject(n, session); 
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "TranslationItems", stopwatch.ElapsedMilliseconds));
    			return attachedObj; 
    		}
    	catch (Exception e)
    	{
    		this.Logger.Error(e.Message); 
    		throw new PersistenceException(PersistenceOperation.SYNCHRONIZE, e); 
    	} 
      } 
    	 public override void Delete(Translation entity, Session session) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			entity.PersistanceState = PState.Unchanged;
    			var attachedObj = Context.SynchronizeObject(entity, session);
    			
    			
    
    			//Navigation Property 'Countries'
    			stopwatch.Start();
    			Context.LoadCollection<Translation>(attachedObj.Id, "Countries");
    			foreach (var n in attachedObj.Countries.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Countries", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'Functions'
    			stopwatch.Start();
    			Context.LoadCollection<Translation>(attachedObj.Id, "Functions");
    			foreach (var n in attachedObj.Functions.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Functions", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'Modules'
    			stopwatch.Start();
    			Context.LoadCollection<Translation>(attachedObj.Id, "Modules");
    			foreach (var n in attachedObj.Modules.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Modules", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'Status'
    			stopwatch.Start();
    			Context.LoadCollection<Translation>(attachedObj.Id, "Status");
    			foreach (var n in attachedObj.Status.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "Status", stopwatch.ElapsedMilliseconds));
    
    			//Navigation Property 'TranslationItems'
    			stopwatch.Start();
    			Context.LoadCollection<Translation>(attachedObj.Id, "TranslationItems");
    			foreach (var n in attachedObj.TranslationItems.ToList())
    			{
    				n.PersistanceState = PState.Deleted;
    			    Context.SynchronizeObject(n, session);
    			} 
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Synchronize state of '{0}', took {1} ms", "TranslationItems", stopwatch.ElapsedMilliseconds));
    			attachedObj.PersistanceState = PState.Deleted;
    			attachedObj = Context.SynchronizeObject(attachedObj, session);
    			stopwatch.Start();
    			Context.Commit();
    			stopwatch.Stop();
    			this.Logger.Info(string.Format("Commit '{0}' Delete, took {1} ms", "Translation", stopwatch.ElapsedMilliseconds));
    		}
    	catch (Exception e)
    	{
    		this.Logger.Error(e.Message); 
    		throw new PersistenceException(PersistenceOperation.DELETE, e);  
    	} 
      } 
    
    }
    
}
