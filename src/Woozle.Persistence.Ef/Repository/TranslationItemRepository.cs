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

namespace Woozle.Persistence.Ef.Repository
{
    public partial class TranslationItemRepository  : AbstractRepository<TranslationItem>
    {
    
    	public TranslationItemRepository(IEfUnitOfWork Context) : base(Context)
    	{
    	}
    
    
    	 public override TranslationItem Synchronize(TranslationItem entity, SessionData sessionData) 
    	 { 
    		try
    		{
    			var stopwatch = new Stopwatch();
    			var attachedObj = Context.SynchronizeObject(entity, sessionData);
    			
    			attachedObj.Language = Context.SynchronizeObject(entity.Language, sessionData); 
    
    			attachedObj.Translation = Context.SynchronizeObject(entity.Translation, sessionData); 
    
    			
    			return attachedObj; 
    		}
    		catch (Exception e)
    		{
    			Trace.TraceError(e.Message); 
    			throw new PersistenceException(PersistenceOperation.SYNCHRONIZE, e); 
    		} 
         } 
    
    }
    
}
