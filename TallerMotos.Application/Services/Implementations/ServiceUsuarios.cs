using AutoMapper;
using TallerMotos.Application.DTO;
using TallerMotos.Application.Services.Interfaces;
using TallerMotos.Infraestructure.Repository.Interfaces;
using Microsoft.Extensions.Options;
using TallerMotos.Application.Config;
using TallerMotos.Application.Utils;
using TallerMotos.Infraestructure.Models;

namespace TallerMotos.Application.Services.Implementations
{
    public class ServiceUsuarios : IServiceUsuarios
    {
        private readonly IRepositoryUsuarios _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<AppConfig> _options;
        public ServiceUsuarios(IRepositoryUsuarios repository, IMapper mapper, IOptions<AppConfig> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }
        public async Task<UsuariosDTO> FindByIdAsync(int id)
        {
            var @object = await _repository.FindByIdAsync(id);
            var objectMapped = _mapper.Map<UsuariosDTO>(@object);
            return objectMapped;
        }

        public async Task<ICollection<UsuariosDTO>> ListAsync()
        {

            var list = await _repository.ListAsync();

            var collection = _mapper.Map<ICollection<UsuariosDTO>>(list);
            // Return lista
            return collection;
        }
        public async Task<UsuariosDTO> LoginAsync(string id, string password)
        {
            UsuariosDTO usuariosDTO = null!;

            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(password, secret);

            var @object = await _repository.LoginAsync(id, passwordEncrypted);

            if (@object != null)
            {
                usuariosDTO = _mapper.Map<UsuariosDTO>(@object);
            }

            return usuariosDTO;
        }
        public async Task<string> AddAsync(UsuariosDTO dto)
        {
            // Llave secreta
            string secret = _options.Value.Crypto.Secret;
            // Password encriptado
            string passwordEncrypted = Cryptography.Encrypt(dto.Contrasenna!, secret);
            // Establecer password DTO
            dto.Contrasenna = passwordEncrypted;
            var objectMapped = _mapper.Map<Usuarios>(dto);

            return await _repository.AddAsync(objectMapped);
        }
    }
}
