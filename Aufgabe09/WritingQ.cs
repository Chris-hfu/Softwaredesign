using System;
using System.Collections.Generic;

namespace Aufgabe09
{
        class WritingQ : Question
    {
        public WritingQ(string Questiontext, string WordToWrite)
        {
            this.Questiontext = Questiontext;
            this.WordToWrite = WordToWrite;
            this.callToAction = "Bitte das Richtige Wort eingeben!";
        }
        public string WordToWrite;
        public override void Show()
        {
            Console.WriteLine(Questiontext);
        }

        public override bool checkAnswer(string response)
        {
            if (response.ToUpper() == WordToWrite.ToUpper())
            {
                return true;
            }
            return false;
        }
    }
}
