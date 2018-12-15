using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace Aufgabe09
{
    class Program
    {
        static bool isGameRunning;
        static public int Points = 0;
        static public int attemptedQuestions = 0;
        static public List<Question> questionCatalogue = new List<Question>();



        static void Main(string[] args)
        {

            questionCatalogue = ReadQuizCatalogueFromFile();
            if (questionCatalogue == null)
            {
                questionCatalogue = new List<Question>();
            }
            StartGame();
        }
        public static void StartGame()
        {
            isGameRunning = true;
            Console.WriteLine("Willkommen");
            do
            {

                Console.WriteLine("Punkte: " + Points);
                Console.WriteLine("Beantwortete Fragen: " + attemptedQuestions);
                Console.WriteLine("Welche Option:");
                Console.WriteLine("1) Frage eintragen");
                Console.WriteLine("2) Frage beantworten");
                Console.WriteLine("3) Beenden");

                string Option = Console.ReadLine();

                if (Option == "1")
                {
                    InsertQuestion();
                    questionCatalogue = ReadQuizCatalogueFromFile();
                }
                else if (Option == "2")
                {
                    AskQuestion();

                }
                else if (Option == "3")
                {
                    Console.WriteLine("Bye");
                    break;
                }

            } while (isGameRunning);
        }


        public static void AskQuestion()
        {
            attemptedQuestions++;
            Random r = new Random();
            int randomQIndex = r.Next(questionCatalogue.Count);
            Question randomQuestionToAsk = questionCatalogue[randomQIndex];

            randomQuestionToAsk.Show();
            Console.WriteLine(randomQuestionToAsk.callToAction);
            string userAnswer = Console.ReadLine();
            if (randomQuestionToAsk.checkAnswer(userAnswer))
            {
                Points++;
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Falsch");
            }

        }

        public static void InsertQuestion()
        {
            Console.WriteLine("Bitte Frage eingeben!");
            string Questiontext = Console.ReadLine();
            Console.WriteLine("Um was für ein Fragentyp handelt es sich?");
            Console.WriteLine("1) Text eingeben");
            Console.WriteLine("2) Ja oder Nein Frage");
            Console.WriteLine("3) Schätzfrage");
            Console.WriteLine("4) Frage mit mehreren richigen Anwtorten");
            Console.WriteLine("5) Frage mit einer richtigen Anwtort");

            string Type = Console.ReadLine();

            switch (Type)
            {
                case "1":
                    questionCatalogue.Add(AddWritingQuestion(Questiontext));
                    break;
                case "2":
                    questionCatalogue.Add(AddYesNoQuestion(Questiontext));
                    break;
                case "3":
                    questionCatalogue.Add(AddEstimationQuestion(Questiontext));
                    break;
                case "4":
                    questionCatalogue.Add(AddMultipleAnswersQuestion(Questiontext));
                    break;
                case "5":
                    questionCatalogue.Add(AddMultipleChoiceQuestion(Questiontext));
                    break;
                default:
                    break;
            }
            WriteQuizCatalogueToFile(questionCatalogue);

        }
        public static Question AddWritingQuestion(string Question)
        {
            Console.WriteLine("Bitte Richtige Antwort eingeben!");
            String answerFree = Console.ReadLine();
            return new WritingQ(Question, answerFree);
        }

        public static Question AddYesNoQuestion(string question)
        {
            Console.WriteLine("Schreib y wenns richtig ist ein und n wenn nicht.");
            string input = Console.ReadLine();
            bool isCorrectYoN = false;
            if (input == "y")
            {
                isCorrectYoN = true;
            }
            return new YesNoQ(question, isCorrectYoN);
        }

        public static Question AddEstimationQuestion(string question)
        {
            Console.WriteLine("Bitte die Richtige Zahl eingeben.");
            int numberToGuess = Int32.Parse(Console.ReadLine());
            return new EstimationQuestion(question, numberToGuess);
        }

        public static Question AddMultipleAnswersQuestion(string question)
        {
            Console.WriteLine("Wieviele Antworten soll es geben?");
            int answerCount = Int32.Parse(Console.ReadLine());
            List<Answer> newAnswer = new List<Answer>();
            Answer userAnswer = new Answer();
            bool isCorrect;
            string text;
            for (int i = 0; i < answerCount; i++)
            {
                Console.WriteLine("Bitte Anwort eingeben");
                text = Console.ReadLine();
                Console.WriteLine("Schreib y wenns richtig ist ein und n wenn nicht.");
                if (Console.ReadLine() == "y")
                {
                    isCorrect = true;
                }
                else
                {
                    isCorrect = false;
                }
                newAnswer.Add(new Answer(text, isCorrect));
            }
            return new MultipleAnswers(question, newAnswer);
        }
        public static Question AddMultipleChoiceQuestion(string question)
        {
            Console.WriteLine("Wieviele Antworten soll es geben?");
            int answerCountSingle = Int32.Parse(Console.ReadLine());
            List<Answer> newAnswerS = new List<Answer>();
            Console.WriteLine("Bitte Richtige Antwtort eingeben!");
            newAnswerS.Add(new Answer(Console.ReadLine(), true));
            for (int i = 0; i < answerCountSingle; i++)
            {
                Console.WriteLine("Bitte Anwort eingeben");
                newAnswerS.Add(new Answer(Console.ReadLine(), false));
            }
            return new MultipleChoiceQ(question, newAnswerS);
        }

        static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Objects,
            Formatting = Formatting.Indented
        };


        public static void WriteQuizCatalogueToFile(List<Question> quizElementList)
        {
            string question = JsonConvert.SerializeObject(quizElementList, settings);
            System.IO.File.WriteAllText(@"questionCatalogue.json", question);
        }

        public static List<Question> ReadQuizCatalogueFromFile()
        {

            List<Question> quizElementList = JsonConvert.DeserializeObject<List<Question>>(File.ReadAllText(@"questionCatalogue.json"), settings);

            return quizElementList;
        }


    }

}

