using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ConsoleTimer;

internal class ViewModel : INotifyPropertyChanged
{
    #region Fields

    public event PropertyChangedEventHandler? PropertyChanged;

    #endregion

    #region Properties

    public string Time { get; set; }

    #endregion

    #region Constructor
    
    public ViewModel(Model model)
    {
        Time = "00:00:00";

        model.TimeChanged += ModelOnTimeChanged;
    }

    #endregion

    #region Private Methods
    
    private void ModelOnTimeChanged(DateTime obj)
    {
        Time = obj.ToLongTimeString();
    }

    #endregion

    #region Protected Methods

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion
}