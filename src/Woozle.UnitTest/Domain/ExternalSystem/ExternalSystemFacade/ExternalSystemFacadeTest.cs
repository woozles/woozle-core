﻿using System;
using System.ComponentModel.Composition.Hosting;
using Moq;
using Woozle.Model;
using Woozle.Model.SessionHandling;
using Woozle.Persistence;
using Woozle.UnitTest.Domain.ExternalSystem.Testdata;
using Woozle.Domain.ExternalSystem.ExternalSystemFacade;
using Xunit;


namespace Woozle.UnitTest.Domain.ExternalSystem.ExternalSystemFacade
{
    public class ExternalSystemFacadeTest
    {
        public const string TypeId = "TestType";
        public const string ExternalServiceId = "TestSystemV1";
        public Session session;

        [Fact]
        public void GetExternalSystemTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
                                                                                       {
                                                                                           MandatorId = 2
                                                                                       }), DateTime.Now.AddHours(2));

            var externalServiceRepositoryMock = new Mock<IExternalSystemRepository>();
            externalServiceRepositoryMock.Setup(n => n.FindServiceByMandantAndType(TypeId, session))
                                         .Returns(new Woozle.Model.ExternalSystem
                                                         {
                                                             ExternalSystemType = new ExternalSystemType
                                                                                       {
                                                                                           Id = 1,
                                                                                           MandatorId = 2,
                                                                                           Name = TypeId
                                                                                       },
                                                             ExternalSystemTypeId = 1,
                                                             Id = 1,
                                                             MandatorId = 2,
                                                             Name = ExternalServiceId
                                                         });
            var externalServiceFacade =
                new ExternalSystemFacade<IExternalTestSystem>(null, externalServiceRepositoryMock.Object,
                                                               new AssemblyCatalog(this.GetType().Assembly), TypeId);

            var foundSystem = externalServiceFacade.GetExternalSystem(session);

            var expectedSystem = new ExternalTestSystem();

            Assert.NotNull(foundSystem);
            Assert.Equal(typeof(ExternalTestSystem), foundSystem.GetType());
            Assert.Equal(expectedSystem.Test(1), foundSystem.Test(1));
            Assert.Equal(expectedSystem.Test(0), foundSystem.Test(0));
            Assert.NotEqual(expectedSystem.Test(1), foundSystem.Test(0));
        }

        [Fact]
        public void GetExternalSystemEmptyTypeIdTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
            {
                MandatorId = 2
            }), DateTime.Now.AddHours(2));

            var externalServiceRepositoryMock = new Mock<IExternalSystemRepository>();
            var externalServiceFacade =
                new ExternalSystemFacade<IExternalTestSystem>(null, externalServiceRepositoryMock.Object,
                                                               new AssemblyCatalog(this.GetType().Assembly), TypeId);

            var foundSystem = externalServiceFacade.GetExternalSystem(session);

            Assert.Null(foundSystem);
        }

        [Fact]
        public void GetExternalSystemTypeIdAsNullTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
            {
                MandatorId = 2
            }), DateTime.Now.AddHours(2));

            var externalServiceRepositoryMock = new Mock<IExternalSystemRepository>();
            var externalServiceFacade =
                new ExternalSystemFacade<IExternalTestSystem>(null, externalServiceRepositoryMock.Object,
                                                               new AssemblyCatalog(this.GetType().Assembly), TypeId);

            var foundSystem = externalServiceFacade.GetExternalSystem(session);

            Assert.Null(foundSystem);
        }

        [Fact]
        public void GetExternalSystemSessionIsNullTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
            {
                MandatorId = 2
            }), DateTime.Now.AddHours(2));

            var externalServiceRepositoryMock = new Mock<IExternalSystemRepository>();
            var externalServiceFacade =
                new ExternalSystemFacade<IExternalTestSystem>(null, externalServiceRepositoryMock.Object,
                                                               new AssemblyCatalog(this.GetType().Assembly), TypeId);

            var foundSystem = externalServiceFacade.GetExternalSystem(null);

            Assert.Null(foundSystem);
        }

        [Fact]
        public void GetExternalSystemWithANullableComposableCatalogTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
            {
                MandatorId = 2
            }), DateTime.Now.AddHours(2));

            var externalServiceRepositoryMock = new Mock<IExternalSystemRepository>();
            externalServiceRepositoryMock.Setup(n => n.FindServiceByMandantAndType(TypeId, session))
                                         .Returns(new Model.ExternalSystem
                                         {
                                             ExternalSystemType = new ExternalSystemType
                                             {
                                                 Id = 1,
                                                 MandatorId = 2,
                                                 Name = TypeId
                                             },
                                             ExternalSystemTypeId = 1,
                                             Id = 1,
                                             MandatorId = 2,
                                             Name = ExternalServiceId
                                         });
            var externalServiceFacade =
                new ExternalSystemFacade<IExternalTestSystem>(null, externalServiceRepositoryMock.Object,
                                                               new AssemblyCatalog(this.GetType().Assembly), TypeId);

            var foundSystem = externalServiceFacade.GetExternalSystem(session);

            var expectedSystem = new ExternalTestSystem();

            Assert.NotNull(foundSystem);
            Assert.Equal(typeof(ExternalTestSystem), foundSystem.GetType());
            Assert.Equal(expectedSystem.Test(1), foundSystem.Test(1));
            Assert.Equal(expectedSystem.Test(0), foundSystem.Test(0));
            Assert.NotEqual(expectedSystem.Test(1), foundSystem.Test(0));
        }

        [Fact]
        public void GetExternalSystemWithANullableExternalServiceRepositoryTest()
        {
            this.session = new Session(Guid.NewGuid(), new SessionData(new User(), new Model.Mandator
            {
                MandatorId = 2
            }), DateTime.Now.AddHours(2));

            Assert.Throws<ArgumentNullException>(() =>
            {
                var externalServiceFacade = new ExternalSystemFacade<IExternalTestSystem>(null, null, new AssemblyCatalog(this.GetType().Assembly), TypeId);
                externalServiceFacade.GetExternalSystem(session);
            });
        }
    }
}
