using BE.BOs.Models;
using BE.DAOs;
using BE.REPOs.Interface;

namespace BE.REPOs.Implementation;

public class UserRepo : IUserRepo
{
    private readonly UserDAO _dao;

    public UserRepo(UserDAO dao)
    {
        _dao = dao;
    }

    public async Task<List<User>> GetAllUsersAsync() => await _dao.GetAllAsync();
    public async Task<User?> GetUserByIdAsync(int id) => await _dao.GetByIdAsync(id);
    public async Task<User?> GetUserByEmailAsync(string email) => await _dao.GetByEmailAsync(email);
    public async Task<User> CreateUserAsync(User user) => await _dao.CreateAsync(user);
    public async Task UpdateUserAsync(User user) => await _dao.UpdateAsync(user);
    public async Task DeleteUserAsync(int id) => await _dao.DeleteAsync(id);
}
