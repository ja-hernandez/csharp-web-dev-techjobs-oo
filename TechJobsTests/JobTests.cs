using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job testJob1 = new Job();
            Job testJob2 = new Job();
            int expectedOutput = 1;
            int actualOutput = testJob2.Id - testJob1.Id;

            Assert.IsFalse(testJob1.Id == testJob2.Id);
            Assert.AreEqual(expectedOutput, actualOutput);
        }
        [TestMethod]

        public void TestJobConstructorSetsAllFields()
        {
            Job testJob1 = new Job("Product tester", new Employer("ACME")
                , new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));
            
            string actualName = testJob1.Name;
            string expectedName = "Product tester";
            Employer actualEmployer = testJob1.EmployerName;
            Employer expectedEmployer = new Employer("ACME");
            Location actualLocation = testJob1.EmployerLocation;
            Location expectedLocation = new Location("Desert");
            PositionType actualPositionType = testJob1.JobType;
            PositionType expectedPositionType = new PositionType("Quality control");
            CoreCompetency actualCoreCompetency = testJob1.JobCoreCompetency;
            CoreCompetency expectedCoreCompetency = new CoreCompetency("Persistence");

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedEmployer.ToString(), actualEmployer.ToString());
            Assert.AreEqual(expectedLocation.ToString(), actualLocation.ToString());
            Assert.AreEqual(expectedPositionType.ToString(), actualPositionType.ToString());
            Assert.AreEqual(expectedCoreCompetency.ToString(), actualCoreCompetency.ToString());
        }
        
        [TestMethod]

        public void TestJobsForEquality()
        {
            Job testJob1 = new Job("Product tester", new Employer("ACME")
            , new Location("Desert"), new PositionType("Quality control")
            , new CoreCompetency("Persistence"));

            Job testJob2 = new Job("Product tester", new Employer("ACME")
            , new Location("Desert"), new PositionType("Quality control")
            , new CoreCompetency("Persistence"));

            Assert.IsFalse(testJob1.Equals(testJob2));
        }

        [TestMethod]

        public void BlankLinesAroundJobInfo()
        {
            Job testJob1 = new Job("Product tester", new Employer("ACME")
                , new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));

            string expectedOutput = "\n" + "\n";
            string actualOutput = testJob1.ToString();
            actualOutput = actualOutput.Substring(0, 1) + actualOutput.Substring(actualOutput.Length - 1, 1);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        
        public void LabelsPrintedFromToString()
        {
            Job testJob1 = new Job("Product tester", new Employer("ACME")
                , new Location("Desert"), new PositionType("Quality control")
                , new CoreCompetency("Persistence"));

            string actualOutput = testJob1.ToString();
            string expectedOutput = "\n";
            expectedOutput += "ID: 4\n";
            expectedOutput += "Name: Product tester\n";
            expectedOutput += "Employer: ACME\n";
            expectedOutput += "Location: Desert, ZIP Code: 63102\n";
            expectedOutput += "Distance from St. Louis: 0 mi\n";
            expectedOutput += "Position Type: Quality control\n";
            expectedOutput += "Core Competency: Persistence\n";
            expectedOutput += "\n";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]

        public void EmptyFieldsHandled()
        {
            Job testJob1 = new Job("Job", new Employer("")
                , new Location("", ""), new PositionType("")
                , new CoreCompetency(""));

            string actualOutput = testJob1.ToString();
            string expectedOutput = "\n";
            expectedOutput += "ID: 3\n";
            expectedOutput += "Name: Job\n";
            expectedOutput += "Employer: Data not available\n";
            expectedOutput += "Location: Data not available\n";
            expectedOutput += "Distance from St. Louis: Data not available\n";
           expectedOutput += "Position Type: Data not available\n";
            expectedOutput += "Core Competency: Data not available\n";
            expectedOutput += "\n";

            Assert.AreEqual(expectedOutput, actualOutput);
        } 

        [TestMethod]

        public void AllEmptyDoesntExist()
        {
            Job testJob1 = new Job("", new Employer("")
                , new Location("", ""), new PositionType("")
                , new CoreCompetency(""));

            string actualOutput = testJob1.ToString();
            string expectedOutput = "\n";
            expectedOutput += "OOPS! This job does not seem to exist.";

            Assert.AreEqual(expectedOutput, actualOutput);

        }

        /*
In order for this compile, you will need to implement the following:
1)	Have a public double CalculateDistance() method part of your Job class; this method can will an array of two doubles (representing the latitude & longitude for a given geo-coordinate)
2)	Have the constructor for the Location class take a second argument (type string, representing the zipcode)
3)	Update your other tests that rely on calling the Location constructor accordingly…
*/
        [TestMethod]

        public void TestZipCodeAdditionToJob()
        {
            Job bandcamp = new Job("QA Analyst", new Employer("Bandcamp")
                , new Location("New York", "10010"), new PositionType("Other")
                , new CoreCompetency("Ruby, Javascript"));

            string actualOutput = bandcamp.EmployerLocation.ZipCode;
            string expectedOutput = "10010";

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        
        public void TestZipLookup()
        {
            double[] expectedOutput = { 38.6352, -90.18702 };
            double[] actualOutput = LocationData.ZipLookup("63102");
            int expectedSize = 2;
            int actualSize = actualOutput.Length;

            Assert.AreEqual(expectedOutput[0], actualOutput[0], 0.001);
            Assert.AreEqual(expectedOutput[1], actualOutput[1], 0.001);
            Assert.AreEqual(expectedSize, actualSize);

        }
        
        [TestMethod]
        public void TestCalculateDistance()
        {
            /*
            from line 79 of job_data.csv in Tech Jobs Console starter-code…
            QA Analyst,Bandcamp,New York,Other,"Ruby, Javascript"
            assuming that the Bandcamp Office address is in Nomad/Chelsea
            */
            Job bandcamp = new Job("QA Analyst", new Employer("Bandcamp"), new Location("New York", "10010" ), new PositionType("Other"), new CoreCompetency("Ruby, Javascript"));
            //working from the zipcode for the Gateway Arch in ST. Louis, MO: 63102
            double[] gatewayArch = { 38.6352, -90.18702 };
            double expectedMiles = 872.987;
            //double expectedKilometers = 1404.581;
            double actual = bandcamp.CalculateDistance(gatewayArch);/*if miles...*/
            //Assert.That(actual, Is.EqualTo(expectedMiles).Within(0.001));
            Assert.AreEqual(expectedMiles, actual, 0.001);
            /*if kilometers*/
            //Assert.That(actual, Is.EqualTo(expectedKilometers).Within(0.001));
        }


    }
}
