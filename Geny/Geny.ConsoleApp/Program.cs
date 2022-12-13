using System;
using System.Text;
using System.IO;

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
                Console.WriteLine();

                List<string> questions = GetQuestions();
                List<int> answers = GetAnswers();
                int countQuestions = questions.Count;
                int countRightAnswers = 0;

                Random random = new Random();

               

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));
                    var rundomQuestionIndex=random.Next(0,questions.Count);
                    Console.WriteLine(questions[rundomQuestionIndex]);
                    int userAnswer = GetUserAnswer();

                    int rightAnswer = answers[rundomQuestionIndex];

                    if (userAnswer == rightAnswer)
                    {
                        countRightAnswers++;
                    }
                    questions.RemoveAt(rundomQuestionIndex);
                    answers.RemoveAt(rundomQuestionIndex);
                }

                Console.WriteLine("Количество правилных ответов: " + countRightAnswers);

                string diagnose = CalculateDiagnose(countQuestions,countRightAnswers);
               
                Console.WriteLine(userName + ", Ваш диагноз: " + diagnose);

                SaveUserResult(userName, countRightAnswers, diagnose);

                Console.WriteLine();
                bool userShoice = GetUserShoice("Хотите посмотрет предыдущие результаты игры?");
                Console.WriteLine();
                if(userShoice)
                {
                    ShowUserResult();
                }
                Console.WriteLine();
                 userShoice = GetUserShoice("Хотите начать сначала?");
                if(userShoice==false)
                {
                    break;
                }
            }
        }

            private static void ShowUserResult()
        {
            StreamReader reader = new StreamReader("userResult.txt",  Encoding.UTF8);
            Console.WriteLine("{0,-20}{1,25}{2,10}","Имя","Кол-во правилных ответов","Диагноз");
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] values = line.Split('#');
                string name=values[0];
                int countRightAnswers=Convert.ToInt32(values[1]);
                string diagnose=values[2];

                Console.WriteLine("{0,-20}{1,25}{2,10}", name, countRightAnswers, diagnose);
            }
            
            reader.Close();
        }
            public  static void SaveUserResult(string userName, int countRightAnswers, string diagnose)
        {
            string value = $"{userName}#{countRightAnswers}#{diagnose}";
            AppendToFile("userResult.txt", value);
        }
            public static void AppendToFile(string fileName, string value)
        {
            StreamWriter writer = new StreamWriter(fileName,true,Encoding.UTF8);
            writer.WriteLine(value);
            writer.Close();
        }
            public static string CalculateDiagnose(int countQuestions, int countRightAnswers)
        {
            string[] diagnoses = GetDiagnoses();

            int percentRightAnswers = countRightAnswers * 100 / countQuestions;
            return diagnoses[percentRightAnswers/20];
           
        }
            public static int GetUserAnswer()
        {
            //Можно так сделат!
            //int userAnswer;
            //while (int.TryParse(Console.ReadLine(), out userAnswer) == false)
            //{
            //    Console.WriteLine("Введите число!");
            //}

            //return userAnswer;

            //Или можно так сделат
             while (true)
                 {
                 try
                 {
                   return Convert.ToInt32(Console.ReadLine());
                 }
                   catch (FormatException e)
                 {
                   Console.WriteLine("Введите число!");
                 }
                 catch (OverflowException)
                 {
                   Console.WriteLine("Число слишком длини!");
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
            public static List<string> GetQuestions()

            {
            List<string> questions = new List<string>();
                questions.Add("Сколько будет два плюс два умноженное на два?");
                questions.Add("Бревно нужно распилить на 10 частей,сколько надо сделать распилов?");
                questions.Add("На двух руках 10 пальцев.Сколько пальцев на  5 руках?");
                questions.Add("Укол делают каждые полчаса,сколько нужно минут для трех уколов? ");
                questions.Add("Пять свечей горело,две потухли.Сколько свечей осталось?");
                return questions;
            }
            public static List<int> GetAnswers()
            {
                List<int> answers = new List<int>();
                answers.Add(6);
                answers.Add(9);
                answers.Add(25);
                answers.Add(60);
                answers.Add(2);
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
 
