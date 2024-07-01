using Base.App;

namespace Base.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CalculateAge_Test()
        {
            // Arrange
            DateTime today = DateTime.Today;
            List<DateTime> startDates = new List<DateTime>();
            startDates.Add(new DateTime(1990, 1, 1));
            startDates.Add(new DateTime(1972, 1, 1));
            startDates.Add(new DateTime(1985, 1, 1));
            startDates.Add(new DateTime(1999, 1, 1));
            startDates.Add(new DateTime(2000, 1, 1));

            var program = new Program();
            var calculateAgeMethod = typeof(Program).GetMethod("calculateAge");

            foreach (var startDate in startDates)
            {
                var parameters = new object[] { startDate.ToString("dd-MM-yyyy") }; // Convert startDate to string in format dd-mm-yyyy

                // Act
                var result = (int)calculateAgeMethod.Invoke(program, parameters);

                TimeSpan difference = today - startDate;
                int yearsDifference = (int)(difference.TotalDays / 365.25); // Approximate number of years

                // Now you can assign the years difference to an integer variable
                int age = yearsDifference;

                // Assert
                Assert.Equal(age, result);
            }
        }
    }
}