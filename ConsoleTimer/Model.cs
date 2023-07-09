using System.Timers;
using Timer = System.Timers.Timer;

namespace ConsoleTimer;

internal class Model
{
    #region Fields
    
    private readonly Timer _timer;

    #endregion

    #region Event
    
    public event Action<DateTime> TimeChanged;

    #endregion

    #region Constructor

    public Model()
    {
        _timer = new Timer(1000);
        _timer.Elapsed += TimerOnElapsed;
        _timer.Start();
    }

    #endregion

    #region Private Methods

    private void TimerOnElapsed(object? sender, ElapsedEventArgs e) 
        => TimeChanged?.Invoke(e.SignalTime);

    #endregion
}