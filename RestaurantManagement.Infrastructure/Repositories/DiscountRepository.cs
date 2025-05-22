using RestaurantManagement.Domain.Entities;
using RestaurantManagement.Infrastructure.Constants;
using RestaurantManagement.Infrastructure.DatabaseConnection;
using RestaurantManagement.Infrastructure.Interfaces;
using System.Data;
using Dapper;

namespace RestaurantManagement.Infrastructure.Repositories
{
    /// <summary>
    /// Repository class for performing CRUD operations on discount.
    /// </summary>
    public class DiscountRepository : IDiscountRepository
    {
        private readonly IDataBaseConnection _db;

        /// <summary>
        /// Initializes a new instance of the <see cref="DiscountRepository"/> class.
        /// </summary>
        /// <param name="_db">The database connection for accessing discounting data.</param>
        public DiscountRepository(IDataBaseConnection db)
        {
            this._db = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Discounts>> GetDiscountsDetails(int? id)
        {
            var spName = SPNames.SP_GETAllDISCOUNTDETAIL; // Update the stored procedure name if necessary
            return await Task.Factory.StartNew(() => _db.Connection.Query<Discounts>(spName,
                new { Id = id }, commandType: CommandType.StoredProcedure).ToList());
        }

        public async Task<Discounts> InsertDiscountDetails(Discounts discount)
        {
            var spName = SPNames.SP_INSERTDISCOUNTDETAIL; // Name of your stored procedure
                                                         // Define parameters for the stored procedure



            var parameters = new
            {
                Percentage = discount.Percentage,
                DiscountType = discount.DiscountType,
                DiscountCode = discount.DiscountCode,
                ValidUpto=discount.ValidUpto,
                CreatedBy = discount.CreatedBy

            };

            // Execute the stored procedure and retrieve the inserted data
            var insertedData = await _db.Connection.QuerySingleOrDefaultAsync<Discounts>(
                spName,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedData;


        }
        /// <inheritdoc/>
        public async Task UpdateDiscountDetails(Discounts discount)
        {
            var spName = SPNames.SP_UPDATEDISCOUNTDETAIL; // Update the stored procedure name if necessary


            var parameters = new
            {
                Id = discount.Id,
                Percentage = discount.Percentage,
                DiscountType = discount.DiscountType,
                DiscountCode = discount.DiscountCode,
                ValidUpto = discount.ValidUpto,
                ModifiedBy = discount.ModifiedBy,



            };
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, parameters, commandType: CommandType.StoredProcedure));
        }

        public async Task<bool> DeleteDiscountDetails(int id)
        {
            var spName = SPNames.SP_DELETEDISCOUNTDETAIL; // Update the stored procedure name if necessary
            await Task.Factory.StartNew(() =>
                _db.Connection.Execute(spName, new { Id = id }, commandType: CommandType.StoredProcedure));
            return true;
        }
    }
}
