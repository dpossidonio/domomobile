namespace Main
{
    public interface IServiceManager
    {
        string[] GetHouses();

        string GetHouseDescription(int houseId);

        int Set(int refProperty, string value);

        string Get(int refProperty);

        bool Login(string username, string password);
    }
}