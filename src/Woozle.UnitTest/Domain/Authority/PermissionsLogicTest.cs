﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Moq;
using Woozle.Domain.Authority;
using Woozle.Model;
using Woozle.Model.ModulePermissions;
using Woozle.Model.SessionHandling;
using Woozle.Persistence;
using Xunit;

namespace Woozle.UnitTest.Domain.Authority
{
    public class PermissionsLogicTest
    {
        private Role Role { get; set; }
        private Session Session { get; set; }
        private Mock<IRepository<User>> UserRepositoryMock { get; set; } 
        private Mock<IRepository<MandatorRole>> MandatorRoleRepositoryMock { get; set; }
        private Mock<IRepository<FunctionPermission>> FunctionPermissionRepositoryMock { get; set; }
        private Mock<IUnitOfWork> UnitOfWorkMock { get; set; }
        private readonly PermissionsLogic permissionsLogic;
        private readonly IQueryable<User> userList;

        public PermissionsLogicTest()
        {
            Role = new Role();
            Session = new Session(Guid.Empty, new SessionData(null, new Model.Mandator() {Id = 1}), DateTime.Now);
            MandatorRoleRepositoryMock = new Mock<IRepository<MandatorRole>>();
            FunctionPermissionRepositoryMock = new Mock<IRepository<FunctionPermission>>();
            this.UserRepositoryMock = new Mock<IRepository<User>>();

            UnitOfWorkMock = new Mock<IUnitOfWork>(MockBehavior.Strict);

            this.permissionsLogic = new PermissionsLogic(this.MandatorRoleRepositoryMock.Object,
                                                         this.FunctionPermissionRepositoryMock.Object,
                                                         this.UserRepositoryMock.Object);

            userList = new List<User>
                       {
                    new User
                        {
                            Id = 1,
                            Username = "Testuser",
                            UserMandatorRoles = new ObservableCollection<UserMandatorRole>
                                {
                                    new UserMandatorRole
                                        {
                                            MandatorRole = new MandatorRole
                                                {
                                                    Id = 1,
                                                    MandId = 5,
                                                }
                                        },
                                    new UserMandatorRole
                                        {
                                            MandatorRole = new MandatorRole
                                                {
                                                    Id = 2,
                                                    MandId = 2,
                                                    FunctionPermissions = new ObservableCollection<FunctionPermission>()
                                                        {

                                                            new FunctionPermission
                                                                {
                                                                    Id = 1,
                                                                    Function = new Function
                                                                        {
                                                                            Id = 44
                                                                        },
                                                                    Permission = new Permission
                                                                        {
                                                                            Id = 55
                                                                        }
                                                                },

                                                            new FunctionPermission
                                                                {
                                                                    Id = 2,
                                                                    Function = new Function
                                                                        {
                                                                            Id = 22
                                                                        },
                                                                    Permission = new Permission
                                                                        {
                                                                            Id = 88
                                                                        }
                                                                },

                                                            new FunctionPermission
                                                                {
                                                                    Id = 3,
                                                                    Function = new Function
                                                                        {
                                                                            Id = 55
                                                                        },
                                                                    Permission = new Permission
                                                                        {
                                                                            Id = 11
                                                                        }
                                                                }
                                                        }
                                                }
                                        },
                                    new UserMandatorRole
                                        {
                                            MandatorRole = new MandatorRole
                                                {
                                                    Id = 3,
                                                    MandId = 45
                                                }
                                        }
                                }
                        },
                    new User
                        {
                            Id = 2,
                            Username = "Testuser",
                            UserMandatorRoles = new ObservableCollection<UserMandatorRole>
                                {
                                    new UserMandatorRole
                                        {
                                            MandatorRole = new MandatorRole
                                                {
                                                    Id = 1,
                                                    MandId = 5,
                                                }
                                        }
                                }
                        }
                }.AsQueryable();
        }

