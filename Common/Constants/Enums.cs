﻿namespace Common.Constants
{
    public class Enums
    {
        public enum RoleId
        {
            Admin = 1,
            Manager = 2,
            User = 3
        }

        public enum PermissionId
        {
            // User
            UserCreate = 1,
            UserRead = 2,
            UserUpdate = 3,
            UserDelete = 4,

            // Role
            RoleCreate = 10,
            RoleRead = 11,
            RoleUpdate = 12,
            RoleDelete = 13,
        }
    }
}
