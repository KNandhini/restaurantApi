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
    /// Service class for performing CRUD operations on orderDetails.
    /// </summary>
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailService"/> class.
        /// </summary>
        /// <param name="OrderDetailRepository">The repository for accessing OrderDetailDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<OrderDetailDto> GetOrderDetailsDetails(int? id)
        {
            var OrderDetails = await _orderDetailRepository.GetOrderDetailsDetails(id);

            var OrderDetailDetails = _mapper.Map<OrderDetailDto>(OrderDetails);
            return OrderDetailDetails;
        }
        /// <inheritdoc/>
        public async Task<OrderDetailDto> InsertOrderDetails(OrderDetailDto orderDetailDto)
        {
            try
            {
                var OrderData = _mapper.Map<OrderDetail>(orderDetailDto);
                var insertedData = await _orderDetailRepository.InsertOrderDetails(OrderData);
                if (insertedData == null)
                {
                    // Handle the case where the insertion was not successful
                    throw new Exception("OrderDetail insertion failed.");
                }
                return _mapper.Map<OrderDetailDto>(insertedData);
            }
            catch (Exception ex)
            {
                // Log or inspect the exception
                Console.WriteLine($"AutoMapper error: {ex.Message}");
                throw;
            }

           

        }
        /// <inheritdoc/>
        public async Task UpdateOrderDetailDetails(List<UpdateFoodReceivedRequestDto> orderDetailDto)
        {
            var OrderDetail = _mapper.Map<List<UpdateFoodReceivedRequest>>(orderDetailDto);
            await _orderDetailRepository.UpdateOrderDetailDetails(OrderDetail);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteOrderDetailDetails(int id)
        {
            return await _orderDetailRepository.DeleteOrderDetailDetails(id);
        }

       
    }
}
