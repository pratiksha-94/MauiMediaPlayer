
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Windows.Input;
using CommunityToolkit.Maui.Views;

#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using WinRT;
using Microsoft.Maui.Controls;
#endif

namespace MauiMediaPlayer;

public partial class MainPage : ContentPage
{
    private bool s_fullScreen;
    private ImageSource restore;
    string fscreen = "fullscreenexit.png";
    public MainPage(ShowVideoPageModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
    private void PlayButton_Clicked(object sender, EventArgs e)
    {
        mediaElement.Play();
    }

    private void PauseButton_Clicked(object sender, EventArgs e)
    {
        mediaElement.Pause();
    }

    private void StopButton_Clicked(object sender, EventArgs e)
    {
        mediaElement.Stop();

    }
#if WINDOWS
    /// <summary>
    /// Method is required for switching Full Screen Mode for Windows
    /// </summary>
    private static Microsoft.UI.Windowing.AppWindow GetAppWindow(MauiWinUIWindow window)
    {
        var handle = WinRT.Interop.WindowNative.GetWindowHandle(window);
        var id = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(handle);
        var appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(id);
        return appWindow;
    }

#endif
    private void StrechScreen_Clicked(object sender, EventArgs e)
    {

        if (s_fullScreen)
        {
            s_fullScreen = false;
            RestoreScreen();
            ((ImageButton)sender).Source = fscreen;
            // ((ImageButton)sender).Background=Color.Parse("#1E3054");  
        }
        else
        {
            if (restore == null)
                restore = ((ImageButton)sender).Source;
            FullScreen();
            ((ImageButton)sender).Source = restore;
            s_fullScreen = true;
            // ((ImageButton)sender).Background = Color.Parse("#1E3054");
        }

    }
    private void RestoreScreen()
    {
#if WINDOWS
        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;
        if (window is not null)
        {
            var appWindow = GetAppWindow(window);
            switch (appWindow.Presenter)
            {
                case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                    if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
                    {

                        overlappedPresenter.Restore();
                        //  ((VerticalStackLayout)((ImageButton)sender).Parent).IsVisible = true;

                    }
                    else
                    {
                        overlappedPresenter.Maximize();
                        //  ((VerticalStackLayout)((ImageButton)sender).Parent).IsVisible = false;
                    }
                    break;


            }
        }
#endif
    }
    private void FullScreen()
    {
#if WINDOWS
        var window = GetParentWindow().Handler.PlatformView as MauiWinUIWindow;
        if (window is not null)
        {
            var appWindow = GetAppWindow(window);
            switch (appWindow.Presenter)
            {
                case Microsoft.UI.Windowing.OverlappedPresenter overlappedPresenter:
                    if (overlappedPresenter.State == Microsoft.UI.Windowing.OverlappedPresenterState.Maximized)
                    {

                        overlappedPresenter.Restore();
                        //((VerticalStackLayout)((ImageButton)sender).Parent).IsVisible = true;

                    }
                    else
                    {
                        overlappedPresenter.Maximize();
                        // ((VerticalStackLayout)((ImageButton)sender).Parent).IsVisible = false;
                    }
                    break;


            }
        }
#endif
    }
    //private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    //{
    //    Toolbar.IsVisible = true;
    //}

    //private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    //{
    //    Toolbar.IsVisible= false;
    //}


}


