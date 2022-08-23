namespace Lexicon_MVC.Models
{
    public class Utilities
    {
        public static string FeverCheck(int? Temp)
        {
            var cold = "°C, You are ice cold !";
            var fever = "°C, You got a fever !";
            var okay = "°C, You are OK !";
            string result = "";
            
            if (Temp < 37)
            {
                result = Temp + cold;
            }
            else if (Temp > 37)
            {
                result = Temp + fever;
            }
            else
            {
                result = Temp + okay;
            }
            return result;
        }

        public static void RandomizeNumber()
        {
            var rnd = new Random();
            int randomNumber = rnd.Next(1, 100);
            RandomNumber = randomNumber;
        }

        public static int RandomNumber { get; set; }
        public static int GuessCount { get; set; } = 0;

        public static string GuessNumber(int? input)
        {
            string result = "";

            GuessCount++;
            if (input == RandomNumber)
            {
                result = ($"Your guess of {input} is correct! It took you {GuessCount} tries!");
                   
            }
            else if (input > RandomNumber)
            {
                result = ($"Your guess of {input} is too big. Please try again: ");

            }
            else if (input < RandomNumber)
            {
                result = ($"Your guess of {input} is too small. Please try again: ");

            }
            
            return result;
        }


    }
}
