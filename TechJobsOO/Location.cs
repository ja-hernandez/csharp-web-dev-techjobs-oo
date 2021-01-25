using System;
namespace TechJobsOO
{
    public class Location : JobField
    {
        public string ZipCode { get; set; }
        public Location(string value, string zipCode) : base(value) {
            ZipCode = zipCode;
        }
        public Location(string value) : this(value, "63102") { }

        public override string ToString()
        {
            return base.ToString() + ", ZIP Code: " + ZipCode;
        }

    }
}
