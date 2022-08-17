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
    }
}
