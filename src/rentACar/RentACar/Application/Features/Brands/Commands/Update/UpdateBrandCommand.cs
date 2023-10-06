using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Brands.Commands.Update
{
    public class UpdateBrandCommand : IRequest<UpdatedBrandResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdatedBrandReaponseHandler : IRequestHandler<UpdateBrandCommand, UpdatedBrandResponse>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;

            public UpdatedBrandReaponseHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<UpdatedBrandResponse> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                Brand? brand = await _brandRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);

                //brand = _mapper.Map<Brand>(request);Yeni instance oluşturduğu için aynı Id'ye sahip iki nesne oluşuyor.Tip'in referansı korunmalıdır.
                brand = _mapper.Map(request, brand);
                var response = await _brandRepository.UpdateAsync(brand);

                UpdatedBrandResponse updatedBrandResponse = _mapper.Map<UpdatedBrandResponse>(response);
                return updatedBrandResponse;
            }
        }
    }
}