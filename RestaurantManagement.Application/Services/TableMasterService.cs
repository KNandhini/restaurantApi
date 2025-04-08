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
    /// Service class for performing CRUD operations on TableMaster.
    /// </summary>
    public class TableMasterService : ITableMasterService
    {
        private readonly ITableMasterRepository _TableMasterRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableMasterService"/> class.
        /// </summary>
        /// <param name="TableMasterRepository">The repository for accessing TableMasterDto data.</param>
        /// <param name="mapper">The AutoMapper instance for mapping between entity and DTO.</param>
        public TableMasterService(ITableMasterRepository TableMasterRepository, IMapper mapper)
        {
            _TableMasterRepository = TableMasterRepository;
            _mapper = mapper;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<TableMasterDto>> GetTableMastersDetails(int? id)
        {
            var TableMasters = await _TableMasterRepository.GetTableMastersDetails(id);

            var TableMasterDetails = _mapper.Map<IEnumerable<TableMasterDto>>(TableMasters);
            return TableMasterDetails;
        }
        /// <inheritdoc/>
        public async Task<TableMasterDto> InsertTableMasterDetails(TableMasterDto TableMasterDto)
        {

            var TableMaster = _mapper.Map<TableMaster>(TableMasterDto);
            var insertedData = await _TableMasterRepository.InsertTableMasterDetails(TableMaster);
            if (insertedData == null)
            {
                // Handle the case where the insertion was not successful
                throw new Exception("TableMaster insertion failed.");
            }
            return _mapper.Map<TableMasterDto>(insertedData);

        }
        /// <inheritdoc/>
        public async Task UpdateTableMasterDetails(TableMasterDto TableMasterDto)
        {
            var TableMaster = _mapper.Map<TableMaster>(TableMasterDto);
            await _TableMasterRepository.UpdateTableMasterDetails(TableMaster);
        }
        /// <inheritdoc/>
        public async Task<bool> DeleteTableMasterDetails(int id)
        {
            return await _TableMasterRepository.DeleteTableMasterDetails(id);
        }
    }
}
