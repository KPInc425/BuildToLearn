namespace BTL.GuessTheNextNumber;
public class NumberGame
{
    public NumberGame(string playerName) {
        if (playerName.Length < 3) {
            throw new Exception("Player name too short");
        }

        PlayerName = playerName;
        InitializeCurrentNumber();

    }

    public NumberGame(Guid id, string playerName) : this(playerName) {
        if (id == Guid.Empty) {
            throw new Exception("ID cannot be empty");
        }
        ID = id;
    }
    public Guid ID { get; private set; } = new Guid();
    public string PlayerName { get; private set; }
    public short CurrentNumber { get; private set; }
    public long Score { get; private set;} = 0;

    private void InitializeCurrentNumber() {
        var rnd = new Random();
        var firstNumber = (short) rnd.NextInt64(0, 10);
        CurrentNumber = firstNumber;
    }
}
