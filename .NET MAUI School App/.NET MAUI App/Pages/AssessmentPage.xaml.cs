using System.Diagnostics;
using Barham_C971.DataClasses;
using Barham_C971.ViewModels;
namespace Barham_C971.Pages;

public partial class AssessmentPage : ContentPage, IQueryAttributable
{
    //Assessment ID
	public int AssessmentID { get; set; }

    //Set ViewModel
    public AssessmentViewModel ViewModel { get; } = new AssessmentViewModel();

    //Bind ViewModel
    public AssessmentPage()
	{
		InitializeComponent();
        BindingContext = ViewModel;
    }

    //Takes the assessment and course ID and populates fields, blank fields for new assessment
    public async void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        int courseId = 0;

        //Get the course ID from the query
        if (query.TryGetValue("courseId", out var c) && int.TryParse(c.ToString(), out var cid))
            courseId = cid;

        int assessmentId = -1;

        //Get the assessment ID from the query
        if (query.TryGetValue("assessmentId", out var a) && int.TryParse(a.ToString(), out var aid))
            assessmentId = aid;

        //If the assessment ID is 0, create a new assessment
        if (assessmentId == 0)
        {
            var course = await App.Database.GetCourseAsync(courseId);
            var instructor = await App.Database.GetInstructorAsync(course.InstructorID);
            ViewModel.Course = course;
            ViewModel.Instructor = instructor;

            ViewModel.Assessment = new Assessment
            {
                AssessmentID = 0,
                CourseID = courseId,
                AssessmentName = "",
                AssessmentStatus = "",
                AssessmentType = "",
                AssessmentStartDate = DateTime.Now,
                AssessmentEndDate = DateTime.Now 
            };

            ViewModel.IsEditingAssessment = true;
            
            //Populate the assessment collection view
            var assessmentList = await App.Database.GetAssessmentsByCourseIdAsync(courseId);
            
            foreach (var assessment in assessmentList)
            {
                ViewModel.Assessments.Add(assessment);
            }
           
            var zeros = ViewModel.Assessments.Where(a => a.AssessmentID == 0).ToList();
            
            foreach (var assessment in zeros)
            {
                ViewModel.Assessments.Remove(assessment);
            }
        }
        else
        {
            await ViewModel.LoadAssessmentDataAsync(assessmentId);
        }
    }
}