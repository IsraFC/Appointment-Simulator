using System;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AppointmentSimulator.Models;

namespace AppointmentSimulator.ViewModels
{
    public partial class AppointmentViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _name = string.Empty;

        [ObservableProperty]
        private string _subject = string.Empty;

        [ObservableProperty]
        private DateOnly _appointmentDate = DateOnly.FromDateTime(DateTime.Today);

        [ObservableProperty]
        private TimeSpan _startingTime = new(9, 0, 0);

        [ObservableProperty]
        private TimeSpan _endingTime = new(10, 0, 0);

        // Agregar cita
        [RelayCommand]
        private async Task AddAppointment()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Subject))
            {
                await Shell.Current.DisplayAlert("Error", "Debes llenar todos los campos.", "Ok");
                return;
            }

            if (StartingTime >= EndingTime)
            {
                await Shell.Current.DisplayAlert("Error", "La hora de inicio debe ser menor a la hora de término.", "Ok");
                return;
            }

            // Validar traslapes
            if (GlobalData.Appointments.Any(a =>
                a.AppointmentDate == AppointmentDate &&
                (StartingTime < a.EndingTime && EndingTime > a.StartingTime)))
            {
                await Shell.Current.DisplayAlert("Error", "La cita se traslapa con otra existente.", "Ok");
                return;
            }

            // Validar fecha
            if (AppointmentDate < DateOnly.FromDateTime(DateTime.Today))
            {
                await Shell.Current.DisplayAlert("Error", "La fecha de la cita no puede ser anterior a hoy.", "Ok");
                return;
            }

            Appointment appointment = new()
            {
                Name = Name.Trim(),
                Subject = Subject.Trim(),
                AppointmentDate = AppointmentDate,
                StartingTime = StartingTime,
                EndingTime = EndingTime
            };

            GlobalData.Appointments.Add(appointment);

            await Shell.Current.DisplayAlert("Éxito", "La cita fue registrada correctamente.", "Ok");
            await Shell.Current.GoToAsync("..");
        }
    }
}
