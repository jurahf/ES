using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace WebApi.Classes
{
    public static class EsFilesHelper
    {
        public static List<string> GetActualSystems()
        {
            string directory = HostingEnvironment.MapPath(@"~/App_Data/ActualESFiles"); // todo: в константу
            DirectoryInfo dirInfo = new DirectoryInfo(directory);
            return dirInfo.GetFiles().Select(x => x.Name).ToList();
        }

        public static string FindFullName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return null;

            string pattern = fileName.ToLower();
            if (!pattern.EndsWith(".es"))       // todo: в константу
                pattern += ".es";

            string directory = HostingEnvironment.MapPath(@"~/App_Data/ActualESFiles"); // todo: в константу
            DirectoryInfo dirInfo = new DirectoryInfo(directory);

            var fileInfo = dirInfo.GetFiles().FirstOrDefault(x => x.Name.ToLower() == pattern);
            return fileInfo?.FullName;
        }


    }
}