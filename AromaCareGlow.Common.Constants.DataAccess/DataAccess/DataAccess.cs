//------------------------------------------------------------------------------ 
// <copyright file="DataAccess.cs" company="AromaCareGlow">
//     Copyright (c) AromaCareGlow LLC.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------ 

namespace AromaCareGlow.Common.Constants.DataAccess
{
    /// <summary>
    ///		This class contains constants for configuration keys of web config file.
    /// </summary>
    public class ConfigKeys
    {
        #region Configuration Keys

        /// <summary>
        ///		Represents  database connection property in config file
        /// </summary>
        public const string DATABASE_CONNECTION = "DatabaseConnection";

        /// <summary>
        ///		Represents  database connection property in config file
        /// </summary>
        public const string DATABASE_CONNECTION_TEST = "DatabaseConnectionTest";

        /// <summary>
        ///		Represents Trusted connection property for connection string in config file
        /// </summary>
        public const string TRUSTEDCONNECTION = "Trusted_Connection";

        /// <summary>
        ///		 Represents server name key for connection string in config file
        /// </summary>
        public const string SERVER = "Server";

        /// <summary>
        ///		Represents database name key for connection string in config file
        /// </summary>
        public const string DATABASE = "Database";

        /// <summary>
        ///		Represents key for user id for connection string in config file
        /// </summary>
        public const string USERID = "UserId";

        /// <summary>
        ///		Represents key for password for connection string in config file
        /// </summary>
        public const string PASSWORD = "Password";

        /// <summary>
        ///     Represents type of database used in this application
        /// </summary>
        public const int DATABASETYPE = 1;

        /// <summary>
        ///     Different types of database supported by the framework.
        /// </summary>
        public enum DatabaseType
        {
            /// <summary>
            ///    MS SQL Server Database
            /// </summary>
            SqlServer = 1,

            /// <summary>
            ///     IBM DB2 Database
            /// </summary>
            DB2 = 2,

            /// <summary>
            ///     Oracle Database
            /// </summary>
            Oracle = 3,

            /// <summary>
            ///     Sybase Database
            /// </summary>
            Sybase = 4,

            /// <summary>
            ///     MY SQL Database
            /// </summary>
            MySql = 5
        }

        #endregion
    }

    /// <summary>
    ///     A class contains constants declaration for Stored procedure names and input output parameters
    /// </summary>
    public class StoredProcedureNames
    {
        #region Common Procedure

        /// <summary>
        ///     Stored procedure name for shipmentcharges procedure.
        /// </summary>
        public const string SP_SHIPMENTCHARGES = "dbo.spGetShipItemCharges";
        /// <summary>
        /// stored procedure for getting customer claim details
        /// </summary>
        public const string SP_GET_CUSTOMER_CLAIMS = "dbo.spGetCustomerClaims";

        /// <summary>
        /// stored procedure for getting selected customer claims details
        /// </summary>
        public const string SP_GET_CUSTOMER_CLAIMS_BY_ID = "dbo.spGetClaimReport";

        /// <summary>
        /// stored procedure for inserting customer claim details
        /// </summary>
        public const string SP_CREATE_CUSTOMER_CLAIM = "dbo.spCreateCustomerClaim";

        /// <summary>
        /// stored procedure for updating customer claim 
        /// </summary>
        public const string SP_UPDATE_CUSTOMER_CLAIM = "dbo.spUpdateCustomerClaim";

        /// <summary>
        ///     Stored procedure name for shipmentgroups procedure.
        /// </summary>
        public const string SP_SHIPMENTUSERS = "dbo.spGetShipmentIndividuals";
        /// <summary>
        ///     Stored procedure name for shipmentgroups procedure.
        /// </summary>
        public const string SP_SHIPMENTGROUPS = "dbo.spGetShipmentGrp";
        /// <summary>
        ///     Stored procedure name for shipmentgroups procedure.
        /// </summary>
        public const string SP_SHIPMENTGROUPSBYCOMPANY = "dbo.spGetShipmentGrpbyCompany";
        /// <summary>
        ///     Stored procedure name for shipmentlist procedure.
        /// </summary>
        public const string SP_SHIPMENTLIST = "dbo.spGetShipmentList";

        /// <summary>
        /// Getting Shipment Address
        /// </summary>
        public const string SP_SHIPADDR = "dbo.spGetShipmentAddress";
        /// <summary>
        ///     Stored procedure name for exception logger procedure.
        /// </summary>
        public const string SP_LOG_EXCEPTION = "dbo.spInsertProcessException";
        /// <summary>
        ///     Stored procedure to save change email data for helpcenter
        /// </summary>

        public const string SP_EMAILSERVICE = "dbo.spGetEmailservice";

        /// <summary>
        ///     Stored procedure to Getr documents for documents bar in menu
        /// </summary>

        public const string SP_DOCUMENTLIST = "dbo.spGetDocumentList";

        /// <summary>
        ///     Stored procedure to save change history data
        /// </summary>
        public const string SP_SAVE_CHANGE_HISTORY = "dbo.spSaveChangeHistory";

        /// <summary>
        ///     Stored procedure to get change history data
        /// </summary>
        public const string SP_GET_CHANGE_HISTORY = "dbo.spGetSystemHistory";

        /// <summary>
        ///     Stored procedure to get change history data
        /// </summary>
        public const string SP_GET_CHANGE_HISTORY_FOR_TYPE = "dbo.spGetSystemHistoryForType";

        /// <summary>
        ///     Object id parameter for history procedures
        /// </summary>
        public const string PARAM_OBJECT_ID = "objectId";

        /// <summary>
        ///     Unique id parameter for history procedures
        /// </summary>
        public const string PARAM_UNIQUE_ID = "uniqueId";

        /// <summary>
        ///     Object type parameter for history procedures
        /// </summary>
        public const string PARAM_OBJECT_TYPE = "objectType";

        /// <summary>
        ///     Object type parameter for history procedures
        /// </summary>
        public const string PARAM_ENTITY_TYPE = "entityType";

        #endregion

        #region [Stored Procedure Names and Parameter]

        /// <summary>
        ///     stored procedure to get netsuite id for customer
        /// </summary>
        public const string SP_GET_NETSUITE_ID_FOR_CUSTOMER = "dbo.spGetNetsuiteInternalIdForCustomer";

        /// <summary>
        ///     stored procedure to get customer financial information eligible for booking
        /// </summary>
        public const string SP_CHECK_CUSTOMER_FINANCIALS = "dbo.spCheckCustomerFinancialStatus";

        /// <summary>
        ///     stored procedure used to do ....
        /// </summary>
        public const string PROC_UPDATE_USER = "dbo.uspUpdateUser";

        /// <summary>
        ///     input parameter used in the update user procedure
        /// </summary>
        public const string PARAM_LOGIN_NAME = "@loginName";

        /// <summary>
        ///     Constant, Stored procedure to get all carriers
        /// </summary>
        public const string SP_GET_CARRIERS = "[dbo].[spGetCarriers]";

        /// <summary>
        ///     Constant, Stored procedure to get all carriers by user id.
        /// </summary>
        public const string SP_GET_CARRIERS_BY_USER_ID = "[dbo].[spGetCarriersByUserID]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_GET_ALLCARRIERNAMES = "[dbo].[spGetAllCarrierNames]";

        /// <summary>
        /// Store procedure for getting all the available trucks.
        /// </summary>
        public const string SP_GET_ALL_AVAILABLETRUCKS = "[dbo].[spGetAllAvailableTrucks]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_LOADBOOKED_BY_BOLNO = "[dbo].[spSearchLoadBookedByBolNo]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_CARRIERS_BY_INITIALS = "[dbo].[spSearchCarriersByInitials]";

        /// <summary>
        /// Store Procedure for getting all the carriers by name
        /// </summary>
        public const string SP_SEARCH_CARRIERS_BY_NAME = "[dbo].[spSearchCarriersByName]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_CUSTOMERS_BY_INITIALS = "[dbo].[spSearchCustomersByInitials]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_CUSTOMERS_BY_COMPANY = "[dbo].[spSearchCustomersByCompany]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_BOL_BY_INITIALS = "[dbo].[spSearchBOLByInitials]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_COMPANIES_BY_INITIALS = "[dbo].[spSearchCompaniesByInitials]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_SHIPPING_ADDRESS_BY_CUSTOMER_INITIALS = "[dbo].[spSearchShippingAddressByCustomerInitials]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_SEARCH_USERS_BY_INITIALS = "[dbo].[spSearchUsersByInitials]";

        /// <summary>
        /// Store procedure for getting all the store procedures
        /// </summary>
        public const string SP_GET_CARRIER_BY_ID = "[dbo].[spGetCarrierById]";

        /// <summary>
        /// stored procedure for getting the carrier and carrier packet details by ID
        /// </summary>
        public const string SP_GET_CARRIER_PACKETS_BY_ID = "[dbo].[spGetCarrierAndPacketDetailsByID]";

        /// <summary>
        ///     Store procedure for storing Load Request information
        /// </summary>
        public const string SP_INSERT_LOAD_REQUEST_QUOTE = "[dbo].[spInsertTruckloadRequest]";

        /// <summary>
        ///     Store procedure for storing Load book information
        /// </summary>
        public const string SP_INSERT_LOAD_BOOKED_QUOTE = "[dbo].[spInsertLoadBooked]";

        /// <summary>
        ///     Store procedure for copying Load book information
        /// </summary>
        public const string SP_COPY_LOAD_BOOKED_QUOTE = "[dbo].[spCopyLoadBooked]";

        /// <summary>
        /// Stored procedure name to store the carriers/carrierLanes in to data base
        /// </summary>
        public const string SP_SAVE_CARRIER_LANES = "[dbo].[spSaveCarriers]";

        /// <summary>
        /// Stored procedure name to Activate the carriers in to data base.
        /// </summary>
        public const string SP_ACTIVATE_CARRIER = "[dbo].[spActivateCarriers]";

        /// <summary>
        ///     Store procedure for updating Load Request information
        /// </summary>
        public const string SP_UPDATE_LOAD_REQUEST_QUOTE = "[dbo].[spUpdateTruckloadRequest]";

        /// <summary>
        ///     Store procedure for updating Load Request information
        /// </summary>
        public const string SP_UPDATE_LOAD_BOOKED_QUOTE = "[dbo].[spUpdateTruckLoadBooked]";

        /// <summary>
        ///     Store procedure for updating Load Summary information
        /// </summary>
        public const string SP_UPDATE_LOAD_SUMMARY = "[dbo].[spUpdateLoadSummary]";

        /// <summary>
        ///     Store procedure for updating Load Request information
        /// </summary>
        public const string SP_GET_LOAD_REQUEST_BY_ID = "[dbo].[spGetLoadRequestById]";

        /// <summary>
        ///     Store procedure for updating quoted Load Request information
        /// </summary>
        public const string SP_GET_LOAD_REQUEST_QUOTE_BY_ID = "[dbo].[spGetLoadRequestQuoteById]";

        /// <summary>
        ///     Store procedure for getting the quoted Load Request information
        /// </summary>
        public const string SP_GET_LOAD_REQUEST_QUOTE_DETAILS_BY_ID = "[dbo].[spGetLoadRequestQuoteDetailsById]";

        /// <summary>
        ///     Store procedure for updating Truck load quote information
        /// </summary>
        public const string SP_COPY_TRUCKLOAD_QUOTE = "[dbo].[spCopyQuoteToReadytobook]";

        /// <summary>
        ///     Store procedure for updating Truck load quote information
        /// </summary>
        public const string SP_UPDATE_TRUCKLOAD_QUOTE = "[dbo].[spUpdateTruckLoadQuote]";

