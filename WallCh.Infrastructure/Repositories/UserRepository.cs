using Microsoft.Extensions.Options;
using WallCh.Domain.Common;
using WallCh.Domain.Models;
using WallCh.Infrastructure.Repositories.Base;

namespace WallCh.Infrastructure.Repositories;

public class UserRepository : Repository<User>
{
    public UserRepository(IOptions<AppSettings> appSettings) 
        : base(appSettings)
    {

    }
}
