using Application.Interfaces;
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

            public UpdateClientCommandHandler(IApplicationDbContext context)
            {
                _context = context;
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
                    client.BirthDate = request.BirthDate;
                    client.Name = request.Name;
                    client.Surname = request.Surname;
                    client.Company = request.Company;
                    await _context.SaveChangesAsync();
                    return client.ID;
                }
            }
        }
    }
}