        /// <summary>
        /// Stored Procedure for getting Warehouses and Inventory Information
        /// </summary>
        public const string SP_GET_WAREHOUSE_AND_INVENTORY_INFORMATION = "[dbo].[spGetWareHouseAndInventoryInformation]";

        /// <summary>
        /// Stored procedure for getting Load booked details
        /// </summary>
        public const string SP_GET_LOAD_BOOKED_BY_ID = "[dbo].[spGetLoadBookedById]";

        /// <summary>
        /// Stored procedure for updating the load booked status based on load booked id
        /// and update carrier Packet sent info based on carrier id
        /// </summary>
        public const string SP_UPDATE_STATUS_AND_CARRIER_PACKET_SENT_INFO = "[dbo].[spUpdateStatusAndPacketsSentInfo]";

        /// <summary>
        /// Stored procedure for deleting load request
        /// </summary>
        public const string SP_DELETE_LOAD_REQUEST = "[dbo].[spDeleteTruckloadRequest]";

        /// <summary>
        /// Stored procedure for getting load request status
        /// </summary>
        public const string SP_GET_LOAD_STATUS = "[dbo].[spGetLoadStatus]";

        /// <summary>
        /// Stored procedure for updating the load Request status based on load request ids
        /// </summary>
        public const string SP_UPDATE_STATUS_BY_LOAD_REQUEST_IDS = "[dbo].[spUpdateStatusByLoadRequestId]";

        /// <summary>
        /// Stored procedure for getting the load request details for previous two dates
        /// </summary>
        public const string SP_GET_LOAD_REQUEST_DETAILS_BY_DATES = "[dbo].[spGetLoadRequestByDates]";

        /// <summary>
        /// Stored procedure for getting the load booked details for previous two dates
        /// </summary>
        public const string SP_GET_LOAD_BOOKED_DETAILS_BY_DATES = "[dbo].[spGetLoadBookedByDates]";

        /// <summary>
        /// Stored procedure for getting load request id
        /// </summary>
        public const string SP_GET_LOAD_REQUEST_ID_BY_GUID = "[dbo].[spGetLoadRequestIdByUniqueId]";

        /// <summary>
        /// Stored procedure for getting GUID generated
        /// </summary>
        public const string SP_GET_GUID_GENERATED = "[dbo].[spGetGUIDGenerated]";

        /// <summary>
        ///     stored procedure to authenticate Customer and retrieve his details
        /// </summary>
        public const string SP_AUTHENTICATE_CUSTOMER = "[dbo].spAuthenticateCustomer";

        /// <summary>
        ///  stored procedure to get carriers by given search criteria
        /// </summary>
        public const string SP_GET_CARRIERS_BY_SEARCH_CRITERIA = "[dbo].spSearchCarrierByCriteria";

        /// <summary>
        ///  stored procedure to get frieght match details.
        /// </summary>
        public const string SP_FRIEGHT_MATCH = "[dbo].[spFrieghtMatch]";

        /// <summary>
        ///  stored procedure to get carriers by given search criteria
        /// </summary>
        public const string SP_MERGE_DUPLICATE_CARRIERS = "[dbo].[spUpdateCarrierDuplicates]";

        /// <summary>
        ///  stored procedure to get top 10 customers
        /// </summary>
        public const string SP_GET_TOP_CUSTOMERS = "[dbo].[spGetTopCustomers]";

        /// <summary>
        ///  stored procedure to get top 10 Sales Rep.
        /// </summary>
        public const string SP_GET_TOP_SALESREP = "[dbo].[spGetTopSalesRep]";

        /// <summary>
        ///  stored procedure to get KPI based Orders
        /// </summary>
        public const string SP_GET_KPI_BASED_ORDERS = "[dbo].[spGetKPIBasedOrders]";

        /// <summary>
        ///  stored procedure to get KPI based Orders for Graph
        /// </summary>
        public const string SP_GET_KPI_BASED_ORDERS_FOR_GRAPH = "[dbo].[spGetKPIBasedOrdersForGraph]";

        /// <summary>
        /// stored procedure to insert new quote from postEveryWhere.
        /// </summary>
        public const string SP_INSERT_POSTED_QUOTE = "[dbo].[spInsertPostedQuote]";

        #endregion

        #region Store Procedure Name for BackOffice

        /// <summary>
        ///     Stored Procedure to get invoice details based on invoice id
        /// </summary>
        public const string SP_GET_INVOICE_DETAILS = "dbo.spGetInvoiceDetails";

        /// <summary>
        ///     Stored Procedure to get invoice details
        /// </summary>
        public const string SP_GET_ALL_INVOICES = "dbo.spGetAllInvoices";

        /// <summary>
        /// Store procedure to get sales order details
        /// </summary>
        public const string SP_SAVE_INVOICE_NOTES = "dbo.spSaveShipmentNote";

        /// <summary>
        /// Store procedure to get sales order details
        /// </summary>
        public const string SP_SAVE_INVOICES = "dbo.spInsertInvoiceId";

        /// <summary>
        /// Store procedure to get sales order details
        /// </summary>
        public const string SP_GET_SALES_ORDER_DETAILS = "dbo.spGetSalesOrderDetails";

        /// <summary>
        ///     Required constant variable.
        /// </summary>
        public const string SP_GET_REQUOTE_SALES_ORDER_DETAILS = "dbo.spGetRequoteSalesOrderDetails";

        /// <summary>
        /// Store procedure to get sales order details by BolNumber
        /// </summary>
        public const string SP_GET_SALES_ORDER_DETAILS_BOLNUMBER = "spGetSalesOrderbyBolNumber";

        /// <summary>
        /// Store procedure to get sales order details by all details
        /// </summary>
        public const string SP_GET_SALES_ORDER_DETAILS_BY_ALLDETAILS = "spGetSalesOrderbyALLDetails";

        /// <summary>
        /// Store procedure to get sales order details
        /// </summary>
        public const string SP_MAKE_A_ORDER = "dbo.spSaveASalesOrder";

        /// <summary>
        /// Store procedure to save sales order details
        /// </summary>
        public const string SP_SAVE_SALES_ORDER_DETAILS = "dbo.spSaveSalesOrderDetails";

        /// <summary>
        /// Store procedure to save sales order details
        /// </summary>
        public const string SP_REQUOTE_SAVE_SALES_ORDER_DETAILS = "dbo.spSaveRequoteSalesOrderDetails";

        /// <summary>
        /// Store procedure to update sales order details
        /// </summary>
        public const string SP_UPDATE_SALES_ORDER_DETAILS = "dbo.spUpdateSalesOrderDetails";

        /// <summary>
        /// Store procedure to create new role
        /// </summary>
        public const string SP_CREATE_ROLE = "dbo.spCreateRole";

        /// <summary>
        /// Store procedure to get hierarchy for user
        /// </summary>
        public const string SP_GET_HIERARCHY = "dbo.spGetHierarchy";

        /// <summary>
        ///  strod procedure for getting user hirarchy with additional information for display puprose
        /// </summary>
        public const string SP_GET_HIERARCHY_FOR_USER = "dbo.spGetHierarchyForUser";

        /// <summary>
        /// Store procedure to get hierarchy by company
        /// </summary>
        public const string SP_GET_HIERARCHY_BY_COMPANY = "dbo.spGetHierarchyByCompany";

        /// <summary>
        /// Store procedure to update selected role
        /// </summary>
        public const string SP_UPDATE_ROLE = "dbo.spUpdateRole";

        /// <summary>
        /// Store procedure to get the information about the selected role
        /// </summary>
        public const string SP_GET_ROLE_INFO_BY_ID = "dbo.spGetRoleInfoById";

        /// <summary>
        /// Stored procedure to set visibility for user
        /// </summary>
        public const string SP_SET_VISIBILITY = "dbo.spSaveVisibility";

        /// <summary>
        /// Store procedure to create new role
        /// </summary>
        public const string SP_CREATE_SECURABLE = "dbo.spCreateSecurable";

        /// <summary>
        /// Store procedure to update selected role
        /// </summary>
        public const string SP_UPDATE_SECURABLE = "dbo.spUpdateSecurable";


        /// <summary>
        /// Store procedure to get the securable and Role permission information about the selected securable
        /// </summary>
        public const string SP_GET_SECURABLE_INFO_BY_ID = "dbo.spGetSecurableInfoById";


        /// <summary>
        /// Store procedure to create new employee or user
        /// </summary>
        public const string SP_CREATE_EMPLOYEE = "dbo.spCreateEmployee";

        /// <summary>
        /// Store procedure to UPDATE selected employee
        /// </summary>
        public const string SP_UPDATE_EMPLOYEE_INFO_BY_ID = "dbo.spUpdateEmployeeInfoById";

        /// <summary>
        /// Store procedure to get all employees list
        /// </summary>
        public const string SP_GET_ALL_EMPLOYEES = "dbo.spGetEmpolyeesInformation";

        /// <summary>
        /// Store procedure to get all employees list for specific company
        /// </summary>
        public const string SP_GET_ALL_EMPLOYEES_BY_COMPANY = "dbo.spGetEmpolyeesByCompany";

        /// <summary>
        /// Store procedure to get all non sales rep employees
        /// </summary>
        public const string SP_GET_ALL_NON_SALES_REP_USERS = "dbo.spGetNonSalesRepUsers";

        /// <summary>
        /// Store procedure to get all non sales rep employees
        /// </summary>
        public const string SP_GET_PARENT_USERS_BY_ID = "dbo.spGetParentUsersById";

        /// <summary>
        /// Store procedure to get summary of the customer shipments
        /// </summary>
        public const string SP_GET_CUSTOMER_SHIPMENT_SUMMARY = "dbo.spGetCustomerShipmentSummary";

        /// <summary>
        /// Store procedure to get details of the customer quote details
        /// </summary>
        public const string SP_GET_CUSTOMER_QUOTE_DETAILS = "dbo.spGetCustomerQuoteDetails";

        /// <summary>
        /// Store procedure to get details of the customer shipmentdetails
        /// </summary>
        public const string SP_GET_CUSTOMER_SHIPMENT_DETAILS = "dbo.spGetCustomerShipmentDetails";

        /// <summary>
        /// Store procedure to get details of the customer 
        /// </summary>
        public const string SP_GET_CUSTOMER_BASIC_DETAILS = "dbo.spGetCustomerDetails";

        /// <summary>
        /// Store procedure to get billing address of the master customer by taking company id as parameter
        /// </summary>
        public const string SP_GET_MASTER_CUSTOMER_BILLING_ADDRESS_BY_COMPANY_ID = "dbo.spGetMasterCustomerBillingAddressByCompanyId";

        /// <summary>
        /// Store procedure to get details of the customer sales transactions
        /// </summary>
        public const string SP_GET_CUSTOMER_SALES_TRANSACTIONS = "dbo.spGetCustomerSalesTransactions";

        /// <summary>
        /// Store procedure to get details of the customer estimated orders
        /// </summary>
        public const string SP_GET_CUSTOMER_ESTIMATED_ORDERS = "dbo.spGetCustomerEstimatedOrders";

        /// <summary>
        /// Store procedure to get details of the customer Invoice Orders
        /// </summary>
        public const string SP_GET_CUSTOMER_INVOICE_ORDERS = "dbo.spGetCustomerInvoiceOrders";

        /// <summary>
        /// Store procedure to get details of the customer financial details
        /// </summary>
        public const string SP_GET_CUSTOMER_FINANCIAL_DETAILS = "dbo.spGetCustomerFinancialDetails";

        /// <summary>
        /// Store procedure to get details of the customer sales transactions
        /// </summary>
        public const string SP_GET_CHILD_CUSTOMERS = "dbo.spGetChildCustomers";

