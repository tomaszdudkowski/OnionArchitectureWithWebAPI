using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClientFeatures.Commands
{
    public class CreateClientCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Company { get; set; }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
        {

            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public CreateClientCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var client = new Client();
                client = _mapper.Map<Client>(request);
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return client.ID;
            }
        }
    }
}
