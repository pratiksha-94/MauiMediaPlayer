using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiMediaPlayer
{
    public partial class ShowVideoPageModel : ObservableObject
    {
        public ICommand TapCommand { get; }
        public ICommand TapVolumeCommand { get; }
        public ShowVideoPageModel()
        {
            TapCommand = new RelayCommand<object>(TapCommandImpl);
            TapVolumeCommand = new RelayCommand<object>(TapVolumeCommandImpl);
        }
        [RelayCommand]
        public void TapCommandImpl(object obj)
        {
            VerticalStackLayout toolbar = obj as VerticalStackLayout;
            if (toolbar.IsVisible)
            {
                toolbar.IsVisible = false;
            }
            else
            {
                toolbar.IsVisible = true;
            }
        }
        [RelayCommand]
        public void TapVolumeCommandImpl(object obj)
        {
            VerticalStackLayout volumecontrol = obj as VerticalStackLayout;
            if (volumecontrol.IsVisible)
            {
                volumecontrol.IsVisible = false;
            }
            else
            {
                volumecontrol.IsVisible = true;
            }
        }
    }
}
