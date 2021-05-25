using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GiftPoint.Common
{
    public static class Constants
    {
        public const string CONNECTION_STRING_KEY = "ConnectionString";
        public const string SITE_URL = "SiteUrl";
        public const string SITE_NAME = "SiteName";
        public const string MIS_CODE_DUPLICATE = " MIS Code is already assigned to distributor = ";

        public const string UPLOADED_FILES = "UploadedFiles";
        public const string UPLOADED_SalesOperationsDOCUMENTS_PATH = "UploadedFiles/SalesOperationsDocuments/";
        public const string OPERATIONALMESSAGE = "OperationalMessage";
        public const string PAGE_TITLE = "pageTitle";

        public const string NO_RECORD_FOUND = "No Record Found";
        public const string INVALID_TOKEN = "Invalid Token";
        public const string NOT_ACCEPTABLE = "Request Not Acceptable";
        public const string INVALID_REQUEST = "Invalid Request";
        public const string REQUEST_DONE = "Request Done Successfully";
        public const string ENTER_REQUIRED_FIELD = "Please enter required fields !";
        public const string DUPLICATE_VALUES = "Duplicate Values are not allowed !";
        public const string INVALID_DATETIME = "The date entered in the forms is not correct.";
        public const string OPERATION_DONE = "Operation Done Successfully";
        public const string OPERATION_FAILED = "Operation Failed";
        public const string ATTACHEMENT_CHECK = "Atleast Add One Document";
        public const string UNIQUE_KEY_EXCEPTION = "UNIQUE KEY";
        public const string NO_DETAIL_RECORD_EXISTS = "There's no detail record. Please enter atleast one detail record.";
        public const string TRUE = "true";
        public const string ERROR_OCCURED = "Error Occured!";
        public const string VALIDATION_FAILED = "Validation failed!";

        public const string SMTP_SERVER_KEY = "";
        public const string SMTP_PORT_KEY = "25";
        public const string SMTP_SSL_KEY = "false";
        public const string SMTP_AUTH_KEY = "true";
        public const string SMTP_USER_NAME_KEY = "";
        public const string SMTP_USER_EMAIL_KEY = "";
        public const string SMTP_USER_PASS_KEY = "";

        public const string DATE_FORMAT_SERVER_SIDE = "dd-MMM-yyyy";
        public const string DATE_FORMAT_CLIENT_SIDE = "dd-M-yy";
        public const string DATE_FORMAT_MASK_CLIENT_SIDE = "99-aaa-9999";

        public const int YEAR_RANGE_START = 1980;
        public const int YEAR_RANGE_END = 2050;
        public const string REPORT_PATHTOTReports = "../../SOReports/TOTReports/";
        public const string REPORT_PATH = "../../SOReports/";
        public const string REPORT_PATHMerchandisigReports = "../../SOReports/MerchandisingSaleOfficerReports/";
        public const string LOADING_GIF =
            @"<div style='text-align:center'><h2><i class='fa fa-spinner fa-spin fa-2x'></i>&nbsp;&nbsp;Loading... Please wait...!</h2></div>";
        public const int TradeExecutive = 47;
        public const string PRODUCT_IMAGES_DIRECTORY_PATH = "ProductImages/";
    }
}
