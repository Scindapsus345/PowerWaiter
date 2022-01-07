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
                    Prize = 3500,
                    Progress = 891563,
                    Purpose = 1000000,
                    Deadline = "27.02.2023"
                },
                new PurposeModel
                {
                    Name = "Обслуженные гости",
                    Prize = 2000,
                    Progress = 2699,
                    Purpose = 2000,
                    Deadline = "12.05.2023"
                }
            };
        }
    }
}
