namespace BTL.GuessTheNextNumber.Exceptions
{
    public class PlayerNameTooShortException : Exception { 

        public static string ErrorMessage { get; } = "Player name too short";
        public override string Message => ErrorMessage;
    }
}