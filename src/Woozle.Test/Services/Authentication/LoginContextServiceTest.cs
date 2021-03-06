﻿using System;
using Moq;
using Woozle.Domain.Location;
using Woozle.Model;
using Woozle.Model.SessionHandling;
using Woozle.Services;
using Woozle.Services.Authentication;
using Xunit;

namespace Woozle.Test.Services.Authentication
{
    public class LoginContextServiceTest : SessionTestBase
    {
        private readonly LoginContextService loginContextService;
        private readonly User user;
        private readonly Model.Mandator mandator;
        private Session session;

        public LoginContextServiceTest()
        {
            MappingConfiguration.Configure();

            user = new User();
            mandator = new Model.Mandator();
            var sessionData = new SessionData(user, mandator);
            session = new Session(sessionData);

            var requestContextMock = this.GetFakeRequestContext(session);

            loginContextService = new LoginContextService()
                {
                    RequestContext = requestContextMock
                };
        }

        [Fact]
        public void GetLoginContextOfLoggedInUserTest()
        {
            user.Username = "sha";
            mandator.Name = "mandator1";

            var result = loginContextService.Get(new LoginContext());

            Assert.NotNull(result.User);
            Assert.Equal(user.Username, result.User.Username);
            Assert.NotNull(result.Mandator);
            Assert.Equal(mandator.Name, result.Mandator.Name);
        }

        
    }
}
