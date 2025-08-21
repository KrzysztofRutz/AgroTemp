using AgroTemp.WebApp.Enums;
using AgroTemp.WebApp.Models;
using AgroTemp.WebApp.Services.Abstractions;
using AgroTemp.WebApp.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components.Web;

namespace AgroTemp.WebApp.Components.Pages;

public partial class Trends
{
    [Inject]
    ISettingsService SettingsService { get; set; }
    [Inject]
    public IExtremeValuesService ExtremeValuesService { get; set; }
    [Inject]
    public ISiloService SiloService { get; set; }
    [Inject]
    public IProbeService ProbeService { get; set; }
    [Inject]
    public IValueWithTimeStampService<Temperature> TemperatureService { get; set; }
    [Inject]
    public IValueWithTimeStampService<DeltaTemperature> DeltaTemperatureService { get; set; }
    [Inject]
    public IJSRuntime JS { get; set; }

    private ChartsViewModel Model { get; set; } = new();

    private ExtremeValues _extremeValues;
    private IEnumerable<Silo> _silos = new List<Silo>();
    private IEnumerable<ProbeWithDetails> _probes = new List<ProbeWithDetails>();
    private Models.Settings _settings = new();
    private string _selectedSilo = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        _settings = await SettingsService.GetAsync();
        _silos = await SiloService.GetAllAsync();
    }

    private async Task OnSiloChanged(ChangeEventArgs e)
    {
        _selectedSilo = e.Value?.ToString();

        if (string.IsNullOrEmpty(_selectedSilo))
        {
            _probes = new List<ProbeWithDetails>();
            return;
        }            

        _probes =  await ProbeService.GetWithDeltailsBySiloIdAsync(int.Parse(_selectedSilo));
    }

    private async Task FilterChartsAsync()
    {
        await Task.Delay(100); // Delay to ensure the UI updates before fetching data
        var temperatures = await TemperatureService.GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(Model.ProbeWithDetailsId, Model.StartAt, Model.EndAt);
        var deltaTemperatures = await DeltaTemperatureService.GetByProbeIdAndBetweenStartDateTimeAndEndTimeAsync(Model.ProbeWithDetailsId, Model.StartAt, Model.EndAt);
       
        // Prepare data for the chart js 
        var sensorColors = Enum.GetValuesAsUnderlyingType(typeof(SensorColors))
            .Cast<SensorColors>()
            .Select(v => "#" + ((int)v).ToString("X6"))
            .ToArray();

        //Data from temperatures
        var temperatureLabels = temperatures.Select(t => t.DateTimeStamp.ToString("dd.MM.yyyy HH:mm")).ToArray();      
        var temperatureDatasets = new List<object>();

        if (temperatures.Any())
        {
            int seriesCount = temperatures.First().ListOfValues.Count;

            for (int i = 0; i < seriesCount; i++)
            {
                temperatureDatasets.Add(new
                {                 
                    label = $"Czujnik {i + 1}",
                    borderColor = sensorColors[i],
                    pointBorderColor = "#FFF",
                    pointBackgroundColor = sensorColors[i],
                    pointBorderWidth = 2,
                    pointHoverRadius = 4,
                    pointHoverBorderWidth = 1,
                    pointRadius = 4,
                    backgroundColor = "transparent",
                    fill = true,
                    borderWidth = 2,
                    data = temperatures.Select(t => t.ListOfValues[i] ?? 0).ToList(), 
                });
            }
        }
        await JS.InvokeVoidAsync("drawTemperatureChart", temperatureLabels, temperatureDatasets);

        //Data from delta temperatures
        var deltaTemperatureLabels = deltaTemperatures.Select(t => t.DateTimeStamp.ToString("dd.MM.yyyy HH:mm")).ToArray();
        var deltaTemperatureDatasets = new List<object>();

        if (deltaTemperatures.Any())
        {
            int seriesCount = deltaTemperatures.First().ListOfValues.Count;

            for (int i = 0; i < seriesCount; i++)
            {
                deltaTemperatureDatasets.Add(new
                {
                    label = $"Czujnik {i + 1}",
                    borderColor = sensorColors[i],
                    pointBorderColor = "#FFF",
                    pointBackgroundColor = sensorColors[i],
                    pointBorderWidth = 2,
                    pointHoverRadius = 4,
                    pointHoverBorderWidth = 1,
                    pointRadius = 4,
                    backgroundColor = "transparent",
                    fill = true,
                    borderWidth = 2,
                    data = deltaTemperatures.Select(t => t.ListOfValues[i] ?? 0).ToList(),
                });
            }
        }
        await JS.InvokeVoidAsync("drawDeltaTemperatureChart", deltaTemperatureLabels, deltaTemperatureDatasets);          
    }

    private async Task TypeOfTemperatureChartSelected(ChangeEventArgs e)
        => await FilterChartsAsync();

    private async Task InitExtremeValuesAsync(MouseEventArgs args)
        => _extremeValues = await ExtremeValuesService.GetBySiloIdAsync(Model.SiloId); // For ensure the UI updates before fetching data
}
