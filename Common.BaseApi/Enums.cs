namespace Common.BaseApi
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
            // Permission IDs follow a pattern: incremented by 10 per section
            // User
            UserCreate = 1,
            UserRead = 2,
            UserUpdate = 3,
            UserDelete = 4,
        }
    }
}
