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
    /// Service class for performing CRUD operations on billings.
    /// </summary>
    public class BillService : IBillService
    {
        private readonly IBillRepository _BillRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="BillService"/> class.
        /// </summary>
        /// <param name="BillRepository">The repository for accessing BillDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public BillService(IBillRepository BillRepository, IMapper mapper)
        {
            _BillRepository = BillRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<BillingDto>> GetBillsDetails(int? id)
        {
            var Bills = await _BillRepository.GetBillsDetails(id);

            var BillDetails = _mapper.Map<IEnumerable<BillingDto>>(Bills);
            return BillDetails;
        }
        /// <inheritdoc/>
        public async Task<BillingDto> InsertBillDetails(BillingDto billingDto)
        {

            var Bill = _mapper.Map<Billings>(billingDto);
            var insertedData = await _BillRepository.InsertBillDetails(Bill);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("Bill insertion failed.");
            }
            return _mapper.Map<BillingDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateBillDetails(BillingUpdateDto billingDto)
        {
            var Bill = _mapper.Map<BillingUpdate>(billingDto);
            await _BillRepository.UpdateBillDetails(Bill);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteBillDetails(int id)
        {
            return await _BillRepository.DeleteBillDetails(id);
        }
        
        
    }
}
