using WallCh.Domain.Attributes;
using WallCh.Domain.Models.Base;

namespace WallCh.Domain.Models;

[BsonCollection("users")]
public class User : Document
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public long Phone { get; set; }

    public string Password { get; set; } = null!;

    public byte[] Salt { get; set; } = null!;

    public string IpAddress { get; set; } = null!;
}
