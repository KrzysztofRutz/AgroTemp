using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using Syncfusion.Maui.Charts;
using System.Windows.Input;

namespace AgroTemp.Mobile.ViewModels;

[QueryProperty(nameof(ProbeWithDetails), "probe")]
[QueryProperty(nameof(Settings), "settings")]
[QueryProperty(nameof(ExtremeValues), "extremeValues")]
public class ChartOfDeltaViewModel : BaseViewModel
{
    private ProbeWithDetails _probeWithDetails;
    public ProbeWithDetails ProbeWithDetails
    {
        get { return _probeWithDetails; }
        set { SetValue(ref _probeWithDetails, value); }
    }

    private Settings _settings;
    public Settings Settings
    {
        get { return _settings; }
        set { SetValue(ref _settings, value); }
    }

    private ExtremeValues _extremeValues;
    public ExtremeValues ExtremeValues
    {
        get { return _extremeValues; }
        set { SetValue(ref _extremeValues, value); }
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

    private ChartSeriesCollection _seriesCollection;
    public ChartSeriesCollection SeriesCollection
    {
        get { return _seriesCollection; }
        set { SetValue(ref _seriesCollection, value); }
    }

    public List<DataOfChart> DataOfCharts { get; set; } = new();

    public ICommand FilterAlarmsCommand { get; set; }

    private readonly IValueWithTimeStampService<Delta> _deltaService;

    public ChartOfDeltaViewModel(IValueWithTimeStampService<Delta> deltaService)
    {
        _deltaService = deltaService;

        DateTo = DateTime.Now;
        DateFrom = DateTime.Now.AddDays(-7);

        FilterAlarmsCommand = new Command(async () => await InitializeDataSeriesAsync());
    }
    public async Task InitializeDataSeriesAsync()
    {
        SeriesCollection = new ChartSeriesCollection();
        //SeriesCollection.Clear();

        var deltaTemperatures = await _deltaService.GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(ProbeWithDetails.Id, DateFrom, DateTo);

        if (deltaTemperatures == null)
        {
            return;
        }

        for (int i = 1; i <= _probeWithDetails.SensorsCount; i++)
        {
            var sensorData = new List<DataOfChart>();

            foreach (var delta in deltaTemperatures)
            {
                sensorData.Add(new DataOfChart
                {
                    Date = delta.DateTimeStamp,
                    Value = delta.ListOfValues[i - 1].Value
                });
            }

            SeriesCollection.Add(new LineSeries()
            {
                ItemsSource = sensorData,
                XBindingPath = "Date",
                YBindingPath = "Value",
                Label = $"Czujnik {i}",
                ShowDataLabels = true,
            });
        }
    }
}
