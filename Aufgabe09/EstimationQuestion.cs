using System;
using System.Collections.Generic;

namespace Aufgabe09
{
        class EstimationQuestion : Question
    {
        public EstimationQuestion(string Questiontext, int answertext)
        {
            this.Questiontext = Questiontext;
            this.answertext = answertext;
            this.callToAction = "Schätze die Richte Zahl";
        }

        public int answertext;
        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            int responseN = Int32.Parse(response);

            if (responseN > answertext - 50 && responseN < answertext + 50)
            {
                return true;
            }
            return false;
        }

    }
}
