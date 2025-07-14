using System.Diagnostics;
using Microsoft.Maui.Controls;
using Barham_C971.DataClasses;
using System;
using System.Windows.Input;

namespace Barham_C971.Controls;

public partial class CourseBlock : ContentView
{
	public CourseBlock()
	{
		InitializeComponent();
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += OnTapped;
        this.GestureRecognizers.Add(tapGesture);
    }

	public static readonly BindableProperty CourseNameProperty = BindableProperty.Create(
        nameof(CourseName),
        typeof(string),
        typeof(CourseBlock),
        default(string));

    public string CourseName
    {
        get => (string)GetValue(CourseNameProperty);
        set => SetValue(CourseNameProperty, value);
    }

    public static readonly BindableProperty CourseStartDateProperty = BindableProperty.Create(
        nameof(CourseStartDate),
        typeof(DateTime),
        typeof(CourseBlock),
        default(DateTime));

    public DateTime CourseStartDate
    {
        get => (DateTime)GetValue(CourseStartDateProperty);
        set => SetValue(CourseStartDateProperty, value);
    }

    public static readonly BindableProperty CourseEndDateProperty = BindableProperty.Create(
        nameof(CourseEndDate),
        typeof(DateTime),
        typeof(CourseBlock),
        default(DateTime));

    public DateTime CourseEndDate
    {
        get => (DateTime)GetValue(CourseEndDateProperty);
        set => SetValue(CourseEndDateProperty, value);
    }

    public static readonly BindableProperty CourseStatusProperty = BindableProperty.Create(
        nameof(CourseStatus),
        typeof(string),
        typeof(CourseBlock),
        default(string));

    public string CourseStatus
    {
        get => (string)GetValue(CourseStatusProperty);
        set => SetValue(CourseStatusProperty, value);
    }

    public static readonly BindableProperty DeleteCommandProperty = BindableProperty.Create(
        nameof(DeleteCommand),
        typeof(ICommand),
        typeof(CourseBlock));

    public ICommand DeleteCommand
    {
        get => (ICommand)GetValue(DeleteCommandProperty);
        set => SetValue(DeleteCommandProperty, value);
    }

    void OnDeleteTapped(object sender, EventArgs e)
    {
        Console.WriteLine($"DeleteCommand is {(DeleteCommand == null ? "NULL" : "NOT NULL")}");
        Console.WriteLine($"DeleteCommand can execute:  {DeleteCommand?.CanExecute(BindingContext)}");
        if (DeleteCommand?.CanExecute(BindingContext) == true)
        {
            Debug.WriteLine("Delete Executing");
            DeleteCommand.Execute(BindingContext);
        }
    }

    public static readonly BindableProperty EditCommandProperty = BindableProperty.Create(
        nameof(EditCommand),
        typeof(ICommand),
        typeof(CourseBlock));

    public ICommand EditCommand
    {
        get => (ICommand)GetValue(EditCommandProperty);
        set => SetValue(EditCommandProperty, value);
    }

    void OnEditTapped(object sender, EventArgs e)
    {
        Console.WriteLine($"EditCommand is {(EditCommand == null ? "NULL" : "NOT NULL")}");
        Console.WriteLine($"EditCommand can execute:  {EditCommand?.CanExecute(BindingContext)}");
        if (EditCommand?.CanExecute(BindingContext) == true)
        {
            Debug.WriteLine("Edit Executing");
            EditCommand.Execute(BindingContext);
        }
    }

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();
        Debug.WriteLine($"CourseBlock BindingContext changed to: {BindingContext}");
    }

    private async void OnTapped(object sender, EventArgs e)
    {
        var course = BindingContext as Course;
        if (course != null)
        {
            Debug.WriteLine($"Tapped on course: {course.CourseName}");
            await Shell.Current.GoToAsync($"CoursePage?courseId={course.CourseID}&termId={course.TermID}");
        }
    }
}