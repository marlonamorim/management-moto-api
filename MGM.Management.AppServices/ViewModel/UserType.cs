using System.ComponentModel;

namespace MGM.Management.AppServices.ViewModel
{
    public enum UserType
    {
        [Description("admin")]
        Admin,
        [Description("entregador")]
        DeliveryPerson
    }
}
