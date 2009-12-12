namespace Main
{
    public interface IServiceProvider
    {
        string[] GetHouses();

        string GetHouseDescription(int HouseId);

        int Set(int RefProperty, string Value);

        string Get(int RefProperty);
    }
}