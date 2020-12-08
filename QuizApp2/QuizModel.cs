using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuizApp2
{
    public sealed class Question
    {
        //make class and data public for long term access
        public int questionNumber { get; set; }
        public string questiontext { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public string correctAnswer { get; set; }
    }
}
