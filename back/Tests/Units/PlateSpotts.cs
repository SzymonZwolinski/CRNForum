namespace Tests.Units
{
    public class PlateSpotts
    {
        private Plate Act(User user, byte[] image, string content)
        {
            var spot = new Spotts(user, image, content);
            var plate = new Plate();

            plate.AddSpott(spot);
            return plate;
        }

        #region Positive
        [Fact]
        private void when_adding_spot_to_a_plate_should_be_added()
        {
            //Arrange
            var user = User;
            //Act
            var plate = Act(user, Image, Content);
            //Assert
            plate.Spotts.ShouldNotBeEmpty();

            var firstSpott = plate.Spotts.First();
            firstSpott.User.ShouldBe(user);
            firstSpott.Image.ShouldBe(Image);
            firstSpott.Description.ShouldBe(Content);
        }

        [Fact]
        private void when_adding_spot_without_description_should_be_added()
        {
            //Arrange
            var user = User;
            //Act
            var plate = Act(user, Image, string.Empty);
            //Assert
            plate.Spotts.ShouldNotBeEmpty();

            var firstSpott = plate.Spotts.First();
            firstSpott.User.ShouldBe(user);
            firstSpott.Image.ShouldBe(Image);
            firstSpott.Description.ShouldBeNullOrWhiteSpace();
        }
        #endregion

        #region Negative
        [Fact]
        private void when_adding_too_long_description_should_throw_an_exception()
        {
            //Arrange
            var desc = TestStringHelper.GenerateStrWithLen(256);
            //Act
            var exception = Record.Exception(() => Act(User, Image, desc));
            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        }
        #endregion

        #region TestVariables
        string Content = "Testowy komentarz ;)";
        byte[] Image = new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64 };
        User User => new User();
        #endregion
    }
}
