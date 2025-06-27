using AgroTemp.Mobile.Models;
using AgroTemp.Mobile.Services.Abstractions;
using System.Collections.ObjectModel;

namespace AgroTemp.Mobile.ViewModels;

[QueryProperty(nameof(Silo), "silo")]
public class ProbesWithDetailsViewModel : BaseViewModel
{
    private Silo silo; 
    public Silo Silo
    {
        get { return silo; }
        set { SetValue(ref silo, value); }
    }

    private ObservableCollection<ProbeWithDetails> _probeWithDetailsList;
    public ObservableCollection<ProbeWithDetails> ProbeWithDetailsList
    {
        get { return _probeWithDetailsList; }
        set { SetValue(ref _probeWithDetailsList, value); }
    } 

    private ExtremeValues _extremeValues;
    public ExtremeValues ExtremeValues
    {
        get { return _extremeValues; }
        set { SetValue(ref _extremeValues, value); }
    }

    private Settings _settings;
    public Settings Settings
    {
        get { return _settings; }
        set { SetValue(ref _settings, value); }
    }

    private readonly IProbeService _probeService;
    private readonly IExtremeValuesService _extremeValuesService;
    private readonly ISettingsService _settingsService;

    public ProbesWithDetailsViewModel(IProbeService probeService, IExtremeValuesService extremeValuesService, ISettingsService settingsService)
    {
        _probeService = probeService;
        _extremeValuesService = extremeValuesService;
        _settingsService = settingsService;
    }

    public async Task InitializeProbesWithDetailsListAsync()
    {
        var probesWithDetails = await _probeService.GetWithDeltailsBySiloIdAsync(Silo.Id);
        var extremeValues = await _extremeValuesService.GetBySiloIdAsync(Silo.Id);

        ProbeWithDetailsList = new ObservableCollection<ProbeWithDetails>(probesWithDetails);
        ExtremeValues = extremeValues ?? new ExtremeValues();

        Settings = await _settingsService.GetAsync();
    }
}
