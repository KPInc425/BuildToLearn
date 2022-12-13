namespace BTL.GuessTheNextNumber.Services
{
    public class UserGuessProcessor : IUserGuessProcessor
    {
        public bool ProcessGuess(NumberGame numberGame, short nextNumber, HighLowValue highLowValue) {

            HighLowValue highLowAnswer;
            if(nextNumber > numberGame.CurrentNumber) {
                highLowAnswer = HighLowValue.High;
            } else if (nextNumber < numberGame.CurrentNumber) {
                highLowAnswer = HighLowValue.Low;
            } else {
                highLowAnswer = HighLowValue.Same;
            }
        

            return highLowValue == highLowAnswer;
        }
    }
}