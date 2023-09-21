using AutoMapper;
using ZenDriver.API.Security.Authorization.Handlers.Interfaces;
using ZenDriver.API.Security.Domain.Models;
using ZenDriver.API.Security.Domain.Repositories;
using ZenDriver.API.Security.Domain.Services;
using ZenDriver.API.Security.Domain.Services.Communication;
using ZenDriver.API.Security.Exceptions;
using ZenDriver.API.Shared.Domain.Repositories;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ZenDriver.API.Security.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    private readonly IJwtHandler _jwtHandler;
    private readonly IMapper _mapper;

    public UserService(IJwtHandler jwtHandler, 
        IMapper mapper, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _jwtHandler = jwtHandler;
        _mapper = mapper;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
    {
        var user = await _userRepository.FindByUsernameAsync(request.Username);
        Console.WriteLine($"Request: {request.Username}, {request.Password}");

        // Verificar si el usuario existe
        if (user == null || !BCryptNet.Verify(request.Password, user.PasswordHash))
        {
            Console.WriteLine("Authentication Error");
            throw new AppException("Username or password is incorrect");
        }

        Console.WriteLine($"User: {user.Id}, {user.FirstName}, {user.LastName}, {user.UserName}, {user.PasswordHash}");
        Console.WriteLine("Authentication successful. About to generate token");

        // Generar respuesta de autenticación
        var response = _mapper.Map<AuthenticateResponse>(user);
        Console.WriteLine($"Response: {response.Id}, {response.FirstName}, {response.LastName}, {response.Username}");
        response.Token = _jwtHandler.GenerateToken(user);
        Console.WriteLine($"Generated token is {response.Token}");

        return response;
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var user = await _userRepository.FindByIdAsync(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public async Task RegisterAsync(RegisterRequest request)
    {
        //Validate
        if (_userRepository.ExistsByUsername(request.Username))
            throw new AppException("Username '" + request.Username + "' is already taken");
        // map model to new user object
        var user = _mapper.Map<User>(request);
        //Hash password
        user.PasswordHash = BCryptNet.HashPassword(request.Password);
        // Save User
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while saving the user: {e.Message}");
        }
    }

    public async Task UpdateAsync(int id, UpdateRequest request)
    {
        var user = GetById(id);

        //Validate
        //if(_userRepository.ExistsByUsername(request.Username))
        //    throw new AppException("Username '" + request.Username + "' is already taken");
        // Hash password if it was entered
        if (!string.IsNullOrEmpty(request.Password))
            user.PasswordHash = BCryptNet.HashPassword(request.Password);
        //Copy model to user and save
        _mapper.Map(request, user);
        try
        {
            _userRepository.Update(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while updating the user: {e.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = GetById(id);

        try
        {
            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new AppException($"An error ocurred while deleting the user : {e.Message}");
        }
    }

    //helper methods
    private User GetById(int id)
    {
        var user = _userRepository.FindById(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}
