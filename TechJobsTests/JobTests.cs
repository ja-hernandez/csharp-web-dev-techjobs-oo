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
    }
}
