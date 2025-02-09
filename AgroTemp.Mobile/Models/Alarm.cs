using System.Globalization;

namespace AgroTemp.Mobile.Models;

public class Alarm : BaseModel
{
    private string _description;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string Description
    {
        get { return _description; }
        set
        {
            switch (value)
            {
                case "HighTemperature":
                    _description = "Przekroczono górny limit wartości temperatury na sondzie ";
                    break;
                case "LowTemperature":
                    _description = "Przekroczono dolny limit wartości temperatury na sondzie ";
                    break;
                case "HighDeltaTemperature":
                    _description = "Przekroczono górny limit wartości przyrostu na sondzie ";
                    break;
                case "NoConnectionWithModuleId":
                    _description = "Brak komunikacji z modułem odczytu temperatur o nazwie ";
                    break;
            }
        }
    }
    public string ObjectName { get; set; }

    //For display on DataGrid in Alarm....Page
    public string DescriptionToDisplay
    {
        get { return Description + ObjectName; }
    }
    public string CreatedAtToDisplay
    {
        get { return CreatedAt.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture); }
    }
    public string UpdatedAtToDisplay
    {
        get { return UpdatedAt.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture); }
    }
}
