using System.ComponentModel;
using System.Runtime.CompilerServices;


//Dùng để thông báo khi thuộc tính này bị thay dôi 
public class BaseViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}