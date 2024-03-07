using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Celin;

public class SearchAndSelect : INotifyPropertyChanged
{
    public List<W01012B.Row> Rows { get; private set; }
        = new List<W01012B.Row>();
    public ICommand SelectRow {  get; private set; }
    public ICommand CustomerSearch { get; private set; }
    public event PropertyChangedEventHandler? PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    CancellationTokenSource _cancel = new CancellationTokenSource();
    public SearchAndSelect(Host host)
    {
        CustomerSearch = new Command<string>(txt =>
        {
            Task.Run(async () =>
            {
                _cancel.Cancel();
                _cancel = new CancellationTokenSource();
                try
                {
                    var tokens = txt.Split(' ');
                    var q = int.TryParse(txt, out int an8)
                    ? Make.Query(Make.List(Make.Equal("1[19]", an8.ToString())))
                    : Make.Query(tokens
                        .Select(t => Make.Like("1[20]", t)));
                    var rs = await host.RequestAsync<Form>(
                        new W01012B.Request(q));
                    Rows = rs.W01012B.data.gridData.rowset.ToList();
                    OnPropertyChanged(nameof(Rows));
                }
                catch (OperationCanceledException) { }
            });
        });

        SelectRow = new Command(e =>
        {
            Debug.WriteLine(e);
        });
    }
}
