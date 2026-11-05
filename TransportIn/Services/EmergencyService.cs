namespace TransportIn.Services
{
    public class EmergencyService
    {
        private string _currentEmergency = "Нормальний режим";
        public event Action? OnChange;

        public string CurrentEmergency
        {
            get => _currentEmergency;
            set
            {
                if (_currentEmergency != value)
                {
                    _currentEmergency = value;
                    NotifyStateChanged();
                }
            }
        }

        private void NotifyStateChanged()
        {
            // Безпечний виклик події для Blazor Server
            Task.Run(() => OnChange?.Invoke());
        }
    }
}