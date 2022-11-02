using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLib.Model
{
    internal static class PhotoManager // gets all the photos created for me
    {
        public static void GetAllPhotos(ObservableCollection<Photo> photos) //tracking changes constantly
        {
            var allPhotos = GetPhotos(); //allPhotos points at a list of photos, sounds is pointing to an empty
            photos.Clear();
            allPhotos.ForEach(photo => photos.Add(photo));
            
        }
        public static void GetAllPhotosByAlbum(ObservableCollection<Photo> photos,
            PhotoAlbum album)
        {
            var allPhotos =GetPhotos();
            photos.Clear();
            var filteredPhotos = allPhotos.Where(photo => photo.Album == album).ToList();
            filteredPhotos.ForEach(photo => photos.Add(photo));
        }
        private static List<Photo> GetPhotos() // a method 
        {
            var photos = new List<Photo>(); // use this class defined in Photo.cs as a type
            photos.Add(new Photo("kitten_1", PhotoAlbum.Album_1));
            photos.Add(new Photo("kitten_2", PhotoAlbum.Album_1));
            photos.Add(new Photo("puppy_1", PhotoAlbum.Album_2));
            photos.Add(new Photo("puppy_2", PhotoAlbum.Album_2));
            photos.Add(new Photo("bunny_1", PhotoAlbum.Album_3));
            photos.Add(new Photo("bunny_2", PhotoAlbum.Album_3));

            return photos;
        }
    }
}
