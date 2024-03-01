namespace Tests.Units
{
    public class PlatesTests
    {
        private Plate Act(string number, CultureCode? cultureCode) => new Plate(number, cultureCode);

        #region Positive

        [Fact]
        public void when_creating_plate_should_have_zero_comments_and_like_ratio_should_be_created()
        {
            //Arrange

            //Act
            var plate = Act(Number, CultureCode);

            //Assert
            plate.Number.ShouldBe(Number);
            plate.Culture.ShouldBe(CultureCode);
            plate.Comments.ShouldBeEmpty();
        }

        [Fact]
        public void when_creating_plate_with_empty_culture_code_should_be_created()
        {
            //Arrange


            //Act
            var plate = Act(Number, null);

            //Assert
            plate.Culture.ShouldBeNull();
            plate.Number.ShouldBe(Number);
            plate.Comments.ShouldBeEmpty();
        }

        #endregion

        #region Exceptions

        [Theory]
        [InlineData("123F5678")]
        [InlineData("123A")]
        public void when_creating_plate_with_invalid_len_numbers_should_throw_an_exception(string number)
        {
            //Arrange

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(number, CultureCode));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void when_creating_plate_with_empty_string_should_throw_an_exception()
        {
            //Arrange
            var number = string.Empty;

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => Act(number, CultureCode));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentNullException>();
        }

        #endregion

        #region TestVariables
        string Number = "1234AF";
        CultureCode CultureCode = CultureCode.PL;
        #endregion
    }
}