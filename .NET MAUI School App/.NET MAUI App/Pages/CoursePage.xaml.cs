using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using Barham_C971.DataClasses;
using Barham_C971.ViewModels;

namespace Barham_C971.Pages;

public partial class CoursePage : ContentPage, IQueryAttributable
{
    //To collect course information from DB if not a new course, or 0 if new
	public int CourseID { get; set; }
    //To establish TermID for course or new course, appropriately appending courses to correct term
    public int TermID { get; set; }

    //ViewModel with necessary logic
    public CourseViewModel ViewModel { get; } = new CourseViewModel();
	
    //Constructor setting BindingContext to the CourseViewModel with data populated from CourseID
    public CoursePage()
	{
		InitializeComponent();
        BindingContext = ViewModel;
    }

    //Loads course data from query attributes
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        //Sets CourseID to the query string from navigation, using data protections
        if (query.TryGetValue("courseId", out object courseIdObj))
        {
            int courseId = 0;
            if (courseIdObj is string courseIdString && int.TryParse(courseIdString, out int parseId))
            {
                courseId = parseId;
            }
            else if (courseIdObj is int courseIdInt)
            {
                courseId = courseIdInt;
            }
            else
            {
                return;
            }
            CourseID = courseId;
        }
        else
        {
            Debug.WriteLine("courseId not found in query.");
        }

        //Sets TermID to the query string from navigation, using data protections
        if (query.TryGetValue("termId", out object tid))
        {
            int tidObj = 0;
            if (tid is string termIdString && int.TryParse(termIdString, out int parseTermId))
            {
                tidObj = parseTermId;
            }
            else if (tid is int termIdInt)
            {
                tidObj = termIdInt;
            }
            else
            {
                return;
            }
            TermID = tidObj;
        }
        else
        {
            Debug.WriteLine("termId not found in query.");
        }
        
        //Sets the course editing property
        if (query.TryGetValue("edit", out var editObj) && bool.TryParse(editObj?.ToString(), out var isEdit) && isEdit)
        {
            ViewModel.IsEditingCourse = true;
        }
    }

    //Loads and refreshes data when page appears
    protected override async void OnAppearing()
    {
        //Clear the ViewModel of assessments in the list
        ViewModel.Assessments.Clear();
        
        //Load course data if course has an ID from the database
        if (CourseID > 0)
        {
            await ViewModel.LoadCourseDataAsync(CourseID, TermID);
        }
        else
        //Turns on editing and sets IDs to 0 for save function to save new entry to database
        {
            ViewModel.IsEditingCourse = true;
            ViewModel.IsEditingInstructor = true;
            await ViewModel.LoadCourseDataAsync(CourseID, TermID);
        }
        //Loads normal OnAppearing behavior after loading data from ViewModel
        base.OnAppearing();
    }
}