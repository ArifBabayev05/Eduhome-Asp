using System;
namespace Utilities.Helpers
{
    public static class Enums
    {
        public enum Statuses
        {
            DataIsNull=1001,
            GeneralError=1000
        }

        public enum Roles
        {
            Admin,
            Member,
            SuperAdmin,
            Manager
        }
    }
}

