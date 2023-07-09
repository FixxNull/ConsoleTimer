namespace ConsoleTimer;

internal class Binding
{
    #region Properties
    
    public string DataContextPropertyName { get; }

    #endregion

    #region Constructor

    public Binding(string dataContextPropertyName) 
        => DataContextPropertyName = dataContextPropertyName;

    #endregion
}