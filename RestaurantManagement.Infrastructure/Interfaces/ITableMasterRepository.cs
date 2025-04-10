using RestaurantManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Interfaces
{

    /// <summary>
    /// Repository interface for performing CRUD operations on TableMaster.
    /// </summary>
    public interface ITableMasterRepository
    {
        /// <summary>
        /// Retrieves TableMaster optionally filtered by their unique identifier.
        /// </summary>
        /// <param name="id">Optional. The unique identifier of the TableMaster to retrieve. If not provided, retrieves all TableMasters.</param>
        /// <returns>
        /// The task result contains a collection of TableMaster if successful, or null if no TableMasters match the provided identifier.
        /// </returns>
        Task<IEnumerable<TableMaster>> GetTableMastersDetails(int? id);
        /// <summary>
        /// Inserts a new TableMaster.
        /// </summary>
        /// <param name="TableMaster">The TableMaster to insert.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task<TableMaster> InsertTableMasterDetails(TableMaster TableMaster);
        /// <summary>
        /// Updates an existing TableMaster.
        /// </summary>
        /// <param name="TableMaster">The TableMaster to update.</param>
        /// <returns>
        /// Not returns anything.
        /// </returns>
        Task UpdateTableMasterDetails(TableMaster TableMaster);
        /// <summary>
        /// Deletes a TableMaster by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the TableMaster to delete.</param>
        /// <returns>
        /// The task result indicates whether the deletion was successful.
        /// </returns>
        Task<bool> DeleteTableMasterDetails(int id);
    }
}
