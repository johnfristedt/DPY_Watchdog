using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace DPY2.WebAdmin.Helpers
{
    public class Utils
    {
        public static string SaveBase64Image(string Base64Image)
        {
            string fileName = "";

            if (String.IsNullOrEmpty(Base64Image))
                return fileName;

            int index = Base64Image.IndexOf(':') + 1,
                    length = Base64Image.IndexOf('/') - index;

            // Extract the datatype from the file header
            // We're only interested in data of type "image"
            string dataType = Base64Image.Substring(index, length);

            if (dataType != "image")
                return fileName;

            index = Base64Image.IndexOf('/') + 1;
            length = Base64Image.IndexOf(';') - index;

            // Extract file type from file header
            // Expected results include "jpeg", "png" etc.
            string fileType = Base64Image.Substring(index, length);

            // Separate the base64 string and the header, separated by a comma
            string base64string = Base64Image.Substring(Base64Image.LastIndexOf(',') + 1);

            fileName = String.Format("{0}.{1}",
                                            Guid.NewGuid().ToString(),
                                            fileType);

            File.WriteAllBytes(AppDomain.CurrentDomain.BaseDirectory + "Uploads\\Images\\" + fileName, Convert.FromBase64String(base64string));

            return fileName;
        }
    }
}