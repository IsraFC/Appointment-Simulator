namespace AppointmentSimulator.Pages;
using AppointmentSimulator.ViewModels;

public partial class AddNewAppointmentPage : ContentPage
{
	public AddNewAppointmentPage()
	{
		InitializeComponent();
        BindingContext = new AppointmentViewModel();
    }
}