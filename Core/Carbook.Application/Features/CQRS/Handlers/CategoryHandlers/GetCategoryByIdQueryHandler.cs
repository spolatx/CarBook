using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using CarBook.Application.Features.CQRS.Results.CategoryResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _reporsitory;

        public GetCategoryByIdQueryHandler(IRepository<Category> reporsitory)
        {
            _reporsitory = reporsitory;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery getCategoryByIdQuery)
        {
            var values = await _reporsitory.GetByIdAsync(getCategoryByIdQuery.Id);
            return new GetCategoryByIdQueryResult
            {
                CategoryID = values.CategoryID,
                Name = values.Name,
            };
        }
    }
}
