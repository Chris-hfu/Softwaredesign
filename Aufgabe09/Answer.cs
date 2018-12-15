using System;
using System.Collections.Generic;

namespace Aufgabe09
{
     public class Answer
    {
        public Answer() { }
        public Answer(string text, bool isCorrect)
        {
            this.text = text;
            this.isCorrect = isCorrect;
        }

        public string text;
        public bool isCorrect;
    }
}
