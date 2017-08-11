namespace Vidly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        // define the membershiptypes so you don't have to use "magic" numbers in code
        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;

    }
}