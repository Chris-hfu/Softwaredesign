using System;
using System.Collections.Generic;

namespace Aufgabe09
{
        abstract class Question
    {
        public string Questiontext;
        public string callToAction;

        public abstract void Show();

        public abstract bool checkAnswer(string input);

    }
}
