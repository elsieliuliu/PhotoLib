using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoLib.Model
{
    internal enum PhotoAlbum
    {
        Album_1,
        Album_2,
        Album_3
    }
    internal  enum  PhotoName
    {
        kitten_1,
        kitten_2,
        puppy_1,
        puppy_2,
        bunny_1,
        bunny_2
           
    }
    internal class Photo
    {
        public PhotoName Name { get; set; }

        public string ImageFile { get; set; }
        public string CoverFile { get; set; } 
        public PhotoAlbum Album { get; set; }
        

        public Photo(PhotoName name, PhotoAlbum album) //asigning parameters
        {
            Name = name;
            Album = album; 
            ImageFile = $"/Assets/Photos/{album}/{name}.jpg";
            CoverFile = $"/Assets/cover/{album}.jpg";
        }
    }
}
