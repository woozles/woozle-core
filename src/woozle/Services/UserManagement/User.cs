//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using ServiceStack;
using Woozle.Model;

namespace Woozle.Services.UserManagement
{
    [Serializable]
    [Route("/users", "POST,PUT,DELETE")]
    [Route("/users/{Id}")]
    public partial class User : WoozleDto, IReturn<UserResponse>, IReturn<SaveResult<User>>, IReturnVoid
    {
        public User()
        {
            this.UserMandatorRoles = new FixupCollection<UserMandatorRole>();
        }
    
        public string Username { get; set; }
        public string Password { get; set; }
        public bool FlagActive { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> LastPasswordChange { get; set; }
        public int LanguageId { get; set; }
        public int FlagActiveStatusId { get; set; }
        public byte[] ChangeCounter { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    
        public Language Language { get; set; }
        public Status Status { get; set; }
        public FixupCollection<UserMandatorRole> UserMandatorRoles { get; set; }
    
    }

    public class UserResponse
    {
        public User User { get; set; }
    }
    
}
