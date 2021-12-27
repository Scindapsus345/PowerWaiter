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
                    Name = "Выручка",
                    Description = "Заработать 1.000.000р",
                    Prize = 3500,
                    Progress = 891563,
                    Purpose = 1000000,
                    Deadline = DateTime.Now + TimeSpan.FromDays(5)
                },
                new PurposeModel
                {
                    Name = "Гости",
                    Description = "Обслужить 2000 гостей",
                    Prize = 2000,
                    Progress = 2699,
                    Purpose = 2000,
                    Deadline = DateTime.Now
                }
            };
        }
    }
}
