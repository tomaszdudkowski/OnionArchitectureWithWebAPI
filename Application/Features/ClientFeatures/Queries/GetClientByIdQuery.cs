using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClientFeatures.Queries
{
    public class GetClientByIdQuery : IRequest<Client>
    {
        public int ID { get; set; }
        public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, Client>
        {
            private readonly IApplicationDbContext _context;

            public GetClientByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
            {
                var client = _context.Clients.Where(c => c.ID == request.ID).FirstOrDefault();
                if(client == null)
                {
                    return null;
                }

                return client;
            }
        }
    }
}
