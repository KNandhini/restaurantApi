using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Services
{
    /// <summary>
    /// Service class for performing CRUD operations on customers.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="CustomerRepository">The repository for accessing CustomerDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<CustomerDto>> GetCustomersDetails(int? id)
        {
            var Customers = await _customerRepository.GetCustomersDetails(id);

            var CustomerDetails = _mapper.Map<IEnumerable<CustomerDto>>(Customers);
            return CustomerDetails;
        }
        /// <inheritdoc/>
        public async Task<CustomerDto> InsertCustomerDetails(CustomerDto customerDto)
        {

            var Customer = _mapper.Map<Customers>(customerDto);
            var insertedData = await _customerRepository.InsertCustomerDetails(Customer);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Customer insertion failed.");
            }
            return _mapper.Map<CustomerDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateCustomerDetails(CustomerDto customerDto)
        {
            var Customer = _mapper.Map<Customers>(customerDto);
            await _customerRepository.UpdateCustomerDetails(Customer);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteCustomerDetails(int id)
        {
            return await _customerRepository.DeleteCustomerDetails(id);
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerByPhoneNumber(string mobileNo)
        {
            var Customers = await _customerRepository.GetCustomerByPhoneNumber(mobileNo);

            var CustomerDetails = _mapper.Map<IEnumerable<CustomerDto>>(Customers);
            return CustomerDetails;
        }
    }
}
