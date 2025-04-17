using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{/// <summary>
 /// Service interface for performing CRUD operations on TableDetails.
 /// </summary>
    public interface ITableDetailsService
    {
        /// <summary>
        /// Retrieves TableDetails optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the TableDetailsDto to retrieve. If not provided, retrieves all TableDetails.</param>
        /// <returns>
        /// The task result contains a collection of TableDetailsDto DTOs. if successful, or null if no TableDetails match the provided identifier.
        /// </returns>
        Task<IEnumerable<TableDetailsDto>> GetTableDetails(int? id);


        /// <summary>
        /// Retrieves MappingDetails optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the MappingDetailsDto to retrieve. If not provided, retrieves all MappingDetails.</param>
        /// <returns>
        /// The task result contains a collection of MappingDetailsDto DTOs. if successful, or null if no MappingDetails match the provided identifier.
        /// </returns>
        Task<IEnumerable<TableMappingDetailsDto>> GetMappingTableDetails(int? id);
        /// <summary>
        /// Inserts a new TableDetailsDto.
        /// </summary>
        /// <param name="TableDetailsDto">The DTO representing the TableDetailsDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<TableDetailsDto> InsertTableDetails(TableDetailsDto TableDetailsDto);

        /// <summary>
        /// Updates an existing TableDetailsDto.
        /// </summary>
        /// <param name="TableDetailsDto">The DTO representing the updated TableDetailsDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateTableDetails(TableDetailsDto TableDetailsDto);
        /// <summary>
        /// Deletes a TableDetailsDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableDetailsDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteTableDetails(int id);
    }
}
