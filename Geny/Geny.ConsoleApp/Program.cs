using System;

namespace GenyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Здраствуйте! как вас зовут?");
                string userName = Console.ReadLine();
                int countQuestions = 5;

                string[] questions = GetQuestions(countQuestions);
                int[] answers = GetAnswers(countQuestions);

                int countRightAnswers = 0;

                Random random = new Random();

                for (int i = 0; i < 1000; i++)
                {
                    int index1 = random.Next(0, countQuestions);
                    int index2 = random.Next(0, countQuestions);

                    string tempQuestion = questions[index1];
                    questions[index1] = questions[index2];
                    questions[index2] = tempQuestion;

                    int tempAnswer = answers[index1];
                    answers[index1] = answers[index2];
                    answers[index2] = tempAnswer;
                }

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    Console.WriteLine(questions[i]);

                    int userAnswer = Convert.ToInt32(Console.ReadLine());

                    int rightAnswer = answers[i];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                }

                Console.WriteLine("Количество правилных ответов: " + countRightAnswers);

                string[] diagnoses = GetDiagnoses();

                Console.WriteLine(userName + ", Ваш диагноз: " + diagnoses[countRightAnswers]);

                bool userShoice = GetUserShoice("Хотите начать сначала?");
                if(userShoice==false)
                {
                    break;
                }
            }
        }
            public static bool GetUserShoice(string message)
        {
            while (true)
            {
                Console.WriteLine(message + " Введите да или нет");
                string userInput = Console.ReadLine();

                if (userInput.ToLower() == "нет")
                {
                    return false;
                }
                if (userInput.ToLower() == "да")
                {
                    return true;
                }
            }
        }
            public static string[] GetQuestions(int countQuestions)

            {
                string[] questions = new string[countQuestions];
                questions[0] = "Сколько будет два плюс два умноженное на два?";
                questions[1] = "Бревно нужно распилить на 10 частей,сколько надо сделать распилов?";
                questions[2] = "На двух руках 10 пальцев.Сколько пальцев на  5 руках?";
                questions[3] = "Укол делают каждые полчаса,сколько нужно минут для трех уколов? ";
                questions[4] = "Пять свечей горело,две потухли.Сколько свечей осталось?";
                return questions;
            }
            public static int[] GetAnswers(int countQuestions)
            {
                int[] answers = new int[countQuestions];
                answers[0] = 6;
                answers[1] = 9;
                answers[2] = 25;
                answers[3] = 60;
                answers[4] = 2;
                return answers;
            }
            public static string[] GetDiagnoses()
            {
                string[] diagnoses = new string[6];
                diagnoses[0] = "Идиот";
                diagnoses[1] = "Кретин";
                diagnoses[2] = "Дурак";
                diagnoses[3] = "Нормальный";
                diagnoses[4] = "Талант";
                diagnoses[5] = "Гений";
                return diagnoses;
            }
        
}   }
 