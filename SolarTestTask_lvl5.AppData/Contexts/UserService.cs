using AutoMapper;
using SolarTestTask_lvl5.Contracts.User;
using SolarTestTask_lvl5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarTestTask_lvl5.AppData.Contexts
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<Guid> CreateUserAsync(CreateUserRequest createUser, CancellationToken cancellation)
        {
            var user = _mapper.Map<User>(createUser);
            user.Id = Guid.NewGuid();

            await _userRepository.AddAsync(user,cancellation);

            return user.Id;
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellation)
        {
            var user = await _userRepository.FindById(id,cancellation);

            await _userRepository.DeleteAsync(user, cancellation);
        }

        public async Task<InfoUserResponse> EditUserAsync(Guid Id, EditUserRequest edit, CancellationToken cancellation)
        {
            var existingUser = await _userRepository.FindById(Id, cancellation);
            await _userRepository.EditUserAsync(_mapper.Map(edit, existingUser), cancellation);

            return _mapper.Map<InfoUserResponse>(existingUser);


        }

        public async Task<IReadOnlyCollection<InfoUserResponse>> GetAll()
        {
            return _userRepository.GetAll().Select(u=>new InfoUserResponse
            {
                Id = u.Id,
                BirthDate = u.BirthDate,
                email = u.email,
                FIO = u.FIO
            }).ToList();
        }

        public async Task<InfoUserResponse> GetByIdAsync(Guid id, CancellationToken cancellation)
        {
            return _mapper.Map<InfoUserResponse>(await _userRepository.FindById(id, cancellation));
        }
    }
}
