using CarBook.Application.Features.CQRS.Commands.BannerCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var values = await _repository.GetByIdAsync(updateBannerCommand.BannerID);
            values.BannerID = updateBannerCommand.BannerID;
            values.VideoUrl = updateBannerCommand.VideoUrl;
            values.VideoDescription = updateBannerCommand.VideoDescription;
            values.Description = updateBannerCommand.Description;
            values.Title = updateBannerCommand.Title;
            await _repository.UpdateAsync(values);
        }
    }
}
