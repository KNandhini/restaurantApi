using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RestaurantManagement.Infrastructure.Repositories
{/// <summary>
 /// Repository class for performing CRUD operations on TableMaster.
 /// </summary>
    public class TableMasterRepository : ITableMasterRepository
    {
        private readonly IDataBaseConnection _db;

    /// <summary>
    /// Initializes a new instance of the <see cref="TableMasterRepository"/> class.
    /// </summary>
    /// <param name="_db">The database connection for accessing billing data.</param>
    public TableMasterRepository(IDataBaseConnection db)
    {
        this._db = db;
    }

    /// <inheritdoc/>
    public async Task<IEnumerable<TableMaster>> GetTableMastersDetails(int? id)
    {
        var spName = SPNames.SP_GETALLTABLEMASTERDETAIL; // Update the stored procedure name if necessary
        return await Task.Factory.StartNew(() => _db.Connection.Query<TableMaster>(spName,
            new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
    }

    public async Task<TableMaster> InsertTableMasterDetails(TableMaster TableMaster)
    {
        var spName = SPNames.SP_INSERTTABLEMASTERDETAIL; // Name of your stored procedure
                                                      // Define parameters for the stored procedure



        var parameters = new
        {
            Name = TableMaster.Name,           
            CreatedBy = TableMaster.CreatedBy,

        };

        // Execute the stored procedure and retrieve the inserted data
        var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<TableMaster>(
            spName,
            parameters,
            commandType: CommandType.StoredProcedure
        );

        return insertedData;


    }
    /// <inheritdoc/>
    public async Task UpdateTableMasterDetails(TableMaster TableMaster)
    {
        var spName = SPNames.SP_UPDATETABLEMASTERDETAIL; // Update the stored procedure name if necessary


        var parameters = new
        {
            Id = TableMaster.Id,
            Name = TableMaster.Name,
            ModifiedBy = TableMaster.ModifiedBy,

        };
        await Task.Factory.StartNew(() =>
            _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
    }

    public async Task<bool> DeleteTableMasterDetails(int id)
    {
        var spName = SPNames.SP_DELETETABLEMASTERDETAIL; // Update the stored procedure name if necessary
        await Task.Factory.StartNew(() =>
            _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
        return true;
    }
  }

}
