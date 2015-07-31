using System.IO;

namespace Leanwork.CodePack
{
    public static  class StreamExtensions
    {
        public static Stream ToStream(this string value)
        {
            MemoryStream stream = new MemoryStream();

            StreamWriter writer = new StreamWriter(stream);

            writer.Write(value);
            writer.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}