        [Fact]
        public void SaveAddedPermissionsTest()
        {
            var mandatorRole = new MandatorRole { Id = 1 };
            var mandatorRoles = new List<MandatorRole> { mandatorRole };

            UnitOfWorkMock.Setup(n => n.Commit());

            MandatorRoleRepositoryMock.Setup(
                n => n.FindByExp(It.IsAny<Func<MandatorRole, bool>>(), Session, It.IsAny<string>())).Returns(
                    mandatorRoles);

            MandatorRoleRepositoryMock.Setup(n => n.Save(mandatorRole, It.IsAny<Session>()));
            MandatorRoleRepositoryMock.Setup(n => n.UnitOfWork).Returns(UnitOfWorkMock.Object);

            var changedRecord1 = new ChangedModulePermission { FunctionPermissionId = 1 , HasPermission = true};
            var functionPermission1 = new FunctionPermission() {Id = 1};
            var changedRecord2 = new ChangedModulePermission { FunctionPermissionId = 2 , HasPermission = true};
            var functionPermission2 = new FunctionPermission() {Id = 2};

            var changedPermissions = new List<ChangedModulePermission>();
            changedPermissions.Add(changedRecord1);
            changedPermissions.Add(changedRecord2);

            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord1.FunctionPermissionId)).Returns(
                functionPermission1);
            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord2.FunctionPermissionId)).Returns(
                functionPermission2);

            var logic = new PermissionsLogic(this.MandatorRoleRepositoryMock.Object,
                                             this.FunctionPermissionRepositoryMock.Object, null);
            logic.SaveChangedPermissions(Role, changedPermissions, Session);

            Assert.Equal(2, mandatorRole.FunctionPermissions.Count);
            Assert.Equal(functionPermission1.Id, mandatorRole.FunctionPermissions[0].Id);
            Assert.Equal(functionPermission2.Id, mandatorRole.FunctionPermissions[1].Id);
        }

        [Fact]
        public void SaveRemovedPermissionsTest()
        {
            var functionPermission1 = new FunctionPermission() { Id = 1 };
            var functionPermission2 = new FunctionPermission() { Id = 2 };

            var mandatorRole = new MandatorRole { Id = 1 };
            mandatorRole.FunctionPermissions = new ObservableCollection<FunctionPermission>();
            mandatorRole.FunctionPermissions.Add(functionPermission1);
            mandatorRole.FunctionPermissions.Add(functionPermission2);

            var mandatorRoles = new List<MandatorRole> { mandatorRole };

            UnitOfWorkMock.Setup(n => n.Commit());

            MandatorRoleRepositoryMock.Setup(
                n => n.FindByExp(It.IsAny<Func<MandatorRole, bool>>(), Session, It.IsAny<string>())).Returns(
                    mandatorRoles);

            MandatorRoleRepositoryMock.Setup(n => n.Save(mandatorRole, It.IsAny<Session>()));
            MandatorRoleRepositoryMock.Setup(n => n.UnitOfWork).Returns(UnitOfWorkMock.Object);

            var changedRecord1 = new ChangedModulePermission { FunctionPermissionId = 1 , HasPermission = false};
            var changedRecord2 = new ChangedModulePermission { FunctionPermissionId = 2, HasPermission = false };

            var changedPermissions = new List<ChangedModulePermission>();
            changedPermissions.Add(changedRecord1);
            changedPermissions.Add(changedRecord2);

            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord1.FunctionPermissionId)).Returns(
                functionPermission1);
            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord2.FunctionPermissionId)).Returns(
                functionPermission2);

            var logic = new PermissionsLogic(this.MandatorRoleRepositoryMock.Object,
                                             this.FunctionPermissionRepositoryMock.Object, null);
            logic.SaveChangedPermissions(Role, changedPermissions, Session);

            Assert.Equal(0, mandatorRole.FunctionPermissions.Count);
        }

        [Fact]
        public void SaveMixedPermissionsTest()
        {
            var functionPermission1 = new FunctionPermission() { Id = 1 };
            var functionPermission2 = new FunctionPermission() { Id = 2 };

            var mandatorRole = new MandatorRole { Id = 1 };
            mandatorRole.FunctionPermissions = new ObservableCollection<FunctionPermission>();
            mandatorRole.FunctionPermissions.Add(functionPermission1);

            var mandatorRoles = new List<MandatorRole> { mandatorRole };

            UnitOfWorkMock.Setup(n => n.Commit());

            MandatorRoleRepositoryMock.Setup(
                n => n.FindByExp(It.IsAny<Func<MandatorRole, bool>>(), Session, It.IsAny<string>())).Returns(
                    mandatorRoles);

            MandatorRoleRepositoryMock.Setup(n => n.Save(mandatorRole, It.IsAny<Session>()));
            MandatorRoleRepositoryMock.Setup(n => n.UnitOfWork).Returns(UnitOfWorkMock.Object);

            var changedRecord1 = new ChangedModulePermission { FunctionPermissionId = 1, HasPermission = false};
            var changedRecord2 = new ChangedModulePermission { FunctionPermissionId = 2 , HasPermission = true};

            var changedPermissions = new List<ChangedModulePermission>();
            changedPermissions.Add(changedRecord1);
            changedPermissions.Add(changedRecord2);

            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord1.FunctionPermissionId)).Returns(
                functionPermission1);
            FunctionPermissionRepositoryMock.Setup(n => n.QueryPrimaryKey(changedRecord2.FunctionPermissionId)).Returns(
                functionPermission2);

            var logic = new PermissionsLogic(this.MandatorRoleRepositoryMock.Object,
                                             this.FunctionPermissionRepositoryMock.Object, null);
            logic.SaveChangedPermissions(Role, changedPermissions, Session);

            Assert.Equal(1, mandatorRole.FunctionPermissions.Count);
            Assert.Equal(functionPermission2.Id, mandatorRole.FunctionPermissions[0].Id);
        }

        [Fact]
        public void GetAssignedPermissionsTest()
        {
            var sessionUser = new User
                {
                    Id = 1
                };

            var sessionData = new SessionData(sessionUser, new Model.Mandator() {Id = 2});

            this.Session = new Session(Guid.NewGuid(), sessionData, DateTime.Now.AddDays(1));

            this.UserRepositoryMock.Setup(n => n.CreateQueryable(It.IsAny<Session>()))
                .Returns(userList);

            var result = this.permissionsLogic.GetAssignedPermissions(this.Session.SessionObject);

            Assert.Equal(3, result.Count);
        }


        [Fact]
        public void GetAssignedPermissionsNoPermissionsForMandatorTest()
        {
            var sessionUser = new User
            {
                Id = 1
            };

            var sessionData = new SessionData(sessionUser, new Model.Mandator() { Id = 5 });

            this.Session = new Session(Guid.NewGuid(), sessionData, DateTime.Now.AddDays(1));

            this.UserRepositoryMock.Setup(n => n.CreateQueryable(It.IsAny<Session>()))
                .Returns(userList);

            var result = this.permissionsLogic.GetAssignedPermissions(this.Session.SessionObject);

            Assert.Equal(0, result.Count);
        }

        [Fact]
        public void GetAssignedPermissionsNoPermissionsForUserTest()
        {
            var sessionUser = new User
            {
                Id = 2
            };

            var sessionData = new SessionData(sessionUser, new Model.Mandator() { Id = 2 });

            this.Session = new Session(Guid.NewGuid(), sessionData, DateTime.Now.AddDays(1));

            this.UserRepositoryMock.Setup(n => n.CreateQueryable(It.IsAny<Session>()))
                .Returns(userList);

            var result = this.permissionsLogic.GetAssignedPermissions(this.Session.SessionObject);

            Assert.Equal(0, result.Count);
        }
    }
}
