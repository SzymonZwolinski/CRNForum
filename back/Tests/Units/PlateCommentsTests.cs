namespace Tests.Units
{
   
    public class PlateCommentsTests
    { 
        private Plate Act(string content, User user, int sequence)
        {
            var plate = new Plate();
            var comment = new Comment(content, user, sequence);
            plate.AddComment(comment);

            return plate;
        }

        #region Positive
        [Fact]
        public void when_adding_comment_to_existing_plate_should_be_added()
        {
            //Arrange
            var user = User;
            //Act
            var commentedPlate = Act(Content, user, Sequence);

            //Assert
            commentedPlate.Comments.ShouldNotBeEmpty();

            var firstComment = commentedPlate.Comments.First();
            firstComment.ShouldNotBeNull();
            firstComment.Content.ShouldBe(Content);
            firstComment.User.ShouldBe(user);
            firstComment.Sequence.ShouldBe(Sequence);
            firstComment.DislikeCount.ShouldBe(0);
            firstComment.LikeCount.ShouldBe(0);
        }

        #endregion

        #region Exceptions
        [Fact]
        public void when_creating_comment_with_too_long_content_should_throw_an_exception()
        {
            //Arrange
            var content = TestStringHelper.GenerateStrWithLen(1024);
            var user = User;

            //Act
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Act(content, user, Sequence));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void when_creating_comment_with_empty_content_should_throw_an_exception()
        {
            //Arrange
            var contnet = string.Empty;
            var user = User;

            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => Act(contnet, user, Sequence));

            //Assert
            exception.ShouldNotBeNull();
            exception.ShouldBeOfType<ArgumentNullException>();
        }

        #endregion

        #region TestVariables
        string Content = "Testowy komentarz ;)";
        int Sequence = 1;
        User User => new User();
        #endregion
    }
}
