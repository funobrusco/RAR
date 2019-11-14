using System;
using System.IO;

namespace RAR.API.Utility
{
    public static class TruncateFilename
    {
        public static string Truncate(string filename,int length)
        {
            if (string.IsNullOrEmpty(filename)) throw new ArgumentNullException(nameof(filename));
            // save extension
            var extension = Path.GetExtension(filename);
            // remove extension here
            filename = Path.GetFileNameWithoutExtension(filename);

            var returnValue = filename;
            if (filename.Length <= length) return returnValue;
            var tmp = filename.Substring(0, length);
            // restore extension of file
            var retName = tmp + extension; //.Substring(0, tmp.LastIndexOf(' ')) + " ...";
            returnValue = retName;
            return returnValue;
        }

    }
}
