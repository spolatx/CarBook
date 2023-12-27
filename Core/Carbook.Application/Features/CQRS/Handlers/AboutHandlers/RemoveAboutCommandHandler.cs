using CarBook.Application.Features.CQRS.Commands.AboutCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class RemoveAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public RemoveAboutCommandHandler(IRepository<About> aboutRepository)
        {
            _repository = aboutRepository;
        }
        public async Task Handle(RemoveAboutCommand removeAboutCommand)
        {
            var value = await _repository.GetByIdAsync(removeAboutCommand.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
