using Application.Features.InstructorCustomers.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.InstructorCustomers.Commands.AddInstructorCustomer
{
    public class AddInstructorCustomerCommand : IRequest<AddedInstructorCustomerDto>
    {
        public int UserId { get; set; }
        public string PhoneNumber { get; set; }
        public int BodyWeight { get; set; }
        public int Height { get; set; }
        public int BranchId { get; set; }

        public class AddInstructorCustomerCommandHandler : IRequestHandler<AddInstructorCustomerCommand, AddedInstructorCustomerDto>
        {
            private readonly IInstructorCustomerRepository _instructorCustomerRepository;

            public AddInstructorCustomerCommandHandler(IInstructorCustomerRepository instructorCustomerRepository)
            {
                _instructorCustomerRepository = instructorCustomerRepository;
            }

            public async Task<AddedInstructorCustomerDto> Handle(AddInstructorCustomerCommand request, CancellationToken cancellationToken)
            {
                InstructorCustomer instructorCustomerToAdd = new()
                {
                    UserId = request.UserId,
                    BodyWeight = request.BodyWeight,
                    Height = request.Height,
                    PhoneNumber = request.PhoneNumber,
                    BranchId = request.BranchId
                };
                InstructorCustomer addedInstructorCustomer = await _instructorCustomerRepository.AddAsync(instructorCustomerToAdd);

                AddedInstructorCustomerDto result = new()
                {
                    Id = addedInstructorCustomer.Id,
                    UserId = addedInstructorCustomer.UserId,
                    BodyWeight = addedInstructorCustomer.BodyWeight,
                    Height = addedInstructorCustomer.Height,
                    PhoneNumber = addedInstructorCustomer.PhoneNumber,
                    BranchId = addedInstructorCustomer.BranchId
                };
                return result
            }
        }

    }
}
