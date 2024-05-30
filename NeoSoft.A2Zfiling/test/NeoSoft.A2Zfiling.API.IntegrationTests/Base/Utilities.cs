using NeoSoft.A2Zfiling.Domain.Entities;
using NeoSoft.A2Zfiling.Persistence;
using System;

namespace NeoSoft.A2Zfiling.API.IntegrationTests.Base
{
    public class Utilities
    {
        public static void InitializeDbForTests(ApplicationDbContext context)
        {
            

            context.SaveChanges();
        }
    }
}
