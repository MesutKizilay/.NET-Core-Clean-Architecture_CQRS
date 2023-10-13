using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand : IRequest<DeletedBrandResponse>, ICacheRemoverRequest
    {
        public int Id { get; set; }

        public string CacheKey => "";
        public bool ByPassCache => false;
        public string? CacheGroupKey => "GetBrands";

        public class DeletedBrandCommandHandler : IRequestHandler<DeleteBrandCommand, DeletedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public DeletedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeletedBrandResponse> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

                brand = await _brandRepository.DeleteAsync(brand);
                DeletedBrandResponse deletedBrandResponse = _mapper.Map<DeletedBrandResponse>(brand);
                return deletedBrandResponse;
            }
        }
    }
}