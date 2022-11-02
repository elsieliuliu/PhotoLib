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
    internal class Photo
    {
        public string Name { get; set; }
        public string ImageFile { get; set; }
        public string CoverFile { get; set; } 
        public PhotoAlbum Album { get; set; }

        public Photo(string name, PhotoAlbum album) //asigning parameters
        {
            Name = name;
            Album = album;
            ImageFile = $"/Assets/Photos/{album}/{name}.jpg";
            CoverFile = $"/Assets/cover/{album}.jpg";
        }
    }
}
