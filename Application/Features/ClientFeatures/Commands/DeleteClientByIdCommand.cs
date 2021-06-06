using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ClientFeatures.Commands
{
    public class DeleteClientByIdCommand : IRequest<int>
    {
        public int ID { get; set; }

        public class DeleteClientByIdCommandHandler : IRequestHandler<DeleteClientByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public DeleteClientByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteClientByIdCommand request, CancellationToken cancellationToken)
            {
                var client = await _context.Clients.Where(c => c.ID == request.ID).FirstOrDefaultAsync();
                
                if(client == null)
                {
                    return default;
                }

                _context.Clients.Remove(client);
                await _context.SaveChangesAsync();
                return client.ID;
            }
        }
    }
}
