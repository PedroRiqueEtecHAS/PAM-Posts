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
    public partial class PostsViewModels : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<Post> posts;

        public ICommand getPostCommand { get; }

        public PostsViewModels() 
        {
            getPostCommand = new Command(getPosts);
        }

        public async void getPosts()
        {
            RestService postService = new RestService();
            Posts = await postService.getPostAsync();
        }
    }
}
