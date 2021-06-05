using Application.Interfaces;
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

            public CreateClientCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var client = new Client();
                client.BirthDate = request.BirthDate;
                client.Name = request.Name;
                client.Surname = request.Surname;
                client.Company = request.Company;
                _context.Clients.Add(client);
                await _context.SaveChangesAsync();
                return client.ID;
            }
        }
    }
}
