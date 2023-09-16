using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand:IRequest<CreatedCommandResponse>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedCommandResponse>
        {
            public Task<CreatedCommandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                CreatedCommandResponse createdCommandResponse =new CreatedCommandResponse();
                createdCommandResponse.Name = request.Name;
                createdCommandResponse.Id = new Guid();
                return null;
            }
        }
    }
}
