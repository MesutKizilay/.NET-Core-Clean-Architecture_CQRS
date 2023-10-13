using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transactions;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Create
{
    public class CreateBrandCommand : IRequest<CreatedBrandResponse>,ITransactionalRequest, ICacheRemoverRequest,ILoggableRequest
    {
        public string Name { get; set; }

        public string CacheKey => "";
        public bool ByPassCache => false;
        public string? CacheGroupKey => "GetBrands";

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandResponse>? Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCannotBeDublicatedWhenInserted(request.Name);

                Brand brand = _mapper.Map<Brand>(request);

                await _brandRepository.AddAsync(brand);
                //await _brandRepository.AddAsync(brand);

                CreatedBrandResponse createdCommandResponse = _mapper.Map<CreatedBrandResponse>(brand);
                return createdCommandResponse;
            }
        }
    }
}