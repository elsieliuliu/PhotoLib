using PhotoLib.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PhotoLib
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Photo> photos;
        private ObservableCollection<Photo> photos2;
        private ObservableCollection<MenuItem> menuItems; //needs it to be able to change
        public MainPage() //constructor, mainpage.xaml is a blueprint of the UI
        {
            this.InitializeComponent();
            photos = new ObservableCollection<Photo>();
            PhotoManager.GetAllPhotos(photos);

            photos2 = new ObservableCollection<Photo>();
            PhotoManager.GetAllPhotos(photos2);

            menuItems = new ObservableCollection<MenuItem>();
            menuItems.Add(new MenuItem
            {
                CoverFile = "Assets/cover/album_1.jpg",
                Album = PhotoAlbum.Album_1

            });
            menuItems.Add(new MenuItem
            {
                CoverFile = "Assets/cover/album_2.jpg",
                Album = PhotoAlbum.Album_2

            });
            menuItems.Add(new MenuItem
            {
                CoverFile = "Assets/cover/album_3.jpg",
                Album = PhotoAlbum.Album_3

            });
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            ContentSplitView.IsPaneOpen = !ContentSplitView.IsPaneOpen;

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoManager.GetAllPhotos(photos);
            AlbumTextBlock.Text = "All Photos";
            BackButton.Visibility = Visibility.Collapsed;
            MenuItemListView.SelectedItem = null;
            AddButton.Visibility = Visibility.Visible;
            OnePhotoGridView.Visibility = Visibility.Collapsed;
            PhotoTextBlock.Visibility = Visibility.Collapsed;
            PhotoGridView.Visibility = Visibility.Visible;
        }

        private void PhotoGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
             PhotoGridView.Visibility = Visibility.Collapsed;
            var photo = (Photo)e.ClickedItem;
            PhotoManager.GetOnePhotoByClick(photos2, photo.Name);
            OnePhotoGridView.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Collapsed;
            PhotoTextBlock.Visibility = Visibility.Visible;
            PhotoTextBlock.Text = photo.Name.ToString();
            AlbumTextBlock.Visibility = Visibility.Collapsed;
        }

        private void MenuItemListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;
            AlbumTextBlock.Text = menuItem.Album.ToString();
            PhotoManager.GetAllPhotosByAlbum(photos, menuItem.Album);
            BackButton.Visibility = Visibility.Visible;
            AddButton.Visibility = Visibility.Collapsed;
        }

        private void OnePhotoGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            PhotoGridView.Visibility = Visibility.Visible;
            OnePhotoGridView.Visibility = Visibility.Collapsed;
            PhotoTextBlock.Visibility= Visibility.Collapsed;
            AlbumTextBlock.Visibility = Visibility.Visible;
            

        }
    }
}
