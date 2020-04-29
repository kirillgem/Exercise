namespace Exercise.Configuration
{
    public class SecretConfig
    {
        public static string Section = "Secret";
        public string Local { get; set; }
        public string Prod { get; set; }
    }
    public struct TwoValues
    {
        public string Value1;
        public string Value2;
    }
}