        /// <summary>
        /// Store procedure to get details of the customers in a company 
        /// </summary>
        public const string SP_GET_COMPANY_CUSTOMERS = "dbo.spGetCustomersByCompanyId";

        /// <summary>
        /// Store procedure to update customer details
        /// </summary>
        public const string SP_UPDATE_EXISTING_CUSTOMER_DETAILS = "dbo.spUpdateCustomerDetails";

        /// <summary>
        /// Store procedure to create customer details
        /// </summary>
        public const string SP_CREATE_CUSTOMER_DETAILS = "dbo.spCreateCustomerDetails";

        /// <summary>
        /// Stored procedure to insert details of the Master customer into Mass Intermediate DB
        /// </summary>
        public const string SP_INSERT_CUSTOMER_MASS_IDB = "dbo.spInsertMasterCustomerInMassIDB";

        /// <summary>
        /// Store procedure to get information of selected employee or user
        /// </summary>
        public const string SP_GET_EMPLOYEE_INFO_BY_ID = "dbo.spGetEmployeeInfoById";

        /// <summary>
        /// Store procedure to get master carrier and all carrier
        /// </summary>
        public const string SP_GET_CARRIER_BACKOFFICE = "dbo.spGetAllCarriers";

        /// <summary>
        /// Store procedure to get master carrier and all carrier
        /// </summary>
        public const string SP_GET_BLOCK_ZIP_RANGE_BACKOFFICE = "dbo.spGetCarrierBlockZipRangedetails";

        /// <summary>
        /// Store procedure to get carrier details for the fee discount FAK for carrierid
        /// </summary>
        public const string SP_GET_CARRIER_DETAILS_BACKOFFICE = "[dbo].[spGetCarriersFeeDetailsByCarrierID]";

        /// <summary>
        /// Store procedure to get carrier details for the fee discount FAK for carrierid
        /// </summary>
        public const string SP_GET_CARRIER_PRIORITY_BACKOFFICE = "[dbo].[spGetCarriersPriorityDetailsByCarrierID]";

        /// <summary>
        /// Store procedure to get address information of all customers
        /// </summary>
        public const string SP_GET_CUSTOMER_ADDRESSES = "dbo.spGetCustomerAddresses";

        /// <summary>
        /// Store procedure to get address information of speified customer by ID
        /// if address is not blocked
        /// </summary>
        public const string SP_GET_CUSTOMER_ADDRESS_BILL_RES_BY_ID = "dbo.spGetCustomerResBillingAddressesById";

        /// <summary>
        /// Store procedure to get address information of all customers
        /// </summary>
        public const string SP_UPDATE_CARRIER = "dbo.spUpdateCarriers";

        /// <summary>
        /// Store procedure to create or register customer
        /// </summary>
        public const string SP_CREATE_CUSTOMER = "dbo.spCreateCustomer";

        /// <summary>
        /// Store procedure to create or register customer from Customer site
        /// </summary>
        public const string SP_SAVE_CUSTOMER = "dbo.spSaveCustomer";

        /// <summary>
        /// Store procedure to create or register customer from Customer site
        /// </summary>
        public const string SP_INSERT_QUOTE_DETAILS = "dbo.spInsertQuoteDetails";

        /// <summary>
        /// Store procedure to insert/update the Invoice Ministatement & Ministatement Details
        /// </summary>
        public const string SP_SAVE_INVOICE_MINISTATEMENT = "spSaveInvoiceMinistatement";

        /// <summary>
        /// Store procedure to delete the Invoice Ministatement details
        /// </summary>
        public const string SP_DELETE_INVOICE_MINISTATEMENT = "spDeleteInvoiceMinistatement";

        /// <summary>
        /// Store procedure to fetch the Invoice Ministatement details
        /// </summary>
        public const string SP_GET_INVOICE_MINISTATEMENT = "spGetInvoiceMinistatements";

        /// <summary>
        /// Store procedure to UPDATE customer
        /// </summary>
        public const string SP_UPDATE_CUSTOMER = "dbo.spUpdateCustomer";

        /// <summary>
        /// Store procedure to get customer information(personal,address and comany) by using customer ID
        /// </summary>
        public const string SP_GET_CUSTOMER_INFO_BY_ID = "dbo.spGetCustomerInformationById";

        /// <summary>
        /// Store procedure to get customer information(personal,address and comany only billing address) by using customer ID
        /// </summary>
        public const string SP_GET_CUSTOMER_INFO = "dbo.spGetCustomerInformation";

        /// <summary>
        /// Stored procedure to  get customer residential and billing addresses while viewing customer address
        /// in Customer Search Result Grid
        /// </summary>
        public const string SP_GET_CUSTOMER_RES_BILLING_ADDRESSES = "dbo.spGetCustomerResBillingAddresses";

        /// <summary>
        /// to add customer product or item
        /// </summary>
        public const string SP_ADD_CUSTOMER_PRODUCT = "dbo.spAddCustomerProduct";

        /// <summary>
        /// to add customer note
        /// </summary>
        public const string SP_ADD_CUSTOMER_NOTE = "dbo.spAddCustomerNote";

        /// <summary>
        /// to get list of customer notes
        /// </summary>
        public const string SP_GET_CUSTOMER_NOTES = "dbo.spGetCustomerNotes";

        /// <summary>
        /// to delete customer product or item
        /// </summary>
        public const string SP_DELETE_CUSTOMER_PRODUCT = "dbo.spDeleteCustomerProduct";

        /// <summary>
        /// to update customer residentail and billing address numbers in Customer Seacrh Option
        /// </summary>
        public const string SP_UPDATE_CUSTOMER_ADDRESS_NUMBERS = "dbo.spUpdateCustomerAddressNumbers";

        /// <summary>
        /// to get customer residentail and billing address numbers in Customer Seacrh Option
        /// </summary>
        public const string SP_GET_CUSTOMER_ADDRESS_NUMBERS = "dbo.spGetCustomerAddressNumbers";

        /// <summary>
        /// to get customer residentail and billing address numbers in Customer Seacrh Option
        /// </summary>
        public const string SP_GET_SHIPMENT_BOOKED_DETAILS = "dbo.spGetShipmentBookedDetails";

        /// <summary>
        /// Store procedure to get customer Products
        /// </summary>
        public const string SP_GET_CUSTOMER_PRODUCTS = "dbo.spGetCustomerProductList";

        /// <summary>
        /// Store procedure to  get all carriers realted to customer,not related to customer,unblocked and 
        /// carriers in block list while "customer profile edit" and carriers added for perticular customer along with their 
        ///  Profit,Block,Fee,Cost and Discount details
        /// </summary>
        public const string SP_GET_CUSTOMER_SPECIFIC_CARRIER_DETAILS = "dbo.spGetCustomerSpecificCarrierDetails";

        /// <summary>
        /// Store procedure to add carriers for perticular customer along with customer specific pricing
        /// </summary>
        public const string SP_ADD_CARRIERS_FOR_CUSTOMER = "dbo.spAddCarriersForCustomer";

        /// <summary>
        /// Store procedure to add carriers for perticular customer along with customer specific pricing
        /// </summary>
        public const string SP_UPDATE_CUSTOMER_SPECIFIC_CARRIER_DETAILS = "dbo.spUpdateCustomerSpecificCarrierDetails";

        /// <summary>
        /// Store procedure to delete customer specific carrier
        /// </summary>
        public const string SP_DELETE_CUSTOMER_SPECIFIC_CARRIER = "dbo.spDeleteCustomerSpecificCarrier";

        /// <summary>
        /// Store procedure to delete customer last booked orders
        /// </summary>
        public const string SP_DELETE_CUSTOMER_BOOKED_ORDERS = "dbo.spDeleteCustomerBookedOrders";

        /// <summary>
        /// Store procedure to delete carrier zip range pricing details
        /// </summary>
        public const string SP_DELETE_CARRIER_ZIP_RANGE_PRICING = "dbo.spDeleteCarrierZipPricingdetails";

        /// <summary>
        /// Store procedure to get carrier and tarriff record information
        /// </summary>
        public const string SP_CARRIER_PRICING = "[dbo].[spGetCarriersPricing]";

        /// <summary>
        /// Stored procedure for deleting the quick request quote row.
        /// </summary>
        public const string SP_DELETE_QUICK_REQUEST_QUOTE = "dbo.spDeleteQuickRequestQuote";

        #region Auto Notification Services

        /// <summary>
        /// Stored procedure to get all the unprocessed invoices for the sending email purpose.
        /// </summary>
        public const string SP_UNPROCESSED_INVOICES = "[dbo].[spGetUnprocessedInvoices]";

        /// <summary>
        /// Stored procedure to get all the invoices for periodic statement, for sending email purpose.
        /// </summary>
        public const string SP_INVOICES_PERIODIC_STATEMENT = "[dbo].[spGetInvoicePeriodicStatement]";

        /// <summary>
        /// Procedure to update the invoice mail status for the invoices email has been sent from the 
        /// auto notification email service
        /// </summary>
        public const string SP_UPDATE_INVOICE_MAIL_STATUS = "dbo.spUpdateInvoiceMailStatus";

        /// <summary>
        /// Procedure to get the customer statement for invoices, based on the selection from Invoice Listing page.
        /// </summary>
        public const string SP_CUSTOMER_STATEMENT_FOR_INVOICES = "dbo.spGetInvoicesForCustomerStatement";

        /// <summary>
        /// Stored procedure to get whether logged in customer has exceeded the credit limit for shipment or not
        /// </summary>
        public const string SP_CHECK_FINANCIAL_STATUS = "dbo.CheckFinancialStatus";

        /// <summary>
        /// Stored procedure to get all the Tracking details for the shipments which has tracking records
        /// for the current date.
        /// </summary>
        public const string SP_SHIPMENT_TRACKINGDETAILS = "[dbo].[spGetTrackingDetailsByCreatedDate]";

        /// <summary>
        /// Stored procedure for getting the customer settings for the shipments which has the track records
        /// for the current date.
        /// </summary>
        public const string SP_SHIPMENT_CUSTOMERSETTINGS = "[dbo].[spGetCustomerSettingsForShipmentTrackingByCreatedDate]";

        #endregion Auto Notification Services

        /// <summary>
        /// Stored Procedure to get the carrier surcharge.
        /// </summary>
        public const string SP_CARRIER_SURCHARGE = "[dbo].[spGetCarrierSurcharge]";

        /// <summary>
        /// Stored procedure on Insert/Update block carrier for service and FAK details.
        /// </summary>
        public const string SP_SAVE_BLOCKCARRIERFOR_SERVICES_FAKS = "[dbo].[spUpdateBlockCarrierForServicesFAKs]";

        /// <summary>
        /// Stored Procedure update the carrier surcharge details.
        /// </summary>
        public const string SP_UPDATE_CARRIER_SURCHARGE = "[dbo].[spBulkUpdateCarrierSurcharge]";

        /// <summary>
        /// Store procedure to get carrier and tarriff record information
        /// </summary>
        public const string SP_CARRIER_DETAILS_BY_ID_PRIORITY = "spGetCarriersDetailsByCarrierIDPriority";

        /// <summary>
        /// Store procedure to get carrier and tarriff record information
        /// </summary>
        public const string SP_NEW_CARRIERS_LIST = "spGetNewCarriersList";

        /// <summary>
        /// Store procedure to get carrier and tarriff record information
        /// </summary>
        public const string SP_UPDATE_NEW_CARRIERS_LIST = "spUpdateNewCarrierList";

