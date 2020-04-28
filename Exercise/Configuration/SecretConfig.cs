namespace Exercise.Configuration
{
    public class SecretConfig
    {
        public static string Section = "Secret";
        public string Local { get; set; }
        public string Prod { get; set; }
    }
}
