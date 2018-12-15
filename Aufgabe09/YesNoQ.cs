using System;
using System.Collections.Generic;

namespace Aufgabe09
{
    class YesNoQ : Question
    {
        public YesNoQ(string Questiontext, bool isCorrect)
        {
            this.Questiontext = Questiontext;
            this.isCorrect = isCorrect;
            this.callToAction = "Bitte y oder n eingeben";
        }
        public bool isCorrect;

        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            bool yorn = false;
            if (response == "y")
            {
                yorn = true;
            }

            if (isCorrect == yorn)
            {
                return true;
            }
            return false;
        }
    }
}