        /// <summary>
        /// Store procedure to get spGetNewCustomers
        /// </summary>
        public const string SP_GET_NEW_CUSTOMERS = "dbo.spGetNewCustomers";
        /// <summary>
        /// Store procedure to get spGetNewCustomers for Plc
        /// </summary>
        public const string SP_GET_NEW_PLCCUSTOMERS = "dbo.spGetNewCustomersForPLC";
        /// <summary>
        /// Store procedure to UPDATE NewCustomers
        /// </summary>
        public const string SP_UPDATE_NEW_CUSTOMERS = "dbo.spUpdateNewCustomerList";

        /// <summary>
        /// Store procedure to SP_PENDING_REQUEST_QUOTE
        /// </summary>
        public const string SP_PENDING_REQUEST_QUOTE = "spGetPendingRequestQuotes";

        /// <summary>
        /// Store procedure to SP_PENDING_REQUEST_QUOTE_BY_QUOTEID
        /// </summary>
        public const string SP_PENDING_REQUEST_QUOTE_BY_QUOTEID = "dbo.spGetPendingRequestQuotesByQuoteId";

        /// <summary>
        /// Store procedure to get users by criteria
        /// </summary>
        public const string SP_SEARCH_USERS_BY_CRITERIA = "dbo.spSearchUsersByInitials";

        /// <summary>
        /// Store procedure to get carriers by criteria
        /// </summary>
        public const string SP_SEARCH_CARRIERS_BY_CRITERIA = "dbo.spSearchCarrierByCriteria";

        /// <summary>
        /// Store procedure to SP_INSERT_UPDATE_CARRIERIS
        /// </summary>
        public const string SP_INSERT_UPDATE_CARRIERIS = "[dbo].[spInsertUpdateCarrierDetails]";

        /// <summary>
        /// Store procedure to save notification details
        /// </summary>
        public const string SP_SAVE_NOTIFICATION_DETAILS = "[dbo].[spSaveNotificationDetails]";

        /// <summary>
        /// Stored procedure for fetching scenarions for subscribe/unsubscribe.
        /// </summary>
        public const string SP_GET_SCENARIOS_FOR_UNSUBSCRIBE = "[dbo].[spGetNotificationScenariosForUnsubscribe]";

        public const string SP_SAVE_SCENARIOS_FOR_UNSUBSCRIBE = "[dbo].[spSaveUnsubscribeScenarioNotifications]";

        /// <summary>
        /// Store procedure to get sales orderboard deatails
        /// </summary>
        public const string SP_GET_SALEORDERBOARD_DETAILS = "[dbo].[spGetSalesOrderBoardDetails]";

        /// <summary>
        /// Store procedure to get sales orderboard deatails
        /// </summary>
        public const string SP_FIND_MATCHING_SALESORDER = "[dbo].[spFindMatchingSalesOrderByCriteria]";

        /// <summary>
        /// Store procedure to get sales orderboard deatails
        /// </summary>
        public const string SP_UPDATE_SALESORDER_STATUS = "[dbo].[spUpdateSalesOrderStatus]";
        /// <summary>
        /// Store procedure to save vendor bill
        /// </summary>
        public const string SP_SAVE_VENDOR_BILL = "[dbo].[spSaveVendorBill]";
        /// <summary>
        /// Store procedure to get vendor bill details 
        /// </summary>
        public const string SP_GET_VENDOR_BILL = "[dbo].[spGetVendorBill]";
        /// <summary>
        /// Store procedure to get purchase order
        /// </summary>
        public const string SP_GET_PURCHASE_ORDER = "[dbo].[spGetPurchaseOrder]";
        /// <summary>
        /// Store procedure to get vendor bill details 
        /// </summary>
        public const string SP_GET_PO_POSSIBILITY = "[dbo].[spGetPOPossibility]";
        /// <summary>
        /// Store procedure to get Requote Board details 
        /// </summary>
        public const string SP_GET_REQUOTE_BOARD_DETAILS = "[dbo].[spGetRequoteBoardDetails]";
        /// <summary>
        /// Store procedure to get Dispute details 
        /// </summary>
        public const string SP_GET_DISPUTE_BOARD_DETAILS = "[dbo].[spGetDisputeBoardDetails]";



        #endregion

        #region Store Procedure Name for Warehouse

        /// <summary>
        ///     Store procedure to Update walmart tracking information
        /// </summary>
        public const string SP_UPDATE_WALMART_PO_TRACKING = "dbo.spUpdateWalMartPurchaseOrderTracking";

        /// <summary>
        ///     Stored Procedure to insert PO tracking information on getting edi 856.
        /// </summary>
        public const string SP_INSERT_WALMART_PO_TRACKING = "dbo.spInsertWalMartPOTracking";

        /// <summary>
        ///     Store procedure to Insert and Update walmart CSV PO tracking information
        /// </summary>
        public const string SP_INSERT_UPDATE_WALMART_CSV_PO_TRACKING = "dbo.spSaveCSVPurchaseOrders";

        /// <summary>
        ///     Store procedure to Cancel CSV Orders.
        /// </summary>
        public const string SP_CANCEL_CSV_PURCHASE_ORDERS = "dbo.spCancelCSVPurchaseOrders";

        /// <summary>
        ///     To insert edi data error details.
        /// </summary>
        public const string SP_INSERT_EDI_ERROR_DETAILS = "dbo.spInsert824ErrorDetails";

        /// <summary>
        ///     To insert 850 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_850 = "dbo.spInsertEdi850File";

        /// <summary>
        ///     To insert 855 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_855 = "dbo.spInsertEdi855File";

        /// <summary>
        ///     To insert 856 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_856 = "dbo.spInsertEdi856File";

        /// <summary>
        ///     To insert 997 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_997 = "dbo.spInsertEdi997File";

        /// <summary>
        ///     To insert 824 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_824 = "dbo.spInsertEdi824File";

        /// <summary>
        ///     To insert 860 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_860 = "dbo.spInsertEdi860File";

        /// <summary>
        ///     To insert 204 edi file information.
        /// </summary>
        public const string SP_INSERT_EDI_204 = "dbo.spInsertEdi204File";

        /// <summary>
        ///  To Update PO details and status on getting edi 855.
        /// </summary>
        public const string SP_UPDATE_PURCHASE_ORDER_DETAILS = "dbo.spUpdateWalMartPurchaseOrderDetail";

        /// <summary>
        ///     Store procedure to Get walmart tracking information
        /// </summary>
        public const string SP_GET_WALMART_TRACKING = "dbo.spGetWalMartTracking";

        /// <summary>
        ///     Stored Procedure to Get ASN Serial Reference number.
        /// </summary>
        public const string SP_GET_ASN_SERIAL_REFERENCE = "dbo.spGetAsnSerialReference";

        /// <summary>
        ///     Stored Procedure to Get Account Number for Warehouse Carrier.
        /// </summary>
        public const string SP_GET_ACCOUNT_NUMBER = "dbo.spGetAccountForWarehouseCarrier";

        /// <summary>
        ///     Stored proc to get InternalVendorNumber from Vendors for give Item.
        /// </summary>
        public const string SP_GET_IA_NUMBER = "dbo.spGetIAForSKU";

        /// <summary>
        ///     Stored Procedure to Get item's balance quantity from inventory.
        /// </summary>
        public const string SP_GET_INVENTORY_BALANCE_QUANTITY = "dbo.spGetBalanceQtyFromInventory";

        /// <summary>
        ///     Stored Procedure to get warehouse for given purchaseOrder.
        /// </summary>
        public const string SP_GET_WAREHOUSE_FOR_PO = "dbo.spGetWarehouseForPurchaseOrder";

        /// <summary>
        ///     Store procedure to Get walmart Purchase Orders information
        /// </summary>
        public const string SP_GET_WALMART_PO = "dbo.spGetWalmartPurchaseOrders";

        /// <summary>
        ///     Store procedure to Get SKUs information
        /// </summary>
        public const string SP_GET_SKU = "dbo.spGetSKUs";

        /// <summary>
        ///     Store procedure to Get SKUs information
        /// </summary>
        public const string SP_GET_SKU_ITEM_LIST = "dbo.spGetSKUITEMLIST";

        /// <summary>
        ///     Store procedure to Get SKUs information for Customer
        /// </summary>
        public const string SP_GET_SKU_ITEM_LIST_FOR_CUSTOMER = "dbo.spGetSKUITEMLISTForCustomer";

        /// <summary>
        ///     Store procedure to update vendor PO information
        /// </summary>
        public const string SP_UPDATE_VENDOR_POS = "dbo.spUpdateVendorPurchaseOrders";

        /// <summary>
        ///     Store procedure to update vendor PO and adjust Inventory
        /// </summary>
        public const string SP_UPDATE_VENDOR_POS_INVENTORY_ADJUST = "dbo.spUpdateVendorPurchaseOrdersInventoryAdjust";

        /// <summary>
        ///     Store procedure to update vendor PO Details information
        /// </summary>
        public const string SP_UPDATE_PO_DETAILS = "dbo.spUpdatePODetails";

        /// <summary>
        ///     Store procedure to Get vendor PO Details information
        /// </summary>
        public const string SP_GET_VENDOR_PO_DETAILS = "dbo.spGetVendorPODetails";

        /// <summary>
        ///     Store procedure to Get vendor PO for Given Vendor information
        /// </summary>
        public const string SP_GET_VENDOR_PO_FOR_VENDOR = "dbo.spGetVendorPOForVendor";

        /// <summary>
        ///     Store procedure to Get PODetails on search criteria.
        /// </summary>
        public const string SP_SEARCH_PO_DETAILS = "dbo.spSearchPODetails";

        /// <summary>
        ///     Store procedure to update inventory and inventory history information
        /// </summary>
        public const string SP_UPDATE_INVENTORY_INVENTORY_HISTORY = "dbo.spUpdateInventoryAndInventoryHistory";

        /// <summary>
        ///      Store procedure to Get inventory information
        /// </summary>
        public const string SP_GET_INVENTORY = "dbo.spGetInventory";

        /// <summary>
        ///     Store procedure to Get SKU for given vendor information
        /// </summary>
        public const string SP_GET_ALL_SKU_FOR_VENDOR = "dbo.spGetAllSKUForVendor";

        /// <summary>
        ///     Store procedure to Get SKU for CSV vendor information
        /// </summary>
        public const string SP_GET_ALL_SKU_FOR_CSV_VENDOR = "dbo.spGetAllSKUForCSVVendor";

        /// <summary>
        ///     Stored proc to Get sku for given sku number.
        /// </summary>
        public const string SP_GET_SKU_FOR_SKU_NUMBER = "dbo.spGetSKUForGiveSKUNumber";

        /// <summary>
        ///     Store procedure to Insert vendor po details information
        /// </summary>
        public const string SP_INSERT_VENDOR_PO_DETAILS = "dbo.spInsertVendorPODetails";

        /// <summary>
        ///     Store procedure to get active skus information
        /// </summary>
        public const string SP_GET_ALL_ACTIVE_SKU_FOR_VENDOR = "dbo.spGetAllActiveSKUForVendor";

        /// <summary>
        ///     Store procedure to insert PO and podetails information
        /// </summary>
        public const string SP_INSERT_PO_AND_PODETAILS = "dbo.spInsertPurchaseOrderAndPODetails";

        /// <summary>
        ///     Stroed procedure to get inventory for date.
        /// </summary>
        public const string SP_GET_INVENTORY_BY_DATE = "dbo.spGetInventoryByDate";

        /// <summary>
        ///     Store procedure to Update skus information
        /// </summary>
        public const string SP_UPDATE_SKU = "dbo.spUpdateSKUs";

        /// <summary>
        ///     Store procedure to insert skus information
        /// </summary>
        public const string SP_INSERT_SKU = "dbo.spInsertSKU";

