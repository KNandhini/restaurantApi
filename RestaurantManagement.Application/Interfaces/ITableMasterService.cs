using RestaurantManagement.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Application.Interfaces
{
    /// <summary>
    /// Service interface for performing CRUD operations on TableMaster.
    /// </summary>
    public interface ITableMasterService
    {
        /// <summary>
        /// Retrieves TableMaster optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the TableMasterDto to retrieve. If not provided, retrieves all TableMaster.</param>
        /// <returns>
        /// The task result contains a collection of TableMasterDto DTOs. if successful, or null if no TableMaster match the provided identifier.
        /// </returns>
        Task<IEnumerable<TableMasterDto>> GetTableMastersDetails(int? id);
        /// <summary>
        /// Inserts a new TableMasterDto.
        /// </summary>
        /// <param name="TableMasterDto">The DTO representing the TableMasterDto to insert.</param>
        /// <returns>
        /// The task result indicates whether the insertion was successful.
        /// </returns>
        Task<TableMasterDto> InsertTableMasterDetails(TableMasterDto TableMasterDto);

        /// <summary>
        /// Updates an existing TableMasterDto.
        /// </summary>
        /// <param name="TableMasterDto">The DTO representing the updated TableMasterDto.</param>
        /// <returns>
        ///The task result indicates whether the update was successful.
        /// </returns>
        Task UpdateTableMasterDetails(TableMasterDto TableMasterDto);
        /// <summary>
        /// Deletes a TableMasterDto by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableMasterDto to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteTableMasterDetails(int id);
    }
}
