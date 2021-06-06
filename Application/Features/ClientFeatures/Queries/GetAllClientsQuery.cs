using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClientFeatures.Queries
{
    public class GetAllClientsQuery : IRequest<IEnumerable<Client>>
    {
        public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, IEnumerable<Client>>
        {
            private readonly IApplicationDbContext _context;

            public GetAllClientsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Client>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
            {
                var clientList = await _context.Clients.ToListAsync();
                
                if(clientList == null)
                {
                    return null;
                }

                return clientList.AsReadOnly();
            }
        }
    }
}