        /// <summary>
        ///     Store procedure to get inventory pallet information
        /// </summary>
        public const string SP_GET_INVENTORY_PALLET_INFO = "dbo.spGetInventoryPalletInfo";

        /// <summary>
        ///     Store procedure to Merge pallet forecast information
        /// </summary>
        public const string SP_MERGE_PALLET_FORECAST = "dbo.spMergePalletForecast";

        /// <summary>
        ///     Store procedure to get warehouse for given vendor information
        /// </summary>
        public const string SP_GET_WAREHOUSES_FOR_VENDOR = "dbo.spGetWareHousesForVendor";

        /// <summary>
        ///     Stored procedure to get purchaseOrder and its Items details.
        /// </summary>
        public const string SP_GET_WALMART_PO_DETAILS = "dbo.spGetWalMartPurchaseOrderDetails";

        /// <summary>
        ///     Stored procedure to get edi fileNames for backOrdering.
        /// </summary>
        public const string SP_GET_BACKORDER_PO_DETAILS = "dbo.spGetBackOrderPOs";

        /// <summary>
        ///     Store procedure to get PO for given vendor information
        /// </summary>
        public const string SP_GET_PO_BY_VENDOR_ID = "dbo.GetPOByVendorId";

        /// <summary>
        ///     Store procedure to get Customers company Details information
        /// </summary>
        public const string SP_GET_CUSTOMER_COMPANY_DETAILS = "dbo.spGetCustomerCompanyDetails";

        /// <summary>
        ///     Store procedure to get WalMart Customers company Details information
        /// </summary>
        public const string SP_GET_WALMART_CUSTOMER_COMPANY_DETAILS = "dbo.spGetWalMartCustomerCompanyDetails";

        /// <summary>
        ///     Store procedure to get Customers , company  and warehouse Details information
        /// </summary>
        public const string SP_GET_CUSTOMER_WAREHOUSE_DETAILS = "dbo.spGetCustomerWarehouseDetails";

        /// <summary>
        ///     Store procedure to insert vendor warehouse Details information
        /// </summary>
        public const string SP_ADD_VENDOR_WAREHOUSE = "dbo.spAddVendorWarehouse";

        /// <summary>
        ///     Store procedure to insert vendor warehouse,WalMart Details information
        /// </summary>
        public const string SP_ADD_VENDOR_WAREHOUSE_WALMART = "dbo.spAddWalMartVendorWarehouse";

        /// <summary>
        ///     Store procedure to Merge vendors information
        /// </summary>
        public const string SP_MERGE_VENDORS = "dbo.spMergeVendors";

        /// <summary>
        ///     Store procedure to Merge vendors information
        /// </summary>
        public const string SP_MERGE_WALMART_VENDORS = "dbo.spMergeWalMartVendors";

        /// <summary>
        ///     Store procedure to Process CSV Orders.
        /// </summary>
        public const string SP_PROCESS_CSV_PURCHASE_ORDER = "dbo.spProcessCSVPurchaseOrder";

        /// <summary>
        ///     Store procedure to get Processed CSV Orders.
        /// </summary>
        public const string SP_GET_PROCESSED_CSV_ORDERS = "dbo.spGetProcessedCSVOrders";

        /// <summary>
        ///      Store procedure to get inventory Audit information
        /// </summary>
        public const string SP_GET_INVENTORY_AUDIT = "dbo.spGetInventoryAudit";

        /// <summary>
        ///      Store procedure to get all sku for warehouse information
        /// </summary>
        public const string SP_GET_ALL_SKU_FOR_WAREHOUSE = "dbo.spGetAllSKUForWarehouse";

        /// <summary>
        /// Store procedure to delete vendor po details row.
        /// </summary>
        public const string SP_DELETE_VENDORPODETAIL_ROW = "DBO.DeleteVendorPODetailRow";

        /// <summary>
        ///     Store procedure to update vendor po and vendor po details from web.
        /// </summary>
        public const string SP_UPDATE_VENDOR_FORWEB = "dbo.spUpdateVendorPOForWEB";

        /// <summary>
        /// To insert new warehouses. 
        /// </summary>
        public const string SP_INSERT_WAREHOUSE = "dbo.spInsertWarehouse";

        /// <summary>
        ///  To update warehouses. 
        /// </summary>
        public const string SP_UPDATE_WAREHOUSE = "dbo.spUpdateWarehouse";

        /// <summary>
        /// To insert only the po details during the updation of VendorPO time.
        /// </summary>
        public const string SP_INSERT_POVENDOR_UPDATETIME = "dbo.spInsertVendorPODetails_UpdateTime";

        /// <summary>
        ///  To GET SKU details when vendor is null or greater than zero. 
        /// </summary>
        public const string SP_GET_VENDOR_SKUs_ALL = "dbo.spGetSKUInfo";

        /// <summary>
        ///  Show Geographicalwise Information of Items shipped. 
        /// </summary>
        public const string SP_GET_GEOGRAPHICAL_SHIPPED_STATE_ALL = "dbo.spgetGeographicalSkuDetails";

        /// <summary>
        ///  Get Email Id's of Warehouse and Vendor. 
        /// </summary>
        public const string SP_GET_WAREHOUSE_VENDOR_EMAIL = "dbo.spGetWarehouseVendorEmail";

        /// <summary>
        ///     Insert accepted PO.
        /// </summary>
        public const string SP_INSERT_INSERT_ACCEPTED_PO = "dbo.spInsertAcceptedPO";

        /// <summary>
        ///     Get edi information for walmart po.
        /// </summary>
        public const string SP_GET_EDI_FOR_WALMART_PO = "dbo.spGetEdiForWalmartPO";

        /// <summary>
        ///     get edi information.
        /// </summary>
        public const string SP_GET_EDI_INFORMATION = "dbo.spGetEdiInformation";
        #endregion

        #region Store Procedure Name for FMS

        /// <summary>
        ///     Get the shipment type of the given shipmentID or bolID
        /// </summary>
        public const string SP_GET_SHIPMENT_TYPE = "dbo.spGetShipmentType";

        /// <summary>
        ///     Get the customer details according to the customer id 
        /// </summary>
        public const string SP_GET_CUSTOMER_DETAILS_BY_ID = "dbo.spGetCustomerDetailsById";

        /// <summary>
        ///     Used to update the customer details
        /// </summary>
        public const string SP_UPDATE_CUSTOMER_DETAILS = "spUpdateCustomerDetails";

        /// <summary>
        ///     Used to update the ShipmentNotes
        /// </summary>
        public const string SP_INSERT_NOTES = "spInsertNotes";

        /// <summary>
        ///     Used to update the ShipmentNotes
        /// </summary>
        public const string SP_GET_NOTES = "spGetNotes";

        /// <summary>
        ///     Used to update the customer password
        /// </summary>
        public const string SP_UPDATE_CUSTOMER_PASSWORD = "dbo.spUpdatePassword";

        /// <summary>
        ///     Get the user details according to customer id.
        /// </summary>
        public const string SP_GET_USER_BY_CUSTOMER_ID = "dbo.spGetUserByCustomerId";

        /// <summary>
        ///     Get the authenticate customer details.
        /// </summary>
        public const string SP_AUTHENTICATE_CUSTOMER_FOR_FMS = "dbo.spAuthenticateCustomerForFMS";

        /// <summary>
        ///     Get the customer details based on the customerId
        /// </summary>
        public const string SP_GET_CUSTOMER_DETAILS = "dbo.spGetCustomerDetails";

        /// <summary>
        ///     Update the customer group details
        /// </summary>
        public const string SP_SAVE_CUSTOMER_GROUP_DETAILS = "spSaveCustomerGroupDetails";

        /// <summary>
        ///     Used to delete the company group
        /// </summary>
        public const string SP_DELETE_COMPANY_GROUP = "spDeleteCompanyGroup";

        /// <summary>
        ///     Get the customer details based on the "@CustomerId", 
        ///     an optional parameter "@ReferenceNo" is passed for search functionality
        /// </summary>
        public const string SP_GET_SAVED_QUOTES = "dbo.spGetSavedQuoteDetails";

        /// <summary>
        ///     Get the item details of the given savedQuoteID
        /// </summary>
        public const string SP_GET_SAVED_QUOTE_ITEMS = "dbo.spGetSavedQuoteItems";

        /// <summary>
        ///     Get the saved quote's charges breakup, provided savedQuoteID and CarrierServiceType
        /// </summary>
        public const string SP_GET_SAVED_QUOTE_CHARGES_BREAKUP = "dbo.spGetSavedQuoteChargesBreakup";

        /// <summary>
        /// Getting Saved Quote Guaranteed Breakup Charges
        /// </summary>
        public const string SP_GET_SAVED_QUOTE_GUARANTEEDCHARGES_BREAKUP = "dbo.spGetSavedQuoteGuaranteedChargesBreakup";

        /// <summary>
        ///     Takes "SavedQuoteId" as input parameter and deletes the saved quote record 
        ///     corresponding to the given id and all other related records (if any)
        /// </summary>
        public const string SP_DELETE_SAVED_QUOTE = "dbo.spDeleteSavedQuote";

        /// <summary>
        /// Retrieved the image / logo of the carrier, provided the CarrierID
        /// </summary>
        public const string SP_GET_CARRIER_IMAGE = "dbo.spGetCarrierImage";

        /// <summary>
        /// Retrieved the image / logo of the carrier, provided the CarrierID
        /// </summary>
        public const string SPGETSHIPMENTPRINTIMAGES = "dbo.spGetShipmentPrintImages";

        /// <summary>
        /// Updating the orderstatus in bolstatus table taking the bolnumber as input parameter
        /// </summary>
        public const string SP_UPDATE_ORDERSTATUS = "dbo.spUpdateOrderStatus";

        /// <summary>
        /// To retrieve the shipment details
        /// </summary>
        public const string SP_GET_SHIPMENT_BOLDETAILS = "dbo.spGetShipmentBolDetails";

        /// <summary>
        /// To retrieve shipment based on date
        /// </summary>
        public const string SP_GET_SHIPMENT_DETAILS_BYDATE = "dbo.spGetShipmentDetailsByDate";


        /// <summary>
        /// Retrieved the pallet charges for different carrier
        /// </summary>
        public const string SP_GET_PALLETCHARGES = "dbo.spGetPalletChargesDetails";


        /// <summary>
        /// Gets the customers addresses, provided customerid, origin zip and destination zip codes
        /// </summary>
        public const string SP_GET_SHIPMENT_ADDRESS = "dbo.spGetCustomerShipmentAddress";

        /// <summary>
        /// Gets the customers addresses, provided customerid, origin zip and destination zip codes
        /// </summary>
        public const string SP_GET_CUSTOMERADDRESS = "dbo.spGetCustomerAddress";

        /// <summary>
        /// Deletes the customer address from CustomerAddress Table, provided "AddressID"
        /// </summary>
        public const string SP_DELETE_CUSTOMERADDRESS = "dbo.spDeleteCustomerAddress";

        /// <summary>
        /// Inserts all the details related to shipment
        /// </summary>
        public const string SP_INSERT_SHIPMENT_DETAILS = "dbo.spInsertShipmentDetails";

        /// <summary>
        /// Inserting save quote details
        /// </summary>
        public const string SP_INSERT_SAVEDQUOTEDETAILS = "dbo.spInsertSaveQuoteDetails";

        /// <summary>
        /// Inserting save quote details
        /// </summary>
        public const string SP_INSERTUPDATE_INSURANCEVALUES = "dbo.spInsertUpdateInsuranceValues";


