using CarBook.Application.Features.CQRS.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand updateContactCommand) 
        {
           var values = await _repository.GetByIdAsync(updateContactCommand.ContactID);
            values.Email = updateContactCommand.Email;
            values.SendDate = updateContactCommand.SendDate;
            values.Subject = updateContactCommand.Subject;
            values.Message = updateContactCommand.Message;
            values.Name = updateContactCommand.Name;
            values.ContactID = updateContactCommand.ContactID;
           await _repository.UpdateAsync(values);
        }
    }
}
