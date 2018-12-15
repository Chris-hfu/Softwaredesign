using System;
using System.Collections.Generic;

namespace Aufgabe09
{

    class MultipleChoiceQ : Question
    {
        public MultipleChoiceQ(string Questiontext, List<Answer> answers)
        {
            this.Questiontext = Questiontext;
            this.callToAction = "Bitte die Nummer für die Antwort eingeben";
            this.answers = answers;
        }
        public List<Answer> answers;
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
            int responseN = Int32.Parse(response);
            for (int i = 0; i < answers.Count; i++)
            {
                if (answers[i].isCorrect && i == responseN)
                {
                    return true;
                }
            }
            return false;
        }

    }
}