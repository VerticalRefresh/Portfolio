using System.Diagnostics;
using System.Threading.Tasks;
using Barham_C971.DataClasses;
using Barham_C971.ViewModels;
using Microsoft.Maui.Controls;

namespace Barham_C971.Pages
{
	public partial class Login : ContentPage
	{
		public Login()
		{
			InitializeComponent();
			BindingContext = new LoginViewModel();
		}
		public async void LoginButton_Clicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//MainPage");
		}
	}
}