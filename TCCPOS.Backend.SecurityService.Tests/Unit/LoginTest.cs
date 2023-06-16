/*using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using TCCPOS.Backend.SecurityService.Application.Exceptions;
using TCCPOS.Backend.SecurityService.Entities;
using TCCPOS.Backend.SecurityService.Infrastructure.Repository;

namespace TCCPOS.Backend.SecurityService.Tests.Integration
{
    public class LoginTest
    {
        private DbContextOptions<SecurityContext> _dbcontextoptions;

        [SetUp]
        public void Setup()
        {
            var dbName = $"SecurityDb_{DateTime.Now.ToFileTimeUtc()}";
            _dbcontextoptions = new DbContextOptionsBuilder<SecurityContext>()
                    .UseInMemoryDatabase(dbName)
                    .Options;
        }

        private async Task<SecurityContext> GetContext()
        {
            var context = new SecurityContext(_dbcontextoptions);
            await context.useraccount.AddAsync(new useraccount { UserID = "b0a946bc-a8a8-4184-a821-9a68958a92eb", Login = "testuser1", Password = "password1", AuthType = "P", CreateBy = "", UpdateBy = "", IsActive = true });
            await context.useraccount.AddAsync(new useraccount { UserID = "27cd3d63-102b-4b73-a6c4-5aa77e786ca4", Login = "noposclient", Password = "password1", AuthType = "P", CreateBy = "", UpdateBy = "", IsActive = true });
            await context.useraccount.AddAsync(new useraccount { UserID = "5465c31d-eefe-466d-956c-f69c00f8a2d8", Login = "inactive", Password = "password1", AuthType = "P", CreateBy = "", UpdateBy = "", IsActive = false });
            await context.useraccount.AddAsync(new useraccount { UserID = "57e8651a-acab-4321-ac14-872c099ef2c9", Login = "system", Password = "password1", AuthType = "S", CreateBy = "", UpdateBy = "", IsActive = true });

            await context.userlogin.AddAsync(new userlogin { UserID = "b0a946bc-a8a8-4184-a821-9a68958a92eb", POSClientID = "6a40c6a3-7128-41de-88a6-f77fcd39c3c4" });
            await context.userlogin.AddAsync(new userlogin { UserID = "b0a946bc-a8a8-4184-a821-9a68958a92eb", POSClientID = "6cbd1ad6-d5aa-447f-89e4-a34a25026e81" });

            await context.posclient.AddAsync(new posclient { POSClientID = "6a40c6a3-7128-41de-88a6-f77fcd39c3c4", BranchID = "", MerchantID = "", POSRunning = "", FRPOSRunning = "", IsActive = true });
            await context.posclient.AddAsync(new posclient { POSClientID = "6cbd1ad6-d5aa-447f-89e4-a34a25026e81", BranchID = "", MerchantID = "", POSRunning = "", FRPOSRunning = "", IsActive = false });

            await context.SaveChangesAsync();
            return context;
        }

        private static LoginCommandHandler GetCommandHandler(SecurityContext context)
        {
            var repo = new SecurityRepository(context);
            var mocklog = new Mock<ILogger<LoginCommandHandler>>();
            var mockhandler = new LoginCommandHandler(mocklog.Object, repo);
            return mockhandler;
        }

        [Test]
        public async Task LoginSuccess()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "testuser1",
                Password = "password1",
                POSClientID = "6a40c6a3-7128-41de-88a6-f77fcd39c3c4",
                Version = "1.0.0",
                ConfigJWTValidIssuer = "issuer",
                ConfigJWTValidAudience = "audience",
                ConfigJWTSecret = "configjwtsecretconfigjwtsecret"
            };

            var actual = await mockhandler.Handle(command, default(CancellationToken));

            Assert.That(actual.Username, Is.EqualTo("testuser1"));

            var ua = await context.useractivity.FirstOrDefaultAsync();
            Assert.True(ua != null);
            Assert.That(ua?.POSClientID, Is.EqualTo(command.POSClientID));
            Assert.That(ua?.Activity, Is.EqualTo("Login"));
            Assert.That(ua?.Note1, Is.EqualTo("1.0.0"));
        }

        [Test]
        public async Task LoginButNoPosClient()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "noposclient", // user คนนี้ไม่มี posclient อะไรเลย
                Password = "password1",
                POSClientID = "6a40c6a3-7128-41de-88a6-f77fcd39c3c4",
                Version = "1.0.0",
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE005.Code));
        }

        [Test]
        public async Task LoginButNotBelongInThisPosClient()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "testuser1",
                Password = "password1",
                POSClientID = "df4ec622-624c-4155-a179-6fabbd137d9f", // posclientid ที่ไม่มีอยู่ในระบบ
                Version = "1.0.0",
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE006.Code));
        }

        [Test]
        public async Task LoginWithInactivePosClient()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "testuser1",
                Password = "password1",
                POSClientID = "6cbd1ad6-d5aa-447f-89e4-a34a25026e81", // posclientid inactive
                Version = "1.0.0",
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE008.Code));
        }

        [Test]
        public async Task LoginUserNotFound()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "testuser2",
                Password = "password1"
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE001.Code));
        }

        [Test]
        public async Task LoginIncorrectPassword()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "testuser1",
                Password = "password2"
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE002.Code));
        }

        [Test]
        public async Task LoginThatInactive()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "inactive",
                Password = "password1"
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE003.Code));
        }

        [Test]
        public async Task LoginViaSystemAccount()
        {
            var context = await GetContext();
            var mockhandler = GetCommandHandler(context);

            var command = new LoginCommand()
            {
                Username = "system",
                Password = "password1"
            };

            var ex = Assert.ThrowsAsync<SecurityServiceException>(() => mockhandler.Handle(command, default(CancellationToken)));
            Assert.That(ex.Code, Is.EqualTo(SecurityServiceException.SE004.Code));
        }


    }

}*/