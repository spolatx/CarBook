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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand createCarCommand)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = createCarCommand.BigImageUrl,
                BrandID = createCarCommand.BrandID,
                CoverImageUrl = createCarCommand.CoverImageUrl,
                Fuel=createCarCommand.Fuel,
                Km=createCarCommand.Km,
                Luggage=createCarCommand.Luggage,
                Model=createCarCommand.Model,
                Seat=createCarCommand.Seat,
                Transmission=createCarCommand.Transmission,
            });

        }
    }
}
