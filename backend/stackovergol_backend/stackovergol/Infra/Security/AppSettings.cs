namespace stackovergol.Infra.Security
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpirationHour { get; set; }
        public string Sended { get; set; }
        public string ValidFrom { get; set; }
    }
}
