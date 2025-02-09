using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AgroTemp.Mobile.ViewModels;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected void SetValue<T>(ref T privateField, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(privateField, value))
        {
            return;
        }

        privateField = value;
        NotifyPropertyChanged(propertyName);
    }
}