        /// <summary>
        /// Selects all the data related to the given BOL no and fills it to the typed dataset.
        /// </summary>
        public const string SP_GET_BOLSHIPMENTINFO = "spGetBolShipmentInfo";

        /// <summary>
        /// Selects all data related to tracking page and returns the values.
        /// </summary>
        public const string SP_GET_TRACKINGDETAILS = "dbo.spGetTrackingDetails";

        ///<summary>
        ///Select default Label Dimension of Customer based on given input customerid
        ///</summary>
        public const string SP_GET_DEFAULT_CUSTOMERLABEL = "dbo.spGetCustomerDefaultLabelName";

        /// <summary>
        /// select savedquote details for QuoteDetails.xsd
        /// </summary>
        public const string SP_GETSCHEDULEPICKUPQUOTEDETAILS = "spGetSchedulePickupQuoteDetails";

        /// <summary>
        /// select savedquote details for ShipmentQuoteDetails.xsd
        /// </summary>
        public const string SP_GETSCHEDULEPICKUPSHIPMENTQUOTEDETAILS = "spGetSchedulePickupShipmentQuoteDetails";
        ///<summary>
        ///Insert or update  Labelid in customer table 
        ///</summary>
        public const string SP_UPDATE_CUSTOMERLABELDIMENSION = "dbo.InsertOrModifyCustomerLabelId";

        /// <summary>
        ///     This is used to map the customer terms
        /// </summary>
        public const string SP_CHECK_CUSTOMER_TERMS = "dbo.spCheckCustomerTerms";

        ///<summary>
        ///Insert or update  Labelid in customer table 
        ///</summary>
        public const string SP_INSERT_LOWEST_QUOTE = "dbo.[spInsertLowestQuoteDetails]";

        /// <summary>
        ///     Used to update the customer details
        /// </summary>
        public const string SP_GET_INVOICE_MINISTATEMENT_DETAILS = "dbo.spGetInvoicesAndMinistatements";


        #endregion

        #region Stored Procedure Name for EDIAutomation

        /// <summary>
        /// Stored procedure for getting the load booked details for previous two dates
        /// </summary>
        public const string SP_INSERT_214_EDI_DETAILS = "[dbo].[spInsert214EdiDetails]";

        /// <summary>
        /// Stored procedure for adding Tracking Details to DB
        /// </summary>
        public const string SP_ADD_TRACKING_DETAILS = "[dbo].[spAddTrackingDetails]";

        /// <summary>
        ///     Procedure which is ued to retrive the edi 204 file count
        /// </summary>
        public const string SP_GET_EDI204_FILECOUNT = "[dbo].[spGetEDI204FileCount]";

        /// <summary>
        ///     Procedure which is ued to retrive the edi 204 file count
        /// </summary>
        public const string SP_GET_EDI204_CONTROLNUMBER = "[dbo].[spGetEDIControlNumber]";

        /// <summary>
        ///     Procedure which is ued to retrive the carrier settings
        /// </summary>
        public const string SP_GET_CARRIER_SETTINGS = "[dbo].[spGetCarrierSettings]";

        /// <summary>
        ///     Procedure which is ued to retrive the carrier settings
        /// </summary>
        public const string SP_GET_CARRIER_CODE = "[dbo].[spGetCarrierCode]";

        /// <summary>
        ///     Procedure which is useed to retrive the vender bill by proNumber
        /// </summary>
        public const string SP_GET_VENDERBILL_PRONUMBER = "[dbo].[spGetVenderBillByProNumber]";

        /// <summary>
        ///     Procedure which is useed to retrive the invoice details for the order.
        /// </summary>
        public const string SP_GET_INVOICE_DETAILS_BY_INVOICE_NO = "[dbo].[spGetInvoiceDetailsByOrder]";


        /// <summary>
        ///     This is used to update the EDI 210 record
        /// </summary>
        public const string SP_UPDATE_EDI210RECORD = "[dbo].[spUpdateEDI210Record]";

        /// <summary>
        ///     This is used to update the matching process service
        /// </summary>
        public const string SP_EDI210_MATCHING_SERVICE_OPERATIONS = "[dbo].[spEDI210MatchingServiceOperations]";

        /// <summary>
        ///     This is used to update the EDI 214 record
        /// </summary>
        public const string SP_EDI214_DB_OPERATIONS = "[dbo].[spEDI214DbOperations]";

        #endregion

        #region Stored ProcedureNames for CSV Purchase Orders
        /// <summary>
        ///     Store procedure to Get CSV walmart Purchase Orders information
        /// </summary>
        public const string SP_GET_CSV_WALMART_PO = "dbo.spGetWalmartCSVPurchaseOrders";

        /// <summary>
        ///  Show Geographicalwise Information of Items shipped. 
        /// </summary>
        public const string SP_WALMART_VENDOR_GET_GEOGRAPHICAL_SHIPPED_STATE_ALL = "dbo.spgetWalmartVendorGeographicalSkuDetails";

        /// <summary>
        ///  Show Geographicalwise Information of Items shipped for a customer
        /// </summary>
        public const string SP_WALMART_GET_GEOGRAPHICAL_SHIPPED_STATE_ALL = "dbo.spgetWalmartGeographicalSkuDetails";

        #endregion

        # region Stored Procedure Names for Record Locking
        /// <summary>
        ///     Stored procedure to Get Lock for a record for specific user
        /// </summary>
        public const string SP_SET_LOCK_FOR_RECORD = "dbo.spLockRecord";

        /// <summary>
        ///     Stored procedure to Release Lock for a record for specific user
        /// </summary>
        public const string SP_RELEASE_LOCK_FOR_RECORD = "dbo.spReleaseLock";

        /// <summary>
        ///     Stored procedure to Check Lock Status for a record for specific user
        /// </summary>
        public const string SP_CHECK_LOCK_STATUS_FOR_RECORD = "dbo.spCheckLockStatus";

        /// <summary>
        ///     Stored procedure to Release Lock for a record for specific user
        /// </summary>
        public const string SP_RELEASE_LOCKS_FOR_USER = "dbo.spReleaseLocksForUser";

        # endregion

        #region Claim Management
        /// <summary>
        /// stored procedure for getting claim report details
        /// </summary>
        public const string SP_GETCLAIMREPORT = "dbo.spGetClaimReport";

        /// <summary>
        /// stored procedure for inserting claim management
        /// </summary>
        public const string SP_INSERTCLAIMMANAGEMENT = "dbo.spInsertClaimReport";

        /// <summary>
        /// stored procedure for updating claim management
        /// </summary>
        public const string SP_UPDATECLAIMMANAGEMENT = "dbo.spUpdateClaimReport";

        #endregion Claim Management

        #region Stored Procedure Names for PLC

        /// <summary>
        /// Store procedure to create new PLC account
        /// </summary>
        public const string SP_CREATE_PLC = "dbo.spCreatePLC";

        /// <summary>
        ///     Store procedure to get PLC information by id.
        /// </summary>
        public const string SS_GET_PLC_INFORMATION_BY_ID = "dbo.spGetPLCInformationById";

        /// <summary>
        ///     Store procedure to update Plc account.
        /// </summary>
        public const string SP_UPDATE_PLC = "spUpdatePLC";

        /// <summary>
        ///     Store procedure to get Plc carrier List.
        /// </summary>
        public const string SP_PLC_CARRIER_LIST = "spGetAllUnBlockCarrierList";

        /// <summary>
        ///     Store procedure to get Plc vendor bill.
        /// </summary>
        public const string SP_GET_PLC_VENDOR_BILL = "spGetPLCVendorBill";

        /// <summary>
        ///     Store procedure to get PLCVendorBillDetailsByDate.
        /// </summary>
        public const string SP_GET_PLC_VENDOR_BILL_DETAILS_BY_DATE = "spGetPLCVendorBillDetailsByDate";

        /// <summary>
        ///     Store procedure to get PLCVendorBillDetailsByDate.
        /// </summary>
        public const string SP_GET_ALL_INVOICES_BY_SALESADMIN_ID = "spGetAllInvoicesBySalesAdminId";

        #endregion
    }

    /// <summary>
    ///     This class contains all user defined table data types created in database.
    /// </summary>
    public class StoredProcedureTableTypesParameters
    {
        /// <summary>
        ///     User defined table type name for change history information parameter
        /// </summary>
        public const string UTT_CHANGE_HISTORY = "dbo.uttChangeHistory";

        /// <summary>
        ///     User defined table type name for Cusomers for Customer Management.
        /// </summary>
        public const string UTT_CM_CUSTOMER = "dbo.uttCustomers";

        /// <summary>
        ///     User defined table type name for Vendors for Customer Management.
        /// </summary>
        public const string UTT_CM_VENDOR = "dbo.uttCMVendor";

        /// <summary>
        ///     User defined table type name for WalMart for Customer Management.
        /// </summary>
        public const string UTT_CM_WALMART = "dbo.uttWalmart";

        /// <summary>
        ///     User defined table type name for CSVFile.
        /// </summary>
        public const string UTT_CSVFILE = "dbo.uttCSVFile";

        /// <summary>
        ///     User defined table type name for CSV Purchase Orders.
        /// </summary>
        public const string UTT_CSV_WALMART_PURCHASE_ORDER = "dbo.uttCSVWalMartPurchaseOrder";

        /// <summary>
        ///     User defined table type name for CSV Purchase Orders Details.
        /// </summary>
        public const string UTT_CSV_WALMART_PURCHASE_ORDER_DETAILS = "dbo.uttCSVWalMartPurchaseOrderDetails";

        /// <summary>
        ///     User defined table type name for load request information parameter
        /// </summary>
        public const string UTT_LOAD_REQUEST = "dbo.uttLoadRequest";

        /// <summary>
        ///     User defined table type name for load request notes information parameter
        /// </summary>
        public const string UTT_NOTES = "dbo.uttNotes";

        /// <summary>
        ///     User defined table type name for load request stops information parameter
        /// </summary>
        public const string UTT_STOPS = "dbo.uttStops";

        /// <summary>
        ///     User defined table type name for load request QUOTE information parameter
        /// </summary>
        public const string UTT_LOAD_REQUEST_QUOTE = "dbo.uttLoadRequestQuote";

        /// <summary>
        ///     User defined table type name for carrier charges information parameter
        /// </summary>
        public const string UTT_LOADREQUEST_CHARGES = "dbo.uttLoadRequestCharges";

        /// <summary>
        ///     User defined table type name for load booked information parameter
        /// </summary>
        public const string UTT_LOADREQUEST_BOOK = "dbo.uttLoadRequestBook";

        /// <summary>
        ///     User defined table type name for pieces information parameter
        /// </summary>
        public const string UTT_LOADREQUEST_PIECES = "dbo.uttPieces";

        /// <summary>
        ///     User defined table type name for Carrier Rating information parameter
        /// </summary>
        public const string UTT_LOADREQUEST_CARRIER_RATING = "dbo.uttCarrierRating";

        /// <summary>
        ///     User defined table type name for Accepted Po
        /// </summary>
        public const string UTT_ACCEPTED_PO = "dbo.uttAcceptedPO";

        /// <summary>
        ///     User defined table type name for Vendor Purchase Order Details.
        /// </summary>
        public const string UTT_VENDOR_PURCHASE_ORDER_DETAILS = "dbo.uttVendorPurchaseOrderDetails";


        #region StoredProcedureTableTypesParameters for BackOffice

        /// <summary>
        ///     User defined table type name for uttcarriers.
        /// </summary>
        public const string UTT_CARRIERS = "Carriers";

        /// <summary>
        ///     User defined table type name for uttcarriers.
        /// </summary>
        public const string UTT_CARRIER_TABLE = "dbo.uttCarriers";

