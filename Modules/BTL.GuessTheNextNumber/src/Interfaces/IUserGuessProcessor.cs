namespace BTL.GuessTheNextNumber.Interfaces
{
    public interface IUserGuessProcessor
    {
        public bool ProcessGuess(NumberGame numberGame, short nextNumber, HighLowValue highLowValue);
    }
}