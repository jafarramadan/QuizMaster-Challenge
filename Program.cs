using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuizMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                StartQuiz();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Quiz done");
            }
        }

        static void StartQuiz()
        {
            List<string> questions = new List<string>
            {
                "1)Who is the best player in the world? \n 1- Cristiano Ronaldo \n 2- Cristiano Ronaldo \n 3- Cristiano Ronaldo \n 4- Cristiano Ronaldo",
                "2)How many times has Real Madrid won the Champions League? \n 1- 12 times \n 2- 13 times \n 3- 14 times \n 4- 15 times",
                "3)Who is the former coach of Real Madrid? \n 1- Carlo Ancelotti \n 2- Zidane \n 3- Rafat Ali \n 4- Xavi",
                "4)In which year did Cristiano Ronaldo leave Real Madrid? \n 1- 2012 \n 2- 1999 \n 3- 2018 \n 4- 2022",
                "5)What is the name of Real Madrid's training ground? \n 1- Camp Nou \n 2- Camp Nou \n 3- Camp Nou \n 4- Camp Nou"
            };

            List<string> correctAnswers = new List<string>
            {
                "1234",
                "4",
                "1",
                "3",
                "1234"
            };

            int questionTimeLimit = 30;
            int score = 0;

            Console.WriteLine("Please choose the correct answer by entering the number (1, 2, 3, or 4)\n");

            for (int i = 0; i < questions.Count; i++)
            {
                Console.WriteLine(questions[i]);

                var cts = new CancellationTokenSource();
                var token = cts.Token;

                Task<string> readAnswerTask = Task.Run(() =>
                {
                    string userAnswer = Console.ReadLine();
                    cts.Cancel();
                    return userAnswer;
                });

                Task timerTask = Task.Run(async () =>
                {
                    for (int t = questionTimeLimit; t > 0; t--)
                    {
                        if (token.IsCancellationRequested)
                        {
                            break;
                        }
                        Console.Write($"\rTime remaining: {t} seconds  ");
                        await Task.Delay(1000);
                    }
                    if (!token.IsCancellationRequested)
                    {
                        Console.WriteLine("\rTime's up!                     ");
                        cts.Cancel();
                    }
                });

                try
                {
                    Task.WaitAny(new Task[] { readAnswerTask, timerTask });

                    if (!readAnswerTask.IsCanceled)
                    {
                        string userAnswer = readAnswerTask.Result.Trim();
                        if (correctAnswers[i].Contains(userAnswer))
                        {
                            score++;
                            Console.WriteLine("Correct answer.\n");
                        }
                        else if (string.IsNullOrEmpty(userAnswer) || !"1234".Contains(userAnswer))
                        {
                            Console.WriteLine("Invalid answer. Please enter a number between 1 and 4.\n");
                            i--; 
                        }
                        else
                        {
                            Console.WriteLine("Wrong answer.\n");
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("You didn't answer in time.\n");
                }

                Console.WriteLine();
            }

            Console.WriteLine($"Your final score is: {score} out of {questions.Count}");
        }
    }
}

