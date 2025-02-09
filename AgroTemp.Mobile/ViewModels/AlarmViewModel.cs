using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace AgroTemp.Mobile.ViewModels;

public class AlarmViewModel : BaseViewModel
{
    private ObservableCollection<Alarm> _alarmsActiveList;
    public ObservableCollection<Alarm> AlarmsActiveList
    {
        get { return _alarmsActiveList; }
        set { SetValue(ref _alarmsActiveList, value); }
    }
    private bool _isRefreshing;
    public bool IsRefreshing
    {
        get { return _isRefreshing; }
        set { SetValue(ref _isRefreshing, value); }
    }
    private ObservableCollection<Alarm> _alarmsHistoryList;
    public ObservableCollection<Alarm> AlarmsHistoryList
    {
        get { return _alarmsHistoryList; }
        set { SetValue(ref _alarmsHistoryList, value); }
    }
    private DateTime _dateFrom;
    public DateTime DateFrom
    {
        get { return _dateFrom; }
        set { SetValue(ref _dateFrom, value); }
    }
    private DateTime _dateTo;
    public DateTime DateTo
    {
        get { return _dateTo; }
        set { SetValue(ref _dateTo, value); }
    }
   
    public ICommand RefreshCommand { get; set; }
    public ICommand FilterAlarmsCommand { get; set; }

    private readonly IAlarmService _alarmService;

    public AlarmViewModel(IAlarmService alarmService)
    {
        _alarmService = alarmService;

        DateFrom = DateTime.Now.AddDays(-7);
        DateTo = DateTime.Now;

        Task.Run(async () => await InitializeAlarmsHistoryListAsync());

        RefreshCommand = new Command(async () => 
        {
            await Task.Delay(1000);

            await InitializeAlarmsActiveListAsync();

            IsRefreshing = false;
        });
        FilterAlarmsCommand = new Command(async () => await InitializeAlarmsHistoryListAsync());
    }

    public async Task InitializeAlarmsActiveListAsync()
    {
        var result = await _alarmService.GetActiveAlarmsAsync();

        AlarmsActiveList = new ObservableCollection<Alarm>(result);
    }

    private async Task InitializeAlarmsHistoryListAsync()
    {
        var result = await _alarmService.GetAlarmsByTimeIntervalAsync(DateFrom, DateTo);

        AlarmsHistoryList = new ObservableCollection<Alarm>(result);
    }
}
