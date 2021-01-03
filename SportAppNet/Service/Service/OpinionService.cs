using AutoMapper;
using SportAppNet.DTO;
using SportAppNet.Entity;
using SportAppNet.Repository;
using SportAppNet.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportAppNet.Service.Service
{
    public class OpinionService : IOpinionService
    {
        private readonly IOpinionRepository<OpinionEntity> _opinionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public OpinionService(IOpinionRepository<OpinionEntity> opinionRepository, IMapper mapper, IUserRepository userRepository)
        {
            _opinionRepository = opinionRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public void AddOpinion(OpinionPostDto opinionPostDto)
        {
            Context context = new Context();
           
            OpinionEntity opinionEntity = _mapper.Map(opinionPostDto,new OpinionEntity());
            if (opinionEntity != null)
            {
               UserEntity userEntity = _userRepository.GetUserByUserId(opinionPostDto.GuidUserId, context); 
                userEntity.OpinionEntity.Add(opinionEntity);
                context.SaveChanges();
            }
        }
    }
}

