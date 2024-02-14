namespace Tests.Units
{
    public class EventTests
    {
        private Event Act(string title, string description, float longtitude, float latitude, DateTime time, float timeZone, User creator)
            => new Event(title, description, longtitude, latitude, time, timeZone, creator);

        #region Positive
        [Fact]
        public void when_creating_event_should_not_have_any_participant()
        {
            //Arrange
            //Act
            var @event = Act(Title, Description, Longtitude, Latitude, Time, TimeZone, Creator);

            //Assert
            @event.ShouldNotBeNull();
            @event.Title.ShouldBe(Title);
            @event.Description.ShouldBe(Description);
            @event.Longtitude.ShouldBe(Longtitude);
            @event.Latitude.ShouldBe(Latitude);
            @event.Participators.ShouldBeEmpty();
        }

        [Fact]
        public void when_creating_event_without_description_should_not_throw_exception()
        {
            //Arrange
            var description = string.Empty;

            //Act
            var @event = Act(Title, description, Longtitude, Latitude, Time, TimeZone, Creator);

            //Assert
            @event.ShouldNotBeNull();
            @event.Description.ShouldBeEmpty();
        }

        [Fact]
        public void when_adding_participator_to_event_should_be_added()
        {
            //Arrange
            var participator = new User();
            var @event = Act(Title, Description, Longtitude, Latitude, Time, TimeZone, Creator);

            //Act
            @event.AddParticipator(participator);

            //Arrange
            @event.Participators.ShouldNotBeEmpty();

            var firstParticipator = @event.Participators.AsEnumerable().First();
            firstParticipator.User.ShouldBe(participator);
        }

        [Fact]
        public void when_removing_participator_from_event_should_be_removed()
        {
            //Arrange
            var participator = new User();
            var @event = Act(Title, Description, Longtitude, Latitude, Time, TimeZone, Creator);

            @event.AddParticipator(participator);

            //Act
            @event.RemoveParticipator(participator);

            //Arrange
            @event.Participators.ShouldBeEmpty();
        }
        #endregion

        #region Negative
        [Fact]
        public void when_creating_event_with_null_title_should_throw_an_exception()
        {
            //Arrange
            var title = string.Empty;

            //Act
            var exception = Record.Exception(() => Act(title, Description, Longtitude, Latitude, Time, TimeZone, Creator));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentNullException>();
        }

        [Fact]
        public void when_creating_event_with_too_long_title_should_throw_an_exception()
        {
            //Arrange
            var title = TestStringHelper.GenerateStrWithLen(64);

            //Act
            var exception = Record.Exception( () => Act(title, Description, Longtitude, Latitude, Time, TimeZone, Creator));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void when_creating_event_with_too_long_description_should_throw_an_exception()
        {
            //Arrange
            var description = TestStringHelper.GenerateStrWithLen(256);

            //Act
            var exception = Record.Exception(() => Act(Title, description, Longtitude, Latitude, Time, TimeZone, Creator));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void when_creating_event_with_null_user_should_throw_an_exception()
        {
            //Arrange
            var creator = (User)null;

            //Act
            var exception = Record.Exception(() => Act(Title, Description, Longtitude, Latitude, Time, TimeZone, creator));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentNullException>();
        }
        #endregion

        #region TestVariables
        User Creator => new User();
        string Title = "Wydarzenie Testowe";
        string Description = "Wydarzenie które odbedzie sie testowo";
        float Longtitude = 26.097369f;
        float Latitude = 44.444941f;
        DateTime Time = DateTime.UtcNow;
        float TimeZone = 1;
        #endregion
    }
}