        /// <summary>
        ///     User defined table type name for uttcarriers.
        /// </summary>
        public const string UTT_CARRIER_ZIPRANGE_PRICING = "CarrierZipRangePricing";

        /// <summary>
        ///     User defined table for uttcarriers.
        /// </summary>
        public const string UTT_CARRIER_ZIPRANGE_PRICING_TABLE = "dbo.uttCarrierZipRangePricing";


        #endregion  StoredProcedureTableTypesParameters for BackOffice

        #region StoredProcedureTableTypesParameters for Warehouse

        /// <summary>
        ///     User defined table type name for Walmart PO Tracking information parameter
        /// </summary>
        public const string UTT_WALMART_PO_TRACKING = "dbo.uttWalMartPurchaseOrderTracking";

        /// <summary>
        ///     User defined table type name for Walmart CSV PO Tracking information parameter
        /// </summary>
        public const string UTT_WALMART_CSV_PO_TRACKING = "dbo.uttWalMartCSVPO";

        /// <summary>
        ///     User defined table type name for Vendor PO information parameter
        /// </summary>
        public const string UTT_VENDOR_POS = "dbo.uttVendorPurchaseOrders";

        /// <summary>
        ///     User defined table type name for Vendor PO details information parameter
        /// </summary>
        public const string UTT_VENDOR_PO_DETAILS = "dbo.uttVendorPurchaseOrderDetails";

        /// <summary>
        ///     User defined table type name for Inventory information parameter
        /// </summary>
        public const string UTT_INVENTORY = "dbo.uttInventory";

        /// <summary>
        ///     User defined table type name for Warehouses information parameter
        /// </summary>
        public const string UTT_WAREHOOUSE = "dbo.uttWarehouse";

        #endregion

        #region StoredProcedureTableTypesParameters for fms

        /// <summary>
        ///     User defined table type name for customers
        /// </summary>
        public const string UTT_CUSTOMERS = "dbo.uttCustomers";

        /// <summary>
        ///     User defined table type name for customers address
        /// </summary>
        public const string UTT_CUSTOMER_ADDRESS = "dbo.uttUpdateCustomerAddress";

        /// <summary>
        ///     User defined table type name for customers comapnies
        /// </summary>
        public const string UTT_CUSTOMER_COMPANIES = "dbo.uttCompanies";

        /// <summary>
        ///     User defined table type name for customers settings
        /// </summary>
        public const string UTT_CUSTOMER_SETTINGS = "dbo.uttCustomerSettings";

        /// <summary>
        ///     User defined table type name for customers group relations
        /// </summary>
        public const string UTT_CUSTOMER_GROUP_RELATIONS = "dbo.uttCustomerGroupRelations";

        #endregion

        #region StoredProcedureTableTypesParameters for PLC

        /// <summary>
        ///     User defined table type name for PLC information.
        /// </summary>
        public const string UTT_PLC = "dbo.uttPLCInformation";

        /// <summary>
        ///     User defined table type name for PLC address information.
        /// </summary>
        public const string UTT_PLC_ADDRESSES = "dbo.uttPLCAddresses";

        /// <summary>
        ///     User defined table type name for PLC financials information.
        /// </summary>
        public const string UTT_PLC_FINANCIALS = "dbo.uttPLCFinancials";

        /// <summary>
        ///     User defined table type name for PLC financials information.
        /// </summary>
        public const string UTT_PLC_THIRD_PARTY_IDS = "dbo.uttPLCThirdPartyIds";

        /// <summary>
        ///     User defined table type name for PLC Carrier information.
        /// </summary>
        public const string UTT_PLC_CARRIER = "dbo.uttPLCCarrier";

        #endregion
    }

    /// <summary>
    ///     Class for keeping stored procedure parameter names
    /// </summary>
    /// 
    public class StoredProcedureParamters
    {
        /// <summary>
        ///     parameter for primary key
        /// </summary>
        public const string PARAM_ID = "id";

        /// <summary>
        ///     parameter for priorityId
        /// </summary>
        public const string PARAM_PRIORITY = "priorityId";

        /// <summary>
        ///     parameter for priorityId
        /// </summary>
        public const string PARAM_COPYCHARGESREQUIRED = "copyChargesrequired";

        /// <summary>
        ///     paramters for Load request quote no
        /// </summary>
        public const string PARAM_QUOTE_NO = "quoteNo";

        /// <summary>
        ///     paramters for Load booked Bol nos
        /// </summary>
        public const string PARAM_BOL = "bolNo";

        /// <summary>
        ///     paramters for Load Request Id
        /// </summary>
        public const string PARAM_LOAD_REQUEST_ID = "loadRequestId";

        /// <summary>
        ///     parameter for initial search 
        /// </summary>
        public const string PARAM_INITIALS = "startingLetters";

        /// <summary>
        ///     Required parameter constant.
        /// </summary>
        public const string PARAM_ADD_ZIP_ID = "Id";

        /// <summary>
        ///     Required parameter constant.
        /// </summary>
        public const string PARAM_TYPE_TO_RETRIEVE_DATA = "DataToRetrieve";

        /// <summary>
        ///     Parameter conatins new password
        /// </summary>
        public const string PARAM_CUSTOMER_NEWPASSWORD = "NewPassword";

        /// <summary>
        /// Parameter contains pickUpDate.
        /// </summary>
        public const string PARAM_PICK_UP_DATE = "pickUpDate";

        /// <summary>
        /// Parameter contains pickUpReadyTime.
        /// </summary>
        public const string PARAM_PICK_UP_READY_TIME = "pickUpReadyTime";

        /// <summary>
        /// Parameter contains deliveryReadyTime.
        /// </summary>
        public const string PARAM_DELIVERY_READY_TIME = "deliveryReadyTime";

        #region StoredProcedureParamters for BackOffice

        /// <summary>
        ///     parameter for role id
        /// </summary>
        public const string PARAM_ROLE_ID = "RoleId";

        /// <summary>
        ///     parameter for Securable ID
        /// </summary>
        public const string PARAM_SECURABLE_ID = "SecurableId";

        /// <summary>
        ///     parameter for Securable ID
        /// </summary>
        public const string PARAM_FLAG = "Flag";

        /// <summary>
        /// This ID is to specify which BlockCarriersForServiceFAK ID needs to be deleted.
        /// </summary>
        public const string PARAM_DELETE_BLOCKID = "DeleteRowId";

        /// <summary>
        ///     parameter for customer id
        /// </summary>
        public const string PARAM_CUSTOMER_ID = "CustomerId";

        /// <summary>
        ///     parameter for passing whether the selected customer is master or not
        /// </summary>
        public const string PARAM_IS_MASTER = "IsMaster";

        /// <summary>
        ///     parameter for address number(Residentail)
        /// </summary>
        public const string PARAM_ADDRESS_NUMBER = "AddressNumber";

        /// <summary>
        ///     parameter for billing address number
        /// </summary>
        public const string PARAM_BILLING_ADDRESS_NUMBER = "BillingAddressNumber";

        /// <summary>
        ///     parameter for uniquely identifying product Id for a customer
        /// </summary>
        public const string PARAM_UNIQUE_PRODUCT_ID = "UniqueProductId";

        /// <summary>
        ///     parameter for pricing id
        /// </summary>
        public const string PARAM_PRICING_ID = "PricingId";


        /// <summary>
        ///     parameter for pricing id
        /// </summary>
        public const string PARAM_ZIP_RANGE_PRICING_ID = "id";

        /// <summary>
        ///     parameter for employee id
        /// </summary>
        public const string PARAM_EMPLOYEE_ID = "EmployeeId";

        /// <summary>
        ///     parameter for customer id
        /// </summary>
        public const string PARAM_NEW_CUSTOMER_ID = "NewCustomerId";

        /// <summary>
        ///     parameter for address type id 
        /// </summary>
        public const string PARAM_ROW_UNIQUE_ID = "RowUniqueId";

        /// <summary>
        ///     parameter for CustomerUpdated
        /// </summary>
        public const string PARAM_CUSTOMER_UPDATE = "CustomerUpdated";

        /// <summary>
        ///     parameter for NetSuiteinternalID
        /// </summary>
        public const string PARAM_NETSUITE_ID = "NetSuiteId";

        /// <summary>
        ///     parameter for PARAM_QUOTE_ID 
        /// </summary>
        public const string PARAM_QUOTE_ID = "QuoteId";

        /// <summary>
        ///     parameter for PARAM_User_ID 
        /// </summary>
        public const string PARAM_User_ID = "UserId";
        /// <summary>
        ///     parameter for PARAM_PageNo 
        /// </summary>
        public const string PARAM_PageNo = "PageNo";
        /// <summary>
        ///     parameter for PARAM_PageNo 
        /// </summary>
        public const string PARAM_Status = "status";

        #endregion StoredProcedureParamters for BackOffice

        #region StoredProcedureParamters for FMS

        /// <summary>
        ///     parameter for CustomerId 
        /// </summary>
        public const string CUSTOMER_ID = "CustomerId";


        /// <summary>
        ///     parameter for DefaultTrackingSelectionItem 
        /// </summary>
        public const string DEFAULT_TRACKING_SELECTION_ITEM = "DefaultTrackingSelectionItem";

        /// <summary>
        ///     parameter for NotesType
        /// </summary>
        public const string NOTES_TYPE = "NotesType";

        /// <summary>
        ///     parameter for EntityId 
        /// </summary>
        public const string ENTITY_ID = "EntityId";

        /// <summary>
        ///     parameter for EntityType 
        /// </summary>
        public const string ENTITY_TYPE = "EntityType";

        ///// <summary>
        /////     parameter for ShipmentNote 
        ///// </summary>
        //public const string SHIPMENT_NOTE = "ShipmentNote";

        /// <summary>
        ///     parameter for Notes 
        /// </summary>
        public const string NOTES = "Notes";

        /// <summary>
        ///     parameter for UpdatedBy 
        /// </summary>
        public const string UPDATED_BY = "UpdatedBy";

        /// <summary>
        ///     parameter for CreatedBy 
        /// </summary>
        public const string CREATED_BY = "CreatedBy";

        /// <summary>
        ///     parameter for CompanyID 
        /// </summary>
        public const string COMPANY_ID = "CompanyID";
        /// <summary>
        ///     parameter for COMPANYNAME 
        /// </summary>
        public const string COMPANYNAME = "COMPANYNAME";
        /// <summary>
        ///     parameter for FROMDATE 
        /// </summary>
        public const string FROMDATE = "FDATE";
        /// <summary>
        ///     parameter for TODATE 
        /// </summary>
        public const string TODATE = "TDATE";
        /// <summary>
        ///     parameter for TODATE 
        /// </summary>
        public const string FORMNAME = "FORMNAME";
        /// <summary>
        ///     parameter for customertype 
        /// </summary>
        public const string CUSTOMERTYPE = "CUSTOMERTYPE";

        /// <summary>
        ///     parameter for customertype 
        /// </summary>
        public const string ISBOOKDATE = "@ISBOOKDATE";
        /// <summary>
        ///     parameter for groupname 
        /// </summary>
        public const string GROUPNAME = "@GROUPNAME";

        /// <summary>
        /// parameter for groupname 
        /// </summary>
        public const string GROUPID = "@GRPID";
        /// <summary>
        ///     parameter for groupname 
        /// </summary>
        public const string CONTACTNAME = "@CONTACTNAME";
        /// <summary>
        ///     parameter for groupname 
        /// </summary>
        public const string GTYPE = "@GTYPE";
        /// <summary>
        ///     parameter for groupname 
        /// </summary>
        public const string SHIMENTID = "@SHIPID";

        public const string MODULENAME = "@Mname";


