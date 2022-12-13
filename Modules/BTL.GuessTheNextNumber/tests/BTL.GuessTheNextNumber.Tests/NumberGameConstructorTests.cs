namespace BTL.GuessTheNextNumber.Entities;

public class NumberGameConstructorTests
{
    [Fact]
    public void CanCreateValidNumberGame()
    {
        // arrange
        var playerName = "Jackie Jones";

        // act
        // create new game with valid player name
        var myNumberGame = new NumberGame(playerName);

        // assert 
        // test to see that the game has been created with the correct player name
        myNumberGame.PlayerName.Should().Be(playerName, "Player should be initialized with correct value");


    }

    [Fact]
    public void DoesScoreInitToZero()
    {
        // arrange
        var playerName = "Jackie Jones";

        // act
        // create new game with valid player name
        var myNumberGame = new NumberGame(playerName);

        // assert 
        // test to see that the game has been created with the correct player name
        myNumberGame.Score.Should().Be(0, "Score inits to a 0 value");


    }

    [Fact]
    public void CurrentNumberInitsToValidValue()
    {

        // arrange
        var playerName = "Jackie Jones";

        // act
        var myNumberGame = new NumberGame(playerName);

        // assert 
        myNumberGame.CurrentNumber.Should().BeOneOf(new short[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    }

    [Fact]
    public void CanCreateValidNumberGameWithID()
    {
        var playerName = "Jackie Jones";
        var myID = Guid.NewGuid();
        // create new game with valid player name and ID
        var myNumberGame = new NumberGame(myID, playerName);

        // test to see that the game has been created with the correct player name and that the playerID is not null/empty
        myNumberGame.ID.Should().Be(myID, "ID should initialize correctly");
    }

    [Fact]
    public void CannotCreateNumberGameWithTooShortOfName()
    {
        var playerName = "a";
        var myID = Guid.NewGuid();
        // create new game with valid player name and ID
        Action act = () => new NumberGame(playerName);

        // test to see that the game has been created with the correct player name and that the playerID is not null/empty
        act.Should().Throw<PlayerNameTooShortException>().WithMessage(PlayerNameTooShortException.ErrorMessage);
    }
}