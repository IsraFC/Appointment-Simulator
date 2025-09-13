using AppointmentSimulator.Models;
using AppointmentSimulator.ViewModels;

namespace AppointmentSimulator.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            AppointmentsCollectionView.ItemsSource = GlobalData.Appointments;
            BindingContext = new AppointmentViewModel();
        }

        // Botón "Agregar Cita" navega a AddNewAppointmentPage
        private async void OnAddAppointmentClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddNewAppointmentPage));
        }
    }
}
