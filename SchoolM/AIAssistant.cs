using System;
using System.Windows.Forms;

namespace SchoolM
{
    public partial class AIAssistant : Form
    {
        // Define controls programmatically to keep it 100% independent
        private ComboBox cmbAIQuestions;
        private Label lblAIAnswer;
        private Label lblTitle;

        public AIAssistant()
        {
            InitializeComponent();
            BuildAIInterface();
        }

        private void BuildAIInterface()
        {
            this.Text = "AI School Assistant";
            this.Size = new System.Drawing.Size(450, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(240, 244, 248);

            // Title Label
            lblTitle = new Label();
            lblTitle.Text = "🧠 AI School Guidance & Advisor";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(20, 20);
            lblTitle.Size = new System.Drawing.Size(400, 30);
            lblTitle.ForeColor = System.Drawing.Color.MidnightBlue;

            // ComboBox for AI Questions
            cmbAIQuestions = new ComboBox();
            cmbAIQuestions.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAIQuestions.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbAIQuestions.Location = new System.Drawing.Point(20, 70);
            cmbAIQuestions.Size = new System.Drawing.Size(390, 30);
            cmbAIQuestions.Items.AddRange(new object[] {
                "-- Select a Question for the AI --",
                "How to handle student frequent absences?",
                "What is the best way to motivate students?",
                "How to deal with late-coming students?",
                "Give me a quick school administrative tip."
            });
            cmbAIQuestions.SelectedIndex = 0;
            cmbAIQuestions.SelectedIndexChanged += new EventHandler(cmbAIQuestions_SelectedIndexChanged);

            // Label for AI Answers
            lblAIAnswer = new Label();
            lblAIAnswer.BorderStyle = BorderStyle.FixedSingle;
            lblAIAnswer.BackColor = System.Drawing.Color.White;
            lblAIAnswer.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAIAnswer.Location = new System.Drawing.Point(20, 120);
            lblAIAnswer.Size = new System.Drawing.Size(390, 160);
            lblAIAnswer.ForeColor = System.Drawing.Color.DarkSlateGray;
            lblAIAnswer.Text = "Please select a question above, and the AI Assistant will provide information instantly.";

            // Add controls to form
            this.Controls.Add(lblTitle);
            this.Controls.Add(cmbAIQuestions);
            this.Controls.Add(lblAIAnswer);
        }

        private void cmbAIQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedQuestion = cmbAIQuestions.SelectedItem.ToString();

            // AI Decision Knowledge-Base (Rule-Based Expert System)
            switch (selectedQuestion)
            {
                case "How to handle student frequent absences?":
                    lblAIAnswer.Text = "💡 AI Knowledge Response:\n\n" +
                                      "1. Analyze absence patterns (e.g., specific days).\n" +
                                      "2. Contact parents immediately to understand the root cause.\n" +
                                      "3. Create a simple makeup plan for missed lessons to save student progress.";
                    break;

                case "What is the best way to motivate students?":
                    lblAIAnswer.Text = "💡 AI Knowledge Response:\n\n" +
                                      "Studies show that implementing a 'Digital Honor Roll' or giving immediate reward points for top attendees increases classroom engagement by 25%.";
                    break;

                case "How to deal with late-coming students?":
                    lblAIAnswer.Text = "💡 AI Knowledge Response:\n\n" +
                                      "Welcome the student calmly to avoid disturbing the class, and log the time. Speak with them privately after class to understand any transport or family issues.";
                    break;

                case "Give me a quick school administrative tip.":
                    lblAIAnswer.Text = "💡 AI Knowledge Response:\n\n" +
                                      "Taking attendance in the first 10 minutes of class builds a strict system culture and provides real-time data for reliable administrative decisions.";
                    break;

                default:
                    lblAIAnswer.Text = "Please select a question above, and the AI Assistant will provide information instantly.";
                    break;
            }
        }
        private void AIAssistant_Load(object sender, EventArgs e)
        {
            // This empty method fixes the missing definition error safely
        }
    }
}