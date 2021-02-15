using SFDA;
using SFDA.DTO;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using ICSharpCode.SharpZipLib.Zip;
//using Devart.Data.Oracle;

namespace SFDA.Extenstion
{
    public static class QueryExtenstion
    {
        public static List<FILE> GetUnCompressedFiles(byte[] data)
        {
            List<FILE> result = new List<FILE>();
            using (var inputStream = new MemoryStream(data))
            {
                using (var zipInputStream = new ZipInputStream(inputStream))
                {
                    ZipEntry entry;
                    var ContentText = "";
                    while ((entry = zipInputStream.GetNextEntry()) != null)
                    {
                        ContentText = "";
                        var currentStream = new MemoryStream();
                        var entryName = entry.Name;

                        zipInputStream.CopyTo(currentStream);
                        MemoryStream stream = new MemoryStream(currentStream.ToArray());
                        StreamReader reader = new StreamReader(stream);
                        ContentText = reader.ReadToEnd();
                        // ContentText = Regex.Replace(ContentText, @"\r\n", "");
                        result.Add(new FILE() { NAME = entryName, CONTENT = ContentText.ToString() });
                    }
                }
                return result;
            }
        }


    }
}
