using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Leanwork.CodePack.Utilities
{
    public class ReduceImage
    {
        public void Reduce(Stream file, string pathSource, long quality = 50)
        {
            // Create a Bitmap object based on a BMP file.
            using (Bitmap myBitmap = new Bitmap(file))
            {
                SavePathSource(pathSource, quality, myBitmap);
            }
        }

        public void Reduce(string fileName, string pathSource, long quality = 50)
        {
            // Create a Bitmap object based on a BMP file.
            using (Bitmap myBitmap = new Bitmap(fileName))
            {
                SavePathSource(pathSource, quality, myBitmap);
            }
        }

        public Bitmap Reduce(Stream stream, long quality = 50)
        {
            // Create a Bitmap object based on a BMP file.
            using (Bitmap myBitmap = new Bitmap(stream))
            {
                return SaveInMemory(stream, quality, myBitmap);
            }
        }

        Bitmap SaveInMemory(Stream stream, long quality, Bitmap myBitmap)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            myEncoder = Encoder.Quality;

            // EncoderParameter object in the array.
            using (myEncoderParameters = new EncoderParameters(1))
            {
                // Save the bitmap as a JPEG file with quality level.            
                myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                myBitmap.Save(stream, myImageCodecInfo, myEncoderParameters);
            }

            return myBitmap;
        }

        void SavePathSource(string pathSource, long quality, Bitmap myBitmap)
        {
            ImageCodecInfo myImageCodecInfo;
            Encoder myEncoder;
            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;

            // Get an ImageCodecInfo object that represents the JPEG codec.
            myImageCodecInfo = GetEncoderInfo("image/jpeg");

            // Create an Encoder object based on the GUID
            // for the Quality parameter category.
            myEncoder = Encoder.Quality;

            // EncoderParameter object in the array.
            using (myEncoderParameters = new EncoderParameters(1))
            {
                // Save the bitmap as a JPEG file with quality level.            
                myEncoderParameter = new EncoderParameter(myEncoder, quality);
                myEncoderParameters.Param[0] = myEncoderParameter;
                myBitmap.Save(pathSource, myImageCodecInfo, myEncoderParameters);
            }
        }

        ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            for (int j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                {
                    return encoders[j];
                }
            }

            return null;
        }
    }
}
