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
    /// Service class for performing CRUD operations on orderTypes.
    /// </summary>
    public class OrderTypeService : IOrderTypeService
    {
        private readonly IOrderTypeRepository _orderTypeRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderTypeService"/> class.
        /// </summary>
        /// <param name="OrderTypeRepository">The repository for accessing OrderTypeDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public OrderTypeService(IOrderTypeRepository orderTypeRepository, IMapper mapper)
        {
            _orderTypeRepository = orderTypeRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<OrderTypeDto>> GetOrderTypesDetails(int? id)
        {
            var OrderTypes = await _orderTypeRepository.GetOrderTypesDetails(id);

            var OrderTypeDetails = _mapper.Map<IEnumerable<OrderTypeDto>>(OrderTypes);
            return OrderTypeDetails;
        }
        /// <inheritdoc/>
        public async Task<OrderTypeDto> InsertOrderTypeDetails(OrderTypeDto orderTypeDto)
        {

            var OrderType = _mapper.Map<OrderTypes>(orderTypeDto);
         
            var insertedData = await _orderTypeRepository.InsertOrderTypeDetails(OrderType);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("OrderType insertion failed.");
            }
            return _mapper.Map<OrderTypeDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateOrderTypeDetails(OrderTypeDto orderTypeDto)
        {
            var OrderType = _mapper.Map<OrderTypes>(orderTypeDto);
            await _orderTypeRepository.UpdateOrderTypeDetails(OrderType);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteOrderTypeDetails(int id)
        {
            return await _orderTypeRepository.DeleteOrderTypeDetails(id);
        }
        
        
    }
}
