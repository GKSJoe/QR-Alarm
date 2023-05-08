namespace QR_Alarm;

public partial class MainPage : ContentPage
{
    private DateTime alarmTime;

    // alarm is on or off
    private bool isOn = false;

    // alarm has been snoozed
    private bool isSnooze = false;

    // Timer to check if the alarm time has been reached
    private static Timer timer;

    public MainPage()
    {
        InitializeComponent();

        // Create a Timer with an interval of 1 second
        timer = new Timer(OnTimerTick, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
    }

    // Event handler for the Set Alarm button click
    private void OnSetAlarmClicked(object sender, EventArgs e)
    {
        // Set the 'IsVisible' property of the StackLayout control to 'True' to display the TimePicker
        timePickerLayout.IsVisible = true;
    }

    private void OnSaveClicked(object sender, EventArgs e)
    {
        // Create a new DateTime using today's date and the time selected by the user
        DateTime selectedTime = DateTime.Today.Add(timePicker.Time);

        // Check if the selected time has already passed today
        if (selectedTime < DateTime.Now)
        {
            // Add one day to the selected time to set the alarm for tomorrow
            selectedTime = selectedTime.AddDays(1);
        }

        // Set the alarm time to the selected time
        alarmTime = selectedTime;

        // Set the alarm to on
        isOn = true;

        // Set Timepicker to invisible again
        timePickerLayout.IsVisible = false;

        // NEED TO ADD CLOCK SHOWING THE TIME OF ALARM HERE
    }

    // This method will be called every time the Timer ticks (every second)
    private async void OnTimerTick(object state)
    {
        // Check if the alarm is on and the current time matches the alarm time
        if (isOn && DateTime.Now >= alarmTime)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
                {
                    // If the alarm time has been reached, navigate to AlarmFirePage
                    await Navigation.PushModalAsync(new AlarmFirePage());
                });
            ///Turn alarm off to prevent loop, pretty sure there is a better way to do this. Maybe a third var isFired
            ///or something like that. Is that even needed? Could just add another if statement here that checks for
            ///isSnooze && DateTime.Now >= alarmTime. Just need to get isSnooze = true from AlarmFirePage with data binding
            ///https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/data-binding/ Just figure that out lol.
            isOn = false;
            
            
        }
    }
}