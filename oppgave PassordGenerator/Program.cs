using System;

namespace oppgave_PassordGenerator
{
    class Program
    {   static Random Random = new Random();
        static void Main(string[] args)
        {
            if (!IsValid(args))
            {
                ShowHelpText();
                return;
            }

            var passwordLength = args[0];
            var pattern = args[1];
            int length = Convert.ToInt32(passwordLength);
            while (pattern.Length < length)
            {
                pattern = pattern.PadRight(length, 'l');
            }

            string password = "";
            foreach (var character in pattern)
            {
                if (character == 'l')
                {
                    password += GetRandomLowerCaseLetter();
                }else if (character == 'L')
                {
                    password += GetRandomUpperCaseLetter();
                }else if (character == 's')
                {
                    password += GetRandomSpecialLetter();
                }
                else
                {
                    password += GetRandomDigit();
                }
            }
            Console.WriteLine(password);

        }

        private static void ShowHelpText()
        {
            Console.WriteLine(@"PasswordGenerator  
            Options:
            - l = lower case letter
            - L = upper case letter
            - d = digit
            - s = special character (!''#¤%&/(){}[]
            Example: PasswordGenerator 14 lLssdd
            Min. 1 lower case
            Min. 1 upper case
            Min. 2 special characters
            Min. 2 digits");
        }

        private static bool IsValid(string[] args)
        {
            if (args.Length == 2)
            {
                if(!CheckIfPasswordIsValid(args) || !CheckIfPasswordCharsValid(args)){
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            
            else
            {
                return false;
            }
            
        }

        private static bool CheckIfPasswordIsValid(string[] args)
        {
            var passwordLength = args[0];
            foreach(var c in passwordLength)
            {
                var isDigit = char.IsDigit(c);
                if (!isDigit)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckIfPasswordCharsValid(string[] args)
        {
            var passwordCharacters = args[1];
            foreach (var character in passwordCharacters)
            {
                if (!(character == 'l' || character == 'L' || character == 'd' || character == 's'))
                {
                    return false;
                }

                
            }
            return true;
        }

        private static char GetRandomLowerCaseLetter()
        {
            return GetRandomLetter('a', 'z');
        }

        private static char GetRandomUpperCaseLetter()
        {
            return GetRandomLetter('A', 'Z');
        }

        private static char GetRandomSpecialLetter()
        {
            var randomSpecial = Random.Next('!', '?');
            return (char)randomSpecial;
        }

        private static char GetRandomLetter(char min, char max)
        {
            var randomNumber = Random.Next(min, max + 1);
            return (char)randomNumber;
        }

        private static int GetRandomDigit()
        {
            var randomNumber = Random.Next(0, 10);
            return randomNumber;
        }
    }
    
}