        /// <summary>
        ///     parameter for LoginName 
        /// </summary>
        public const string LOGIN_NAME = "LoginName";

        /// <summary>
        ///     parameter for LoginPassword 
        /// </summary>
        public const string LOGIN_PASSWORD = "LoginPassword";

        /// <summary>
        ///     Parameter for UpdatedDate
        /// </summary>
        public const string UPDATED_TIME = "UpdatedDate";

        /// <summary>
        ///     Used to represent the group id
        /// </summary>
        public const string GROUP_ID = "GroupId";


        /// <summary>
        ///     Used to represent the reference no
        /// </summary>
        public const string REFERENCE_NO = "ReferenceNo";

        /// <summary>
        ///     Represents the saved quote id from "SavedQuote" table
        /// </summary>
        public const string SAVEDQUOTE_ID = "SavedQuoteId";

        /// <summary>
        ///     Represents TimeFrame For savedQuote
        /// </summary>
        public const string TIMEFRAME = "TimeFrame";

        /// <summary>
        ///     Represents the insurance fee id from Accessorial table
        /// </summary>
        public const string INSURANCEFEE_ID = "InsuranceFeeId";

        /// <summary>
        ///     Represents the Shipment Types, i.e; LTL / Guaranteed LTL / Pallet
        /// </summary>
        public const string SHIPMENT_TYPE = "CarrierServiceType";

        /// <summary>
        /// "CarrierID" parameter from "Carrier" Table
        /// </summary>
        public const string CARRIER_ID = "CarrierID";

        /// <summary>
        /// Represents the origin zip code of the customer addresss
        /// </summary>
        public const string ORIGIN_ZIP = "OriginZip";

        /// <summary>
        /// Represents the origin zip code of the customer addresss
        /// </summary>
        public const string ZIPCODE = "ZipCode";

        /// <summary>
        /// Represents the destination zip code of the customer address
        /// </summary>
        public const string DESTINATION_ZIP = "DestinationZip";

        /// <summary>
        /// parameter for shipmentHistory Page
        /// </summary>
        public const string MONTH = "Month";
        /// <summary>
        /// parameter for shipmentHistory Page
        /// </summary>
        public const string YEAR = "Year";
        /// <summary>
        /// parameter for shipmentHistory Page
        /// </summary>
        public const string DATE_TYPE = "DateType";

        /// <summary>
        /// parameter for Shipper Home Page
        /// </summary>
        public const string ORDERCOUNT = "OrderCount";

        /// <summary>
        /// parameter name
        /// </summary>
        public const string SAVEDQUOTETYPE = "QuoteType";

        ///// <summary>
        ///// parameter for Pallet Quote Calculation 
        ///// </summary>
        public const string SOURCEZIP = "sourceZip";
        /// <summary>
        /// parameter for Pallet Quote Calculation 
        /// </summary>
        public const string DESTZIP = "destZip";
        /// <summary>
        /// parameter for Pallet Quote Calculation 
        /// </summary>
        public const string QOUTEBY = "quoteByType";
        /// <summary>
        /// parameter for Pallet Quote Calculation 
        /// </summary>
        public const string QOUTEBYID = "quotebyid";

        /// <summary>
        /// parameter for Pallet Quote Calculation 
        /// </summary>
        public const string QOUTEITEM = "quoteitem";
        /// <summary>
        /// Represents the ID parameter of the CustomerAddress table
        /// </summary>
        public const string ADDRESS_ID = "AddressID";

        /// <summary>
        /// Represents the ID parameter of the MiniStatement 
        /// </summary>
        public const string MINISTATEMENT_ID = "MiniStatementId";

        /// <summary>
        ///     parameter for BOL number of the last booked order of customer
        /// </summary>
        public const string PARAM_BOL_NUMBER = "BolNo";

        /// <summary>
        /// Represents edi enabled parameter
        /// </summary>
        public const string EDI_ENABLED = "EdiEnabled";

        /// <summary>
        ///     parameter order status
        /// </summary>
        public const string PARAM_ORDER_STATUS = "OrderStatus";

        /// <summary>
        ///     parameter for BOL number of the last booked order of customer
        /// </summary>
        public const string PARAM_INSURANCE_STATUS = "InsuranceUpdateStatus";

        /// <summary>
        ///     parameter for shipmentId
        /// </summary>
        public const string PARAM_SHIPMENTID = "shipmentId";


        /// <summary>
        ///     parameter for Insured Amount
        /// </summary>
        public const string PARAM_INSUREDAMOUNT = "InsuredAmount";

        /// <summary>
        ///     parameter for Insurance charge
        /// </summary>
        public const string PARAM_INSURANCECHARGE = "InsuranceAmount";

        /// <summary>
        ///     parameter for Insurance charge
        /// </summary>
        public const string PARAM_INSURANCECOST = "InsuranceCost";

        /// <summary>
        ///     parameter for operationtype add or remove
        /// </summary>
        public const string PARAM_OPERATION_TYPE = "OperationType";

        /// <summary>
        ///     parameter for number
        /// </summary>
        public const string NUMBER = "Number";

        public const string IS_AUTHORIZED = "IsAuthorized";
        #endregion

        #region EDI        

        /// <summary>
        ///     Parameter conatins SalesOrderId
        /// </summary>
        public const string PARAM_SALES_ORDER_ID = "SalesOrderId";

        /// <summary>
        ///     Parameter conatins FileCount
        /// </summary>
        public const string PARAM_FILE_COUNT = "FileCount";

        /// <summary>
        ///     Parameter conatins EDIType
        /// </summary>
        public const string PARAM_EDI_TYPE = "EDIType";

        /// <summary>
        ///     Parameter conatins EDIControlNumber
        /// </summary>
        public const string PARAM_EDI_CONTROL_NUMBER = "EDIControlNumber";

        /// <summary>
        ///     Parameter conatins CarrierId
        /// </summary>
        public const string PARAM_CARRIER_ID = "CarrierId";

        /// <summary>
        ///     Parameter conatins Carrier Code
        /// </summary>
        public const string PARAM_CARRIER_CODE = "CarrierCode";

        /// <summary>
        ///     Parameter conatins Record Count
        /// </summary>
        public const string PARAM_RECORD_COUNT = "RecordCount";

        /// <summary>
        ///     Parameter conatins Thread Count
        /// </summary>
        public const string PARAM_THREAD_COUNT = "ThreadCount";

        /// <summary>
        ///     Parameter contains proNumber
        /// </summary>
        public const string PARAM_PRO_NUMBER = "ProNumber";

        /// <summary>
        ///     This is used to map the delivery date
        /// </summary>
        public const string PARAM_DELIVERY_DATE = "DeliveryDate";

        /// <summary>
        ///     This is used to map the invoice status
        /// </summary>
        public const string PARAM_INVOICE_STATUS = "InvoiceStatus";

        /// <summary>
        ///     This is used to map the edi210details id
        /// </summary>
        public const string PARAM_EDI210_DETAIL_ID = "EDIDetailsId";

        /// <summary>
        ///     This is used to map the VENDERBILL id
        /// </summary>
        public const string PARAM_VENDER_BILL_ID = "VendorID";

        /// <summary>
        ///     This is used to map the Adjustment
        /// </summary>
        public const string PARAM_PROFIT_ADJUSTMENT = "NeedAdjustment";

        /// <summary>
        ///     Parameter contains ProNo
        /// </summary>
        public const string PARAM_PRO_NO = "ProNo";

        /// <summary>
        ///     Parameter contains ProNo
        /// </summary>
        public const string PARAM_PO_NO = "PoNo";

        /// <summary>
        ///     Parameter contains bolNumber
        /// </summary>
        public const string PARAM_BOLNUMBER = "BolNumber";

        /// <summary>
        ///     Parameter contains InvoiceNumber
        /// </summary>
        public const string PARAM_INVOICENUMBER = "InvoiceNumber";

        /// <summary>
        ///     Parameter contains ShipmentId
        /// </summary>
        public const string PARAM_SHIPMENT_ID = "ShipmentId";

        /// <summary>
        ///     This is used to map the Process status
        /// </summary>
        public const string PARAM_PROCESS_STATUS = "ProcessStatus";

        /// <summary>
        ///     This is used to map the Edi FileName
        /// </summary>
        public const string PARAM_EDI_FILENAME = "EDIFileName";

        /// <summary>
        ///     This is used to map the Edi File Path
        /// </summary>
        public const string PARAM_EDI_FILEPATH = "EDIFilePath";

        /// <summary>
        ///     This is used to map the isa control number
        /// </summary>
        public const string PARAM_ISA_CONTROL_NUMBER = "IsaControlNumber";

        /// <summary>
        ///     This is used to map the RecieverId
        /// </summary>
        public const string PARAM_RECIEVER_ID = "RecieverId";

        /// <summary>
        ///     This is used to map the SenderId
        /// </summary>
        public const string PARAM_SENDER_ID = "SenderId";

        /// <summary>
        ///     This is used to map the tracking details xml
        /// </summary>
        public const string PARAM_TRACKING_DETAILS_XML = "TrackingDetails";

        /// <summary>
        ///     This is used to map the track Id
        /// </summary>
        public const string PARAM_CONTROL_NUMBER = "ControlNumber";

        /// <summary>
        ///     This is used to map the pickup date
        /// </summary>
        public const string PARAM_PICKUP_DATE = "PickupDate";

        /// <summary>
        ///     This is used to map the NOTES   
        /// </summary>
        public const string PARAM_NOTES = "Notes";

        /// <summary>
        ///     This is used to map the PickupExists   
        /// </summary>
        public const string PARAM_PICKUP_EXISTS = "PickupExists";

        #endregion

        #region stored parameter for plc

        /// <summary>
        ///     Parameter contains plc id
        /// </summary>
        public const string PARAM_PLC_ID = "PLCId";

        #endregion

    }

    /// <summary>
    ///     This class contains constants declaration for Table and primary keys   
    /// </summary>
    public class TableAndPrimaryKeyNames
    {
        #region [Table name and their Primary Key]

        #endregion
    }

    /// <summary>
    ///     This class contains declaration of table column names
    /// </summary>
    public class TableColumnsConstants
    {
        #region [Table column names]

        #endregion
    }

    /// <summary>
    ///     This class contains declaration of db Error codes
    /// </summary>
    public class DatabaseErrorConstants
    {
        /// <summary>
        ///     Timestamp mismatch error
        /// </summary>
        public const int TIMESTAMP_MISMATCH_ERROR = 50001;

        /// <summary>
        ///     Timestamp mismatch error
        /// </summary>
        public const int HAZMAT_PACKET_NOT_RECEIVED_ERROR = 50013;

        /// <summary>
        ///     Timestamp mismatch error
        /// </summary>
        public const int CARRIER_CODE_ALREADY_EXIST_ERROR = 50014;

        /// <summary>
        ///     DataMismatch error
        /// </summary>
        public const int DATA_MISMATCH_ERROR = 50015;

        /// <summary>
        ///     Carrier insurance expired error.
        /// </summary>
        public const int CARRIER_INSURANCE_EXPIRED_ERROR = 50016;

        /// <summary>
        ///     Carrier is not setup in netsuite error.
        /// </summary>
        public const int CARRIER_NOT_SETUP_NETSUITE_ERROR = 50019;

        /// <summary>
        ///     Carrier is not setup in netsuite error.
        /// </summary>
        public const int CARRIER_INACTIVE_ERROR = 50020;

        /// <summary>
        /// Database Record already changed
        /// </summary>
        public const string RECORD_ALREADY_CHANGED = "Record already changed";

        /// <summary>
        ///     Customer already exists
        /// </summary>
        public const int CUSTOMER_ALREADY_EXISTS = 5000;
    }
}

