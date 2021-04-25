using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftPoint.Common
{
    public enum OperationMessageType : int
    {
        Error = 1,
        Notics = 2,
        Information = 3,
        Success = 4,
        ProcessFailed=5,
        AddedNew=6,
        Updated=7,
        Deleted=8,
        AlreadyGateOut = 20,
        Duplicate=21
    }

    public enum AuditLogType : int
    {
        Login = 1,
        Added = 2,
        Edited = 3,
        Deleted = 4,
        Downloaded = 5
    }

    public enum UserRolesEnum : int
    {
        Admin = 1,
        Owner = 2,
        KPO = 24
    }


    public enum EntityType : int
    {
        SalesOperationsDocument = 1
    }

    public enum RequestTypes : int
    {
        Unapproved = 0,
        Approved = 1,
        Rejected = 2
    }
    /// <summary>
    /// DB Operation Types enumeration regarding Update/Delete in order to maintain history.
    /// </summary>
    public enum OperationType 
    {
        Update = 1,
        Delete = 2,
        Insert = 3
    }

    public enum OutletStatuses : int
    {
        Initiated =1,
        ApprovedBySOManager=2,
        InprocessofPhysicalVerification=3,
        InprocessofDatabaseVerification=4,
        Approved=5,
        RejectedBySO=6,
        RejectedBySIS=7
    }

    public enum Notifications :int
    {
        ProductRates=1
    }

    public enum Designations : int
    {
        GMSales = 38,
        DSM = 22,
        RSM = 21,
        AASM = 14,
        ASM = 15,
        SO = 12,
        SalesSupervisor = 13,
        TradeExecutive = 47,
        Merchandiser = 27,
        MerchandiserOfficer = 33,
        SND = 39,
        KAE = 49

    }

    public enum Reports : int
    {
        ScoreCardReport = 1
    }
}
