using System.ComponentModel;

namespace ConsoleTimer;

internal class View
{
    #region Fields

    private string _text;

    #endregion

    #region Properties

    public object DataContext { get; }

    public string Text
    {
        get => _text;
        set
        {
            _text = value;

            Update();
        }
    }

    #endregion

    #region Constructor

    public View(ViewModel dataContext)
    {
        DataContext = dataContext;
        var binding = new Binding("Time");

        SetBinding(nameof(Text), binding);
    }

    #endregion

    #region Public Methods

    public void Show()
    {
        Update();
        Console.ReadLine();
    }

    #endregion

    #region Private Methods

    private void Update()
    {
        Console.Clear();

        foreach (var text in Text)
        {
            Console.ForegroundColor = text == ':'
                ? ConsoleColor.DarkRed
                : ConsoleColor.Cyan;

            Console.Write(text);
        }
    }

    private void SetBinding(string dependencyPropertyName, Binding binding)
    {
        SetPropertyValue(dependencyPropertyName, binding);

        if (DataContext is INotifyPropertyChanged notify)
        {
            notify.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == binding.DataContextPropertyName)
                {
                    SetPropertyValue(dependencyPropertyName, binding);
                }
            };
        }
    }

    private void SetPropertyValue(string dependencyPropertyName, Binding binding)
    {
        var sourceProperty = DataContext.GetType().GetProperty(binding.DataContextPropertyName);

        var targetProperty = this.GetType().GetProperty(dependencyPropertyName);

        targetProperty?.SetValue(this, sourceProperty?.GetValue(DataContext));
    }

    #endregion
}