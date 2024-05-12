using CarFactoryLibrary;

namespace CarFactoryLibaray_test_Task1
{
    public class UnitTest1
    {
        [Fact]
        public void IsStopped_VelocityZero_ReturnsTrue()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 0;

            // Act
            bool result = bmw.IsStopped();

            // Assert
            Assert.True(result);
        }
        [Fact]
        public void IncreaseVelocity_Velocity10IncreasedBy20_Returns30()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.velocity = 10;
            double addedVelocity = 20;

            // Act
            bmw.IncreaseVelocity(addedVelocity);

            // Assert
            Assert.Equal(30, bmw.velocity);
        }
        [Fact]
        public void GetDirection_DrivingForward_ReturnsForward()
        {
            // Arrange
            BMW bmw = new BMW();
            bmw.drivingMode = DrivingMode.Forward;

            // Act
            string direction = bmw.GetDirection();

            // string Asserts
            Assert.Equal(DrivingMode.Forward.ToString(), direction);
            Assert.Equal("Forward", direction);
            Assert.StartsWith("F", direction);
            Assert.EndsWith("rd", direction);

            Assert.Contains("wa", direction);
            Assert.DoesNotContain("zx", direction);

            Assert.Matches("[A-Z][a-z]*rd", direction);

            Assert.DoesNotMatch("[0-9]", direction);

        }

        [Fact]
        public void GetMyCar_Call_ReturnsSameCar()
        {
            // Arrange
            BMW bmw = new BMW();
            BMW bmw2 = new BMW();

            // Act
            Car car = bmw.GetMyCar();

            // Refrence Assert
            Assert.Same(bmw, car);
            Assert.NotSame(bmw2, car);
        }
        [Fact]
        public void NewCar_RequestBMW_ReturnsBMW()
        {


            // Act
            Car? car = CarFactory.NewCar(CarTypes.BMW);

            // Type Asserts
            Assert.IsType<BMW>(car);
            Assert.IsNotType<Toyota>(car);

            Assert.IsAssignableFrom<Car>(car);
            Assert.IsAssignableFrom<Car>(new BMW());
            Assert.IsAssignableFrom<Car>(new Toyota());
        }
        [Fact]
        public void NewCar_RequestBMW_ReturnsBMW_Exception()
        {
            // Assert
            Assert.Throws<NotImplementedException>(() =>
            {
                // Act
                Car? result = CarFactory.NewCar(CarTypes.Honda);
            });
        }

    }
}