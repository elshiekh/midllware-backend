using ICSharpCode.SharpZipLib.Zip;
using SFDA_PRODUCTION.DTO;
using System.Collections.Generic;
using System.IO;

namespace SFDA_PRODUCTION.Extenstion
{
    public static class QueryExtenstion
    {
        public static List<FILE> GetUnCompressedFiles(byte[] data)
        {
            SaveData("FIRSTTRANSFERID", data);
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

        private static bool SaveData(string FileName, byte[] Data)
        {
            BinaryWriter Writer = null;
            string name = @"C:\wf\TRANSFER\" + FileName;

            try
            {
                // Create a new stream to write to the file
                Writer = new BinaryWriter(File.OpenWrite(name));

                // Writer raw data                
                Writer.Write(Data);
                Writer.Flush();
                Writer.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }


    }
}
