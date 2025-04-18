namespace EBookApi.Domain.Options
{
    public class ConnectionStringOption
    {
        public const string Key = "ConnectionStrings";
        public string PostgreSql { get; set; } = default!;
    }
}
