namespace BTL.ConsoleApp;
public class App 
{
    private INextNumberGenerator _nextNumberGenerator;
    private IUserGuessProcessor _userGuessProcessor;
    public App(INextNumberGenerator nextNumberGenerator, IUserGuessProcessor userGuessProcessor)
    {
        _nextNumberGenerator = nextNumberGenerator;
        _userGuessProcessor = userGuessProcessor;
    }
    public void RunGame() 
    {
        var myGame = new NumberGame("Jackie");
        ConsoleKeyInfo userInput;

        while(true) {
            Console.WriteLine($"Hello, User!, the current number is { myGame.CurrentNumber }, do you thing the next number will be low=0, high=1, same=2 (worth 2 pts). Esc or X to quit.");
            userInput = Console.ReadKey();

            if(userInput.Key == ConsoleKey.Escape || userInput.Key == ConsoleKey.X) {
                break;
            }

            HighLowValue? myHighLowValue = null;
            var isValid = true;

            switch (userInput.Key) {
                case ConsoleKey.D0 : 
                    myHighLowValue = HighLowValue.Low;
                    break;
                case ConsoleKey.D1 : 
                    myHighLowValue = HighLowValue.High;
                    break;
                case ConsoleKey.D2 : 
                    myHighLowValue = HighLowValue.Same;
                    break;
                default : 
                    isValid = false;
                    Console.WriteLine("Please select, 0,1,2,x, or esc.");
                    break;
                    
            }

            if(isValid) {
                var isCorrect = myGame.ProcessUserGuess(_userGuessProcessor, _nextNumberGenerator, myHighLowValue.Value);
                Console.WriteLine($"Input was: { userInput.Key }, your guess was { isCorrect }, your current score is { myGame.Score }");
            }
        }
    Console.WriteLine($"Thank you for playing, your final score was: { myGame.Score }");
    }
}


