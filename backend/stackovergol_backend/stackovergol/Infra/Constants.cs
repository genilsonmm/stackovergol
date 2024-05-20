namespace stackovergol.Infra
{
    public static class Constants
    {
        public const string MEMBER = "MEMBER";
        public const string ADMIN = "ADMIN";
        public const string GUEST = "GUEST";
        public const string GERAL = $"{ADMIN},{MEMBER},{GUEST}";
    }
}
