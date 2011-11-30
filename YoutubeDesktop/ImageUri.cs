using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;

namespace YoutubeDesktop
{
    public class ImageUri
    {
        private Image _image = null;
        private Uri _uri = null;

        public ImageUri(Image image){
            _image = image;
        }

        public ImageUri(Uri uri){
            _uri = uri;
        }

        public static explicit operator Image(ImageUri obj){
            if (obj._image != null)
                return obj._image;

            try
            {
                using (Stream str = HttpWebRequest.Create(obj._uri).GetResponse().GetResponseStream())
                {
                    return (obj._image = Image.FromStream(str));
                }     
            }
            catch (Exception)
            {
                return null;
            }       
        }

    }
}
