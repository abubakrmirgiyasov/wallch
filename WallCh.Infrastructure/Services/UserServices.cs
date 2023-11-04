using WallCh.Infrastructure.Repositories;

namespace WallCh.Infrastructure.Services;

public class UserServices
{
    private readonly UserRepository _userRepository;

    public UserServices(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }
}
