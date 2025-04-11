namespace EBookApi.Repositories.DbServices
{
    public class ConnectionStringOption
    {
        public const string Key = "ConnectionStrings";
        public string PostgreSql { get; set; } = default!;
    }
}
