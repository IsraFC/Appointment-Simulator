using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppointmentSimulator.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace AppointmentSimulator.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        // Lista de citas
        public ObservableCollection<Appointment> Appointments { get; }

        // Item seleccionado del CollectionView
        [ObservableProperty]
        private Appointment _selectedAppointment;

        public MainPageViewModel()
        {
            Appointments = GlobalData.Appointments;
        }

        // Comando para navegar a la página de agregar cita
        [RelayCommand]
        private async Task NavigateToAddAppointment()
        {
            await Shell.Current.GoToAsync(nameof(Pages.AddNewAppointmentPage));
        }

        // Comando para eliminar cita seleccionada
        [RelayCommand]
        private async Task DeleteAppointment()
        {
            if (SelectedAppointment == null) return;

            bool confirm = await Shell.Current.DisplayAlert(
                "Confirmar",
                $"¿Deseas eliminar la cita de {SelectedAppointment.Name}?",
                "Sí", "No");

            if (confirm)
            {
                Appointments.Remove(SelectedAppointment);
            }
        }
    }
}
