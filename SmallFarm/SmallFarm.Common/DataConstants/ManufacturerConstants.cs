namespace SmallFarm.Common.DataConstants
{
    public static class ManufacturerConstants
    {
        public const int NameMinLength = 10;
        public const int NameMaxLength = 70;

        public const int DescriptionMinLength = 25;
        public const int DescriptionMaxLength = 500;

        public const string PhoneNumberRegex = @"^([+]\d{12})|([0]\d{9})$";
    }
}
