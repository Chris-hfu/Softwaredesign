using System;
using System.Collections.Generic;

namespace Aufgabe09
{
        class MultipleAnswers : Question
    {
        public MultipleAnswers(string Questiontext, List<Answer> answers)
        {
            this.Questiontext = Questiontext;
            this.answers = answers;
            this.callToAction = "Bitte die Zahlen der eingeben. Mit Leerzeichen!(z.B.:2 3) ";
        }
        List<Answer> answers;
        public override void Show()
        {
            Console.WriteLine(Questiontext);

            for (int i = 0; i < answers.Count; i++)
            {
                Console.WriteLine(i + ": " + answers[i].text);
            }
        }

        public override bool checkAnswer(string response)
        {
            string[] responseSplitt = response.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);
            bool[] inputAnswer = new bool[answers.Count];
            for (int i = 0; i < answers.Count; i++)
            {
                inputAnswer[i] = false;
                for (int j = 0; j < responseSplitt.Length; j++)
                {
                    if (responseSplitt[j] == i.ToString())
                    {
                        inputAnswer[i] = true;
                    }
                }
                if (inputAnswer[i] != answers[i].isCorrect)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
