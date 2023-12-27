using CarBook.Application.Features.CQRS.Commands.CarCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var values = await _repository.GetByIdAsync(updateCarCommand.BrandID);
            values.Fuel = updateCarCommand.Fuel;
            values.Transmission = updateCarCommand.Transmission;
            values.BigImageUrl = updateCarCommand.BigImageUrl;
            values.BrandID = updateCarCommand.BrandID;
            values.CoverImageUrl = updateCarCommand.CoverImageUrl;
            values.Km = updateCarCommand.Km;
            values.Luggage = updateCarCommand.Luggage;
            values.Model = updateCarCommand.Model;
            values.Seat = updateCarCommand.Seat;
            await _repository.UpdateAsync(values);
        }
    }
}
