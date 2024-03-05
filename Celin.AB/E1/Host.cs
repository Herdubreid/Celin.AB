using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Celin;

public class Host : AIS.Server, INotifyPropertyChanged
{
    bool _isAuthenticated;
    public bool IsAuthenticated
    {
        get => _isAuthenticated;
        private set
        {
            _isAuthenticated = value;
            OnPropertyChanged();
        }
    }
    public ICommand Authenticate { get; private set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    public Host(IConfiguration config, ILogger<Host> logger)
        : base(config.GetValue<string>("BaseUrl"), logger)
    {
        Authenticate = new Command(
            execute: async () =>
            {
                try
                {
                    await AuthenticateAsync();
                    IsAuthenticated = true;
                }
                catch (Exception ex)
                {

                }
            },
            canExecute: () => !IsAuthenticated);
    }
}
