#nullable disable

namespace WallCh.Domain.Common;

public class AppSettings
{
    public MongoDbSettings MongoDbSettings { get; set; }
}

public class MongoDbSettings
{
    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
}
