
using Microsoft.Maui.Controls;
using Barham_C971.DataClasses;
using System;
using System.Diagnostics;

namespace Barham_C971.Controls
{
	public partial class TermTab : ContentView
	{
#pragma warning disable CA1416 // Validate platform compatibility

        public TermTab()
		{
			InitializeComponent();
			var tapGesture = new TapGestureRecognizer();
			tapGesture.Tapped += OnTapped;
			this.GestureRecognizers.Add(tapGesture);
		}

		//Tab Text
        public static readonly BindableProperty TabTextProperty = BindableProperty.Create(
			nameof(TabText),
			typeof(string),
			typeof(TermTab),
			default(string));

        public string TabText
        {
            get => (string)GetValue(TabTextProperty);
            set => SetValue(TabTextProperty, value);
        }

		//Is selected tab
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(
			nameof(IsSelected),
			typeof(bool),
			typeof(TermTab),
			false,
			propertyChanged: OnIsSelectedChanged);

        public bool IsSelected
        {
            get => (bool)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

        //Term bound to tab
        public static readonly BindableProperty BoundTermProperty = BindableProperty.Create(
            nameof(BoundTerm),
            typeof(Term),
            typeof(TermTab),
            default(Term));

        public Term BoundTerm
        {
            get => (Term)GetValue(BoundTermProperty);
            set => SetValue(BoundTermProperty, value);
        }

        //Method to change visual state of the tab when selected
        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var termTab = bindable as TermTab;
            if (termTab != null)
            {
                bool isSelected = (bool)newValue;
                VisualStateManager.GoToState(termTab.TermButton, isSelected ? "Selected" : "Unselected");
            }
        }

        // Event to notify when the tab is tapped
        public event EventHandler<Term> TermTabTapped;
        private void OnTapped(object sender, EventArgs e)
		{
            TermTabTapped?.Invoke(this, BoundTerm ?? BindingContext as Term);
        }
#pragma warning restore CA1416 // Validate platform compatibility
	}
}