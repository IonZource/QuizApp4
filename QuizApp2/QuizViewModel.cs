using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace QuizApp2
{
    sealed class QuizViewModel:INotifyPropertyChanged
    {

        IEnumerable<Question> shuffledQuestions;

        public int CurrentQuestionIndex; 
        //change data passed to view here
        
        public int questionNumber
        {
            //get { return CurrentQuestionIndex+1; }
            get { return shuffledQuestions.Count(); }
        }
        public string questiontext
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).questiontext; }
        }
        public string answer1
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).answer1; }
        }
        public string answer2
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).answer2; }
        }
        public string answer3
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).answer3; }
        }
        public string answer4
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).answer4; }
        }
        public string correctAnswer
        {
            get { return shuffledQuestions.ElementAt(CurrentQuestionIndex).correctAnswer; }
        }

        private FormView m_View;
        public IEnumerable<Question> questionList;
        //example to tie data in
        public QuizViewModel(FormView View)
        {
            m_View = View;
            //passing the form through the viewmodel

            questionList = new List<Question>
            //view model responsible for moving data to view. okay to have example data here. or access to database
            //could create data factory/singleton
            //slow because has to reallocate memory
            //create list with amount of questions (3)
            {
            new Question
                {
                    questionNumber = 1,
                    questiontext = "test question1",
                    answer1 = "test1",
                    answer2 = "test2",
                    answer3 = "test3",
                    answer4 = "test4",
                    correctAnswer = "test3"
                },
             new Question
                {
                    questionNumber = 2,
                    questiontext = "test question2",
                    answer1 = "test5",
                    answer2 = "test6",
                    answer3 = "test7",
                    answer4 = "test8",
                    correctAnswer = "test5"
                }
            };

            shuffledQuestions = questionList.OrderBy(x => Guid.NewGuid()).ToList();
            //pseudo random shuffling of questions
            //costly in terms of resource
            //list is very costly in upper scale vs using a hash set

            //initialize variable for counting the array
            CurrentQuestionIndex = 0;

            //listener
            m_View.PropertyChanged += m_inputs_PropertyChanged;
        
        }
        void m_inputs_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "answered":
                    checkAnswer();
                    break;
            }
        }

        public void checkAnswer()
        {
            
            ErrorMessage = string.Empty;
            //if (operation != null)
            //{
            //    try
            //    {
                    
            //        ErrorMessage = string.Empty;
            //    }
            //    catch (Exception ex)
            //    {
            //        ErrorMessage = ex.Message + " " + ex.InnerException;
            //    }
            //}

            CurrentQuestionIndex++;
            if (CurrentQuestionIndex >= shuffledQuestions.Count())
            {
                CurrentQuestionIndex = 0;
            }
            OnPropertyChange(EventNames.OperationComplete);
        }
        public string ErrorMessage { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
