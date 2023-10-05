using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetList
{
    public class GetListModelQuery:IRequest<GetListResponse<GetListModelListItemDto>>
    {
        public PageRequest PageRequest { get; set; }

        class GetListModelQueryHandler : IRequestHandler<GetListModelQuery, GetListResponse<GetListModelListItemDto>>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public Task<GetListResponse<GetListModelListItemDto>> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}