using AutoMapper;

using Backend_Condominio.DTOs.User;
using Backend_Condominio.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace Backend_Condominio.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly IMapper mapper;

        public UserRepository(ApplicationDbContext applicationDbContext,
            IMapper mapper)
        {
            this.applicationDbContext = applicationDbContext;
            this.mapper = mapper;


        }

        public async Task<bool> UpdateProfile(UpdateDataDTO updateDataDTO)
        {
            var user = await applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == updateDataDTO.UserId);
            if (user == null) { return false; }

            applicationDbContext.Attach(user);


            ; mapper.Map(updateDataDTO, user);


            var residenceData = updateDataDTO.ResidenceDatas.Select(x => mapper.Map<ResidenceData>(x))
                .ToList();
            for (int i = 0; i < residenceData.Count; i++)
            {
                residenceData[i].UserId = user.Id;
            }
            applicationDbContext.AddRange(residenceData);

            try
            {
                await applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return false;
            }

            return true;
        }
        public async Task<UserDTO> GetUser(string UserId)
        {
            var user = await applicationDbContext.Users.Include(x => x.ResidenceDatas).FirstOrDefaultAsync(u => u.Id == UserId);
            if (user == null) { return null; }

            var entity = mapper.Map<UserDTO>(user);
            return entity;

        }


    }
}
