using Application.Features.IndividualCustomers.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.IndividualCustomers.Commands.AddIndividualCustomer
{
    public class AddIndividualCustomerCommand : IRequest<AddedIndividualCustomerDto>
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int BodyWeight { get; set; }
        public int Height { get; set; }
        public bool IsVIP { get; set; }
        public class AddIndividualCustomerCommandHandler : IRequestHandler<AddIndividualCustomerCommand, AddedIndividualCustomerDto>
        {

            private readonly IIndividualCustomerRepository _individualCustomerRepository;

            public AddIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository)
            {
                _individualCustomerRepository = individualCustomerRepository;
            }

            public async Task<AddedIndividualCustomerDto> Handle(AddIndividualCustomerCommand request, CancellationToken cancellationToken)
            {
                IndividualCustomer individualCustomerToAdd = new()
                {
                    UserId = request.UserId,
                    BodyWeight = request.BodyWeight,
                    Height = request.Height,
                    PhoneNumber = request.PhoneNumber,
                    IsVIP = request.IsVIP
                };
                IndividualCustomer addedIndividualCustomer = await _individualCustomerRepository.AddAsync(individualCustomerToAdd);

                AddedIndividualCustomerDto result = new()
                {
                    Id = addedIndividualCustomer.Id,
                    UserId = addedIndividualCustomer.UserId,
                    BodyWeight = addedIndividualCustomer.BodyWeight,
                    Height = addedIndividualCustomer.Height,
                    PhoneNumber = addedIndividualCustomer.PhoneNumber,
                    IsVIP = addedIndividualCustomer.IsVIP
                };
                return result;
            }
        }


    }
}
