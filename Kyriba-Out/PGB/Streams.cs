using System.IO;

namespace Kyriba_Out.PGB
{
    public class Streams
    {
        private const int BufferSize = 512;

        public static void PipeAll(Stream inStr, Stream outStr)
        {
            byte[] bs = new byte[BufferSize];
            int numRead;
            while ((numRead = inStr.Read(bs, 0, bs.Length)) > 0)
            {
                outStr.Write(bs, 0, numRead);
            }
        }
    }
}
