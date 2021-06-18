using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClientFeatures.Commands
{
    public class UpdateClientCommand : IRequest<int>
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Company { get; set; }

        public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, int>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdateClientCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            {
                var client = _context.Clients.Where(c => c.ID == request.ID).FirstOrDefault();

                if(client == null)
                {
                    return default;
                } 
                else
                {
                    _mapper.Map(request, client);
                    await _context.SaveChangesAsync();
                    return client.ID;
                }
            }
        }
    }
}
