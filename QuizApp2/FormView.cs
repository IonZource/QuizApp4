using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuizApp2
{
    public partial class FormView : Form
    {
        List<RadioButton> buttons;
        QuizViewModel q_viewModel;
        //declare new viewmodel
        int questionNumber;
        int amountOfWrongAnswers;
        int amountOfCorrectAnswers;
        int amountOfQuestionsAnswered;
        public FormView()
        {
            InitializeComponent();
        }

        private void question_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            q_viewModel = new QuizViewModel(this);
            questionbox.Text = q_viewModel.questiontext;
            questionNumber = 1;
            QuestionNumber.Text = "Question " + (questionNumber).ToString() + ":";
            //convert int to string to display
            
            radioButton1.Text = q_viewModel.answer1;
            radioButton2.Text = q_viewModel.answer2;
            radioButton3.Text = q_viewModel.answer3;
            radioButton4.Text = q_viewModel.answer4;
            InfoDisplay1.Text = "";

            int amountOfWrongAnswers = 0;
            int amountOfCorrectAnswers = 0;
            int amountOfQuestionsAnswered = amountOfWrongAnswers + amountOfCorrectAnswers;
            //q_viewModel.questionList.add
            //implementing as list allows adding

            //for fixing the fixed data model; will probably never implement

            //for (int x = 0; x < q_viewModel.questionList.Count; x++)
            //{
            //    RadioButton rb = new RadioButton();
            //    rb.Name = "rb" + x;
            //    rb.Tag = x;
            //    rb.Dock = DockStyle.Top;
            //    panelQuestions.Controls.Add(rb);
            //    rb.BringToFront();
            //    rb.Text = "answer " + x;
            //}
            //do event listener stuff here
            q_viewModel.PropertyChanged += new PropertyChangedEventHandler(q_viewModel_PropertyChanged); 
            //event handler
            buttons = new List<RadioButton>();
            buttons.Add(radioButton1);
            buttons.Add(radioButton2);
            buttons.Add(radioButton3);
            buttons.Add(radioButton4);
        }

        void q_viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //throw new NotImplementedException();
            //ready to be interrogated; switch/business needs etc case switch propertychanged eventss blah
            switch (e.PropertyName) 
            { 
                case EventNames.OperationComplete:
                    //write code here for operation complete
                    //do it here not in viewmodel
                    buttons[0].Checked = true;
                    questionbox.Text = q_viewModel.questiontext;
                    questionNumber += 1;
                    QuestionNumber.Text = "Question " + (questionNumber).ToString() + ":";
                    //convert int to string to display
                    
                    radioButton1.Text = q_viewModel.answer1;
                    radioButton2.Text = q_viewModel.answer2;
                    radioButton3.Text = q_viewModel.answer3;
                    radioButton4.Text = q_viewModel.answer4;
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void submitbutton_Click(object sender, EventArgs e)
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs("answered"));
            //}

            //Goes through the buttons to check if the checked answer matches the correct answer
            int i;
            //iterator for buttons checking answer
            for (i = 0;  i < buttons.Count(); i++)
            {
                if (buttons[i].Checked == true)
                {
                    if (buttons[i].Text == q_viewModel.correctAnswer)
                    {
                        amountOfCorrectAnswers += 1;
                        amountOfQuestionsAnswered += 1;
                        InfoDisplay1.Text = String.Format("Previous answer was correct! {0} out of {1}", amountOfCorrectAnswers, amountOfQuestionsAnswered);
                    }
                    else
                    {
                        amountOfWrongAnswers += 1;
                        amountOfQuestionsAnswered += 1;
                        InfoDisplay1.Text = String.Format("Previous answer was wrong! {0} out of {1}", amountOfCorrectAnswers, amountOfQuestionsAnswered);
                    }
                }
            }

            if (questionNumber == q_viewModel.questionNumber)
            {
                QuestionNumber.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;
                questionbox.Visible = false;
                submitbutton.Visible = false;

                InfoDisplay1.Text = String.Format("{0} out of {1} correct!", amountOfCorrectAnswers, amountOfQuestionsAnswered);
                InfoDisplay1.Anchor = AnchorStyles.None;
                InfoDisplay1.Left = (this.Size.Width - InfoDisplay1.Width) / 2;
                InfoDisplay1.Top = (this.Size.Height - InfoDisplay1.Height) / 2;

            }

            OnPropertyChange("answered");
            //fire off event for answered

            //Load new form once done? Or center InfoDisplay1

 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        protected void OnPropertyChange(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void InfoDisplay1_Click(object sender, EventArgs e)
        {

        }
    }
}
