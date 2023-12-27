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
    public class UpdateAboutCommandHandle
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandle(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var values = await _repository.GetByIdAsync(updateAboutCommand.AboutID);
            values.Description = updateAboutCommand.Description;
            values.Title= updateAboutCommand.Title;
            values.ImageUrl = updateAboutCommand.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
