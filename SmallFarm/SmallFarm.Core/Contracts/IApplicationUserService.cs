namespace SmallFarm.Core.Contracts
{
    public interface IApplicationUserService
    {
        public string GetFullName(string email);

        public string GetManufacturerName(string email);
    }
}
