namespace StudentRegistrationForm
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.labelFirstName.AssociatedControlID = this.textFirstName.ID;
            this.labelLastName.AssociatedControlID = this.textLastName.ID;
            this.labelFNumber.AssociatedControlID = this.textFNumber.ID;
            this.labelUniversity.AssociatedControlID = this.comboUniversity.ID;
            this.labelSpecialty.AssociatedControlID = this.comboSpecialty.ID;
            this.labelCourses.AssociatedControlID = this.listCourses.ID;

            this.comboSpecialty.Enabled = this.comboSpecialty.Items.Count > 0;
            this.listCourses.Enabled = this.listCourses.Items.Count > 0;
            this.buttonSubmit.Enabled = this.listCourses.Items.Count > 0;

            this.comboUniversity.Items.Add("First Uni");
            this.comboUniversity.Items.Add("Second Uni");
            this.comboUniversity.Items.Add("Third Uni");
            this.comboUniversity.Items.Add("Fourth Uni");

            this.buttonSubmit.Click += ButtonSubmit_Click;
            this.comboUniversity.SelectedIndexChanged += ComboUniversity_SelectedIndexChanged;
            this.comboSpecialty.SelectedIndexChanged += ComboSpecialty_SelectedIndexChanged;
            this.listCourses.SelectedIndexChanged += ListCourses_SelectedIndexChanged;
        }

        private void ComboUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboSpecialty.Enabled = true;
            this.comboSpecialty.Items.Add("First Specialty");
            this.comboSpecialty.Items.Add("Second Specialty");
            this.comboSpecialty.Items.Add("Third Specialty");
            this.comboSpecialty.Items.Add("Fourth Specialty");
        }

        private void ComboSpecialty_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listCourses.Enabled = true;
            this.listCourses.Items.Add("First");
            this.listCourses.Items.Add("Second");
            this.listCourses.Items.Add("Third");
            this.listCourses.Items.Add("Fourth");
        }

        private void ListCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.buttonSubmit.Enabled = true;
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            var student = this.CreateStudent();
            this.ShowStudent(student);

        }

        private Student CreateStudent()
        {
            var student = new Student();
            student.FirstName = this.textFirstName.Text;
            student.LastName = this.textLastName.Text;
            student.FNumber = this.textFNumber.Text;
            student.University = this.comboUniversity.SelectedValue.ToString();
            student.Specialty = this.comboSpecialty.SelectedValue.ToString();
            foreach (ListItem course in this.listCourses.Items)
            {
                if (course.Selected)
                {
                    student.Courses.Add(course.ToString());

                }
            }

            return student;
        }

        private void ShowStudent(Student student)
        {
            var divContainer = new HtmlGenericControl("div");
            divContainer.ID = "container";

            var h1Name = new HtmlGenericControl("h1");
            h1Name.InnerText = $"{student.FirstName} {student.LastName}";
            divContainer.Controls.Add(h1Name);

            var divInfo = new HtmlGenericControl("div");
            divInfo.InnerText = $"is part of {student.University} in {student.Specialty} for these courses: ";
            divContainer.Controls.Add(divInfo);

            var ulCourses = new HtmlGenericControl("ul");
            foreach (var course in student.Courses)
            {
                var liCourse = new HtmlGenericControl("li");
                liCourse.InnerText = course;
                ulCourses.Controls.Add(liCourse);
            }

            divContainer.Controls.Add(ulCourses);

            this.placeHolderStudent.Controls.Add(divContainer);
        }
    }
}