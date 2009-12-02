using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Service
{
    [ServiceContract(Namespace="http://DomoMobile.com")]
    public interface IDomoService
    {
        [OperationContract]
        string Echo();

        [OperationContract]
        bool Login(string Token,string Password);

        [OperationContract]
        string[] GetHouses(string Token);

        [OperationContract]
        string GetHouseDescription(string Token,int HouseId);

        [OperationContract]
        int Set(string Token,int RefDevice,int RefProperty,string Value);

        [OperationContract]
        string Get(string Token,int RefDevice, int RefProperty);
    }
}
