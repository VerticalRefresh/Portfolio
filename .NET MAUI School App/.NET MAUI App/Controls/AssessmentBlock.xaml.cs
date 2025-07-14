using Barham_C971.DataClasses;
using System.Diagnostics;
using Barham_C971.Pages;

namespace Barham_C971.Controls;

public partial class AssessmentBlock : ContentView
{
    // Constructor
    public AssessmentBlock()
	{
		InitializeComponent();
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += OnTapped;
        this.GestureRecognizers.Add(tapGesture);
    }

    // Bindable properties for the AssessmentBlock

    //Name
    public static readonly BindableProperty AssessmentNameProperty = BindableProperty.Create(
        nameof(AssessmentName),
        typeof(string),
        typeof(AssessmentBlock),
        default(string));

    public string AssessmentName
    {
        get => (string)GetValue(AssessmentNameProperty);
        set => SetValue(AssessmentNameProperty, value);
    }

    //Type
    public static readonly BindableProperty AssessmentTypeProperty = BindableProperty.Create(
        nameof(AssessmentType),
        typeof(string),
        typeof(AssessmentBlock),
        default(string));

    public string AssessmentType
    {
        get => (string)GetValue(AssessmentTypeProperty);
        set => SetValue(AssessmentTypeProperty, value);
    }


    //Status
    public static readonly BindableProperty AssessmentStatusProperty = BindableProperty.Create(
        nameof(AssessmentStatus),
        typeof(string),
        typeof(AssessmentBlock),
        default(string));

    public string AssessmentStatus
    {
        get => (string)GetValue(AssessmentStatusProperty);
        set => SetValue(AssessmentStatusProperty, value);
    }


    //Start Date
    public static readonly BindableProperty AssessmentStartDateProperty = BindableProperty.Create(
        nameof(AssessmentStartDate),
        typeof(DateTime),
        typeof(AssessmentBlock),
        default(DateTime));

    public DateTime AssessmentStartDate
    {
        get => (DateTime)GetValue(AssessmentStartDateProperty);
        set => SetValue(AssessmentStartDateProperty, value);
    }

    //End Date
    public static readonly BindableProperty AssessmentEndDateProperty = BindableProperty.Create(
        nameof(AssessmentEndDate),
        typeof(DateTime),
        typeof(AssessmentBlock),
        default(DateTime));

    public DateTime AssessmentEndDate
    {
        get => (DateTime)GetValue(AssessmentEndDateProperty);
        set => SetValue(AssessmentEndDateProperty, value);
    }

    //Notes
    public static readonly BindableProperty AssessmentNotesProperty = BindableProperty.Create(
        nameof(AssessmentNotes),
        typeof(string),
        typeof(AssessmentBlock),
        default(string));

    public string AssessmentNotes
    {
        get => (string)GetValue(AssessmentNotesProperty);
        set => SetValue(AssessmentNotesProperty, value);
    }

    // Event handler for tap gesture
    public async void OnTapped(object sender, EventArgs e)
    {
        var assessment = BindingContext as Assessment;
        if (assessment != null)
        {
            var assessmentId = assessment.AssessmentID;
            await Shell.Current.GoToAsync($"AssessmentPage?assessmentId={assessmentId}");
        }
    }
}