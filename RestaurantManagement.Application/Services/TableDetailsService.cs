using AutoMapper;
using RestaurantManagement.Application.Dtos;
using RestaurantManagement.Application.Interfaces;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.Domain.Entities;

namespace RestaurantManagement.Application.Services
{ /// <summary>
  /// Service class for performing CRUD operations on TableDetails.
  /// </summary>
    public class TableDetailsService : ITableDetailsService
    {
        private readonly ITableDetailsRepository _TableDetailsRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableDetailsService"/> class.
        /// </summary>
        /// <param name="TableDetailsRepository">The repository for accessing TableDetailsDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public TableDetailsService(ITableDetailsRepository TableDetailsRepository, IMapper mapper)
        {
            _TableDetailsRepository = TableDetailsRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TableDetailsDto>> GetTableDetailsDetails(int? id)
        {
            var TableDetails = await _TableDetailsRepository.GetTableDetailsDetails(id);

            var TableDetailsDetails = _mapper.Map<IEnumerable<TableDetailsDto>>(TableDetails);
            return TableDetailsDetails;
        }
        /// <inheritdoc/>
        public async Task<TableDetailsDto> InsertTableDetailsDetails(TableDetailsDto TableDetailsDto)
        {

            var TableDetails = _mapper.Map<TableDetails>(TableDetailsDto);
            var insertedData = await _TableDetailsRepository.InsertTableDetailsDetails(TableDetails);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("TableDetails insertion failed.");
            }
            return _mapper.Map<TableDetailsDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateTableDetailsDetails(TableDetailsDto TableDetailsDto)
        {
            var TableDetails = _mapper.Map<TableDetails>(TableDetailsDto);
            await _TableDetailsRepository.UpdateTableDetailsDetails(TableDetails);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteTableDetailsDetails(int id)
        {
            return await _TableDetailsRepository.DeleteTableDetailsDetails(id);
        }
    }
}
