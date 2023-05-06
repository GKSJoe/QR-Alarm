using CommunityToolkit.Maui.Views;
using Microsoft.Maui.Controls.Shapes;

namespace QR_Alarm;

public partial class AlarmFirePage : ContentPage
{
	public AlarmFirePage()
	{
		InitializeComponent();
	}

    //Figure out how to disable back button, I guess all buttons? Should be able to lock phone but alarm should
    //keep going off. Should also be what you see on lock screen? Might be harder to do that.
    //https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/navigationpage
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/override
    //Might be it?

    //public override bool OnBackButtonPressed()
    //{
    //    return false;
    //}


    private async void OnButtonClicked(object sender, EventArgs e)
    {
        // Stop and cleanup MediaElement when we navigate away
        mediaElement.Handler?.DisconnectHandler();
        // Send user back to MainPage
        await Navigation.PopModalAsync();
    }
}