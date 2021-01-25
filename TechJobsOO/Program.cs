using System;
using System.Collections.Generic;

namespace TechJobsOO
{
    class Program
    {
        static void Main(string[] args)
        {
            Job bandcamp = new Job("QA Analyst", new Employer("Bandcamp"), new Location("New York", "10010"), new PositionType("Other"), new CoreCompetency("Ruby, Javascript"));
            Job job1 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Job job2 = new Job("Web Developer", new Employer("LaunchCode"), new Location("St. Louis"), new PositionType("Front-end developer"), new CoreCompetency("JavaScript"));
            Job job3 = new Job("Ice cream tester", new Employer(""), new Location("Home"), new PositionType("UX"), new CoreCompetency("Tasting ability"));

            List<Job> jobs = new List<Job>();

            jobs.Add(bandcamp);
            jobs.Add(job1);
            jobs.Add(job2);
            jobs.Add(job3);

            foreach (Job job in jobs)
            {
                Console.WriteLine(job);
            }
            //double[] gatewayArch = { 38.6352, -90.18702 };
            //double actualDistance = bandcamp.CalculateDistance(gatewayArch);
            //Console.WriteLine($"calculated distance is: {actualDistance}");
        }
    }
}
