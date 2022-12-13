namespace BTL.GuessTheNextNumber;
public class NumberGame
{
    private short _currentNumber = -1; 
    public NumberGame(string playerName) {
        if (playerName.Length < 3) {
            throw new PlayerNameTooShortException();
        }

        PlayerName = playerName;
    }

    public NumberGame(Guid id, string playerName) : this(playerName) {
        if (id == Guid.Empty) {
            throw new Exception("ID cannot be empty");
        }
        ID = id;
    }
    public Guid ID { get; private set; } = new Guid();
    public string PlayerName { get; private set; }
    public virtual short CurrentNumber { 
        get {
            if (_currentNumber < 0 ) {
                var rnd = new Random();
                var firstNumber = (short) rnd.NextInt64(0, 10);
                _currentNumber = firstNumber;
            }
            return _currentNumber;
        } 
       private set {
        _currentNumber = value;
       }
    }
    public long Score { get; private set;} = 0;

    public bool ProcessUserGuess(IUserGuessProcessor userGuessProcessor, INextNumberGenerator nextNumberGenerator, HighLowValue highLowValue) {
        var nextNumber =  nextNumberGenerator.GenerateNextNumber();
        var isCorrect = userGuessProcessor.ProcessGuess(this, nextNumber, highLowValue);
        var incrementor = 1;
        if(highLowValue == HighLowValue.Same) {
            incrementor = 2;
        }
    
        if(isCorrect) {
            Score += incrementor;
        } else {
            Score -= incrementor;
        }

        CurrentNumber = nextNumber;

        return isCorrect;
    }

}
