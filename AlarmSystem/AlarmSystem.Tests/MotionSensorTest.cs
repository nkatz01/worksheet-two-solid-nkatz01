using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlarmSystem.Tests
{
    [TestClass]
    public class MotionSensorTest
    {
        [TestMethod]
        public void TestThatIsTriggeredReturnsFalse()
        {
            MotionSensor sensor = new MotionSensor();
            bool isTriggered = sensor.IsTriggered;
            Assert.AreEqual(false, isTriggered);
        }

        [TestMethod]
        public void TestThatGetLocationReturnsNull()
        {
            MotionSensor sensor = new MotionSensor();
            string location = sensor.GetLocation();
            Assert.AreEqual(string.Empty, location);
        }

        [TestMethod]
        public void TestThatGetSensorTypeReturnsNull()
        {
            MotionSensor sensor = new MotionSensor();
            string sensorType = sensor.GetSensorType();
            Assert.AreEqual(string.Empty, sensorType);
        }

       
    }
}
