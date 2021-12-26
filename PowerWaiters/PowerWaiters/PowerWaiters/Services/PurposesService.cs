using PowerWaiters.Models;
using System;
using System.Collections.Generic;

namespace PowerWaiters.Services
{
    static class PurposesService
    {
        public static IEnumerable<PurposeModel> GetPurposes()
        {
            return new List<PurposeModel> {
                new PurposeModel
                {
                    Name = "Name",
                    Description = "Desc",
                    Prize = 200,
                    Progress = 50,
                    Purpose = 100,
                    Deadline = DateTime.Now + TimeSpan.FromDays(5)
                },
                new PurposeModel
                {
                    Name = "Name2",
                    Description = "Desc2",
                    Prize = 200,
                    Progress = 100,
                    Purpose = 100,
                    Deadline = DateTime.Now
                }
            };
        }
    }
}
