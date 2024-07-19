using System;
using System.Linq;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int target = random.Next(100, 1000); // Phát sinh số ngẫu nhiên từ 100 đến 999
            int maxAttempts = 7;
            int attempts = 0;
            bool isGuessed = false;
            
            
            Console.WriteLine("Ban co 7 lan de doan");

            while (attempts < maxAttempts && !isGuessed)
            {
                Console.Write($"lan doan thu {attempts + 1}: ");
                string input = Console.ReadLine();
                int guess;

                // Kiểm tra đầu vào có phải là số có 3 chữ số hay không
                if (!int.TryParse(input, out guess) || guess < 100 || guess > 999)
                {
                    Console.WriteLine("nhap mot so co 3 chu so tu 100 den 999.");
                    continue;
                }

                attempts++;
                string feedback = GetFeedback(guess, target);

                if (feedback == "+++")
                {
                    Console.WriteLine($"chuc mung ban da doan dung so {target} sau {attempts} lan doan.");
                    isGuessed = true;
                }
                else
                {
                    Console.WriteLine($"phan hoi: {feedback}");
                }
            }

            if (!isGuessed)
            {
                Console.WriteLine($"rat tiec ban da thua, so dung la {target}.");
            }
        }

        static string GetFeedback(int guess, int target)
        {
            char[] feedback = new char[] { ' ', ' ', ' ' };
            string guessStr = guess.ToString();
            string targetStr = target.ToString();

            for (int i = 0; i < 3; i++)
            {
                if (guessStr[i] == targetStr[i])
                {
                    feedback[i] = '+';
                }
                else if (targetStr.Contains(guessStr[i]))
                {
                    feedback[i] = '?';
                }
            }

            return new string(feedback);
        }
    }
}
