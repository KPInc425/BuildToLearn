namespace BTL.GuessTheNextNumber.Services
{
    public class NextNumberGenerator : INextNumberGenerator
    {
        public short GenerateNextNumber() {
            var rnd = new Random();
            var nextNumber = (short) rnd.NextInt64(0,10);


            return nextNumber;
        }
    }
}