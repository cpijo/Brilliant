
namespace TTAF.Entities.Common
{
    public static class Constants
    {
        public const string Error_LogIn = "Invalid Username or Password!";
        public const string Error_AccoutLockOut = "Account Locked Out";
        public const string ERROR_Empty_Fields = "Please Fill up all the Fields";

        public const string ERROR_Empty_Field_Name = "Please Enter {0}";

        public const string SUCCESS_Msg_Submitted = "Message ID {0} Is Successfully Submitted";
        public const string SUCCESS_Msg_ID_Submitted = "Message ID {0} Is Successfully Submitted";
        public const string SUCCESS_Submitted = "Your Request Is Successfully Submitted";
        public const string SUCCESS_Saved = "Your file Is Successfully Saved";
        public const string SUCCESS_Updated = "Your Request has been successfully updated";
        public const string SUCCESS_Account_Updated = "Your Account has been successfully updated";
        public const string SUCCESS_Account_Created = "Your Account has been successfully Created";
        public const string SUCCESS_downloaded = "Your file Is Successfully downloaded";
        public const string SUCCESS_Request = "Your request has been sent successfully";

        public const string WARNING_LogIn = "Invalid Username or Password!";
        public const string WARNING_Submitted = "Only file is less than {0} Is Allowed";
        public const string WARNING_File_Type = "Only file is less than {0} Is Allowed";
        public const string WARNING_File_Size = "Only file is less than {0} Is Allowed";
        public const string WARNING_File_Empty = "Please choose a candidate";

        public const string WARNING_NewMessages_To_Open = "You can only open {0} New Messages";


        public const string INFOR_Busy = "...busy, Please wait...!";
        public const string INFOR_Busy_Api = "... busy getting Data from API ...";
        public const string INFOR_Empty_Fields = "Please Fill up all the Fields";


        public static bool NotNullValue(string variable)
        {
            if (variable == null || variable == "")
            {
                return false;
            }
            return true;
        }

        public static string waitingTime(int waitingMinute)
        {
            int totalSeconds = waitingMinute;
            int seconds = totalSeconds % 60;
            int minutes = totalSeconds / 60;

            string waitingTime = minutes + " Minutes : " + seconds + " Seconds";
            waitingTime = string.Format("Try Again in {0}", waitingTime);
            return waitingTime;
        }


        public enum MonthsOfYear
        {
            January = 1,
            February = 2,
            March = 3,
            April = 4,
            May = 5,
            June = 6,
            July = 7,
            August = 8,
            September = 9,
            October = 10,
            November = 11,
            December = 12,

        }
        public enum IproStatus
        {
            Active = 1,
            Disabled = 2,
        }
        public enum IproCalls
        {
            RequestResponse = 1,
            ResponseOnly = 2,
        }
        public enum IproCallsDirection
        {
            Request = 1,
            Response = 2,
        }

        public enum IproMetaData
        {
            strings = 1,
            date = 2,
            datetime = 3,
            ints = 3,
            decimale = 3,
        }
        //private static SelectList _ListDistributorOptions { get; set; }
        //public static SelectList DistributorList(List<BProcSecurityStructs.DistributorSimple> listDistributorSimple)
        //{
        //    List<SelectListItem> list = listDistributorSimple
        //       .Select(item => new SelectListItem
        //       {
        //           Value = item.distributorID.ToString(),
        //           Text = item.distributorName,
        //           Selected = "-1" == item.distributorID.ToString() ? true : false
        //       })
        //  .ToList();

        //   return _ListDistributorOptions = new SelectList(list, "Value", "Text");
        //}
    }

   

}