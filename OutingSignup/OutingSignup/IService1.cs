using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OutingSignup
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);


        [OperationContract]
        string InsertUserDetails(UserDetails userInfo);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserDetails
    {
        string captainName = string.Empty;
        string captainEmail = string.Empty;
        string golfer2Name = string.Empty;
        string golfer2Email = string.Empty;
        string golfer3Name = string.Empty;
        string golfer3Email = string.Empty;
        string golfer4Name = string.Empty;
        string golfer4Email = string.Empty;

        [DataMember]
        public string CaptainName
        {
            get { return captainName; }
            set { captainName = value; }
        }
        [DataMember]
        public string CaptainEmail
        {
            get { return captainEmail; }
            set { captainEmail = value; }
        }
        [DataMember]
        public string Golfer2Name
        {
            get { return golfer2Name; }
            set { golfer2Name = value; }
        }
        [DataMember]
        public string Golfer2Email
        {
            get { return golfer2Email; }
            set { golfer2Email = value; }
        }
        [DataMember]
        public string Golfer3Name
        {
            get { return golfer3Name; }
            set { golfer3Name = value; }
        }
        [DataMember]
        public string Golfer3Email
        {
            get { return golfer3Email; }
            set { golfer3Email = value; }
        }
        [DataMember]
        public string Golfer4Name
        {
            get { return golfer4Name; }
            set { golfer4Name = value; }
        }
        [DataMember]
        public string Golfer4Email
        {
            get { return golfer4Email; }
            set { golfer4Email = value; }
        }
    }

    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
