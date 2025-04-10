﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.Infrastructure.Constants
{
    public static class SPNames
    {
        public const string SP_GETAllBILLINGDETAIL = "[sp_GetBillInformation]";
        public const string SP_INSERTBILLINGDETAIL = "[sp_InsertBillInformation]";
        public const string SP_UPDATEBILLINGDETAIL = "sp_UpdateBillInformation";
        public const string SP_DELETEBILLINGDETAIL = "sp_DeleteBillInformation";

        public const string SP_GETAllCUSTOMERDETAIL = "sp_GetCustomerMaster";
        public const string SP_INSERTCUSTOMERDETAIL = "[sp_InsertCustomerMaster]";
        public const string SP_UPDATECUSTOMERDETAIL = "sp_UpdateCustomerMaster";
        public const string SP_DELETECUSTOMERDETAIL = "sp_DeleteCustomerMaster";
        public const string SP_GETAllCUSTOMERBYPHONE = "sp_GetCustomerByPhoneNo";

        

        public const string SP_GETAllINVENTORYDETAIL = "sp_GetInventoryMaster";
        public const string SP_INSERTINVENTORYDETAIL = "[sp_InsertInventoryMaster]";
        public const string SP_UPDATEINVENTORYDETAIL = "sp_UpdateInventoryMaster";
        public const string SP_DELETEINVENTORYDETAIL = "sp_DeleteInventoryMaster";

        public const string SP_GETAllORDERDETAIL = "sp_GetOrderDetails";
        public const string SP_INSERTORDERDETAIL = "sp_InsertOrderDetails";
        public const string SP_UPDATEORDERDETAIL = "sp_UpdateOrderDetails";
        public const string SP_DELETEORDERDETAIL = "[sp_DeleteOrderDetails]";

        public const string SP_GETAllINVENTORYCOSTDETAIL = "sp_GetInventoryCost";
        public const string SP_INSERTINVENTORYCOSTDETAIL = "[sp_InsertInventoryCost";
        public const string SP_UPDATEINVENTORYCOSTDETAIL = "sp_UpdateInventoryCost";
        public const string SP_DELETEINVENTORYCOSTDETAIL = "sp_DeleteInventoryCost";


        public const string SP_GETAllDISCOUNTDETAIL = "sp_GetDiscountMaster";
        public const string SP_INSERTDISCOUNTDETAIL = "[sp_InsertDiscountMaster]";
        public const string SP_UPDATEDISCOUNTDETAIL = "sp_UpdateDiscountMaster";
        public const string SP_DELETEDISCOUNTDETAIL = "sp_DeleteDiscountMaster";

        public const string SP_GETAllTABLEDETAIL = "sp_GetTableDetails";
        public const string SP_INSERTTABLEDETAIL = "[sp_InsertTableDetails]";
        public const string SP_UPDATETABLEDETAIL = "sp_UpdateTableDetails";
        public const string SP_DELETETABLEDETAIL = "sp_DeleteTableDetails";

        public const string SP_GETAllTABLEMASTER = "sp_GetTableMaster";
        public const string SP_INSERTTABLEMASTER = "[sp_InsertTableMaster]";
        public const string SP_UPDATETABLEMASTER = "sp_UpdateTableMaster";
        public const string SP_DELETETABLEMASTER = "sp_DeleteTableMaster";


        public const string SP_GETAllUSERMASTER = "sp_GetUserMaster";
        public const string SP_INSERTUSERMASTER = "[sp_InsertUserMaster]";
        public const string SP_UPDATEUSERMASTER = "sp_UpdateUserMaster";
        public const string SP_DELETEUSERMASTER = "sp_DeleteUserMaster";
        public const string SP_UPDATEPASSWORD = "sp_UpdatePassword";

        public const string SP_GETAllROLEMASTER = "[sp_GetRoleMaster]";
        public const string SP_INSERTROLEMASTER = "[sp_InsertRoleMaster]";
        public const string SP_UPDATEROLEMASTER = "sp_UpdateRoleMaster";
        public const string SP_DELETEROLEMASTER = "sp_DeleteRoleMaster";


        public const string SP_GETALLTABLEMASTERDETAIL = "sp_GetTableMaster";
        public const string SP_INSERTTABLEMASTERDETAIL = "[sp_InsertTABLEMASTERMaster]";
        public const string SP_UPDATETABLEMASTERDETAIL = "sp_UpdateTABLEMASTERMaster";
        public const string SP_DELETETABLEMASTERDETAIL = "sp_DeleteTABLEMASTERMaster";

        public const string SP_GETALLTABLEDETAILS = "sp_GetOrderTypeMaster";
        public const string SP_INSERTTABLEDETAILS = "[sp_InsertTABLEMASTERMaster]";
        public const string SP_UPDATETABLEDETAILS = "sp_UpdateTABLEMASTERMaster";
        public const string SP_DELETETABLEDETAILS = "sp_DeleteTABLEMASTERMaster";


        public const string SP_GETAllORDERTYPEMASTER = "sp_GetOrderTypeMaster";
        public const string SP_INSERTORDERTYPEMASTER = "[sp_InsertOrderTypeMaster]";
        public const string SP_UPDATEORDERTYPEMASTER = "sp_UpdateOrderTypeMaster";
        public const string SP_DELETEORDERTYPEMASTER = "sp_DeleteOrderTypeMaster";

    }


}
