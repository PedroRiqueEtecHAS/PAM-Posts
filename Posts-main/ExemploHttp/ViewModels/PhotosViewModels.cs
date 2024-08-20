using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHttp.Models;
using ExemploHttp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExemploHttp.ViewModels
{
    public partial class PhotosViewModels : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Photo> photos;

        public ICommand getPhotoCommand { get; }

        public PhotosViewModels()
        {
            getPhotoCommand = new Command(getPhotos);
        }

        public async void getPhotos()
        {
            RestServicePhoto photoService = new RestServicePhoto();
            Photos = await photoService.getPhotoAsync();
        }
    }
}

