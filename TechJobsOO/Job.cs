using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.

        public Job()
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employerName, Location employerLocation
            , PositionType jobType, CoreCompetency jobCoreCompetency): this()
        {
            Name = name;
            EmployerName = employerName;
            EmployerLocation = employerLocation;
            JobType = jobType;
            JobCoreCompetency = jobCoreCompetency;
        }

        public double CalculateDistance(double[] originLatLong)
        {
            double[] jobLatLong = LocationData.ZipLookup(EmployerLocation.ZipCode);
            
            const double avgREarth = 3961; //mi
            double radLat1 = originLatLong[0] * Math.PI/180;

            double radLat2 = jobLatLong[0] * Math.PI / 180;

            double dRadLong = (jobLatLong[1] - originLatLong[1])*Math.PI/180;

            double dRadLat = radLat2-radLat1;

            double a = Math.Sin(dRadLat/2) * Math.Sin(dRadLat / 2) + Math.Cos(radLat1)*Math.Cos(radLat2)*Math.Sin(dRadLong/2) * Math.Sin(dRadLong / 2);
            
            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            
            double d = avgREarth*c;
            
            return d; //in mi

        }

        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        // TODO: Generate Equals() and GetHashCode() methods.

        public override string ToString()
        {
            double[] originPoint = { 38.6352, -90.18702 }; //change this to change origin calculation
            //TODO: Ask user for this info, or grab from zip -> coord csv
            string jobsInfo = "\n";
            if (Name == "" && EmployerName.ToString() == "" && EmployerLocation.ToString() == ", ZIP Code: " && JobType.ToString() == "" && JobCoreCompetency.ToString() == "")
            {
                jobsInfo += "OOPS! This job does not seem to exist.";
                return jobsInfo;
            }
            jobsInfo += $"ID: {Id}\n";
            jobsInfo += $"Name: {(Name == ""? "Data not available" : Name)}\n";
            jobsInfo += $"Employer: {(EmployerName.ToString() == "" ? "Data not available" : EmployerName.ToString())}\n";
            jobsInfo += $"Location: {(EmployerLocation.ToString() == ", ZIP Code: " ? "Data not available" : EmployerLocation.ToString())}\n";
            jobsInfo += $"Distance from St. Louis: {(EmployerLocation.ToString() == ", ZIP Code: " ? "Data not available" : CalculateDistance(originPoint).ToString() + " mi")}\n";
            jobsInfo += $"Position Type: {(JobType.ToString() == "" ? "Data not available" : JobType.ToString())}\n";
            jobsInfo += $"Core Competency: {(JobCoreCompetency.ToString() == "" ? "Data not available": JobCoreCompetency.ToString())}\n";
            jobsInfo += "\n";
            return jobsInfo;
        }
    }
}
