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
            string jobsInfo = "\n";
            if (Name == "" && EmployerName.ToString() == "" && JobType.ToString() == "" && JobCoreCompetency.ToString() == "")
            {
                jobsInfo += "OOPS! This job does not seem to exist.";
                return jobsInfo;
            }
            jobsInfo += $"ID: {Id}\n";
            jobsInfo += $"Name: {(Name == ""? "Data not available" : Name)}\n";
            jobsInfo += $"Employer: {(EmployerName.ToString() == "" ? "Data not available" : EmployerName.ToString())}\n";
            jobsInfo += $"Position Type: {(JobType.ToString() == "" ? "Data not available" : JobType.ToString())}\n";
            jobsInfo += $"Core Competency: {(JobCoreCompetency.ToString() == "" ? "Data not available": JobCoreCompetency.ToString())}\n";
            jobsInfo += "\n";
            return jobsInfo;
        }
    }
}
