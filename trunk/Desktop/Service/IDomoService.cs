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
        string[] GetHouses();

        [OperationContract]
        string GetHouseDescription(int i);

        [OperationContract]
        int Set(int RefDevice,int RefProperty,string Value);

        [OperationContract]
        string Get(int RefDevice, int RefProperty);
    }
}
