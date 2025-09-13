using AppointmentSimulator.Pages;

namespace AppointmentSimulator
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddNewAppointmentPage), typeof(AddNewAppointmentPage));
        }
    }
}
