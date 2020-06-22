using System;
using System.IO;

namespace Streams
{

    public static class StreamsExtension
    {
        // TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using FileStream reader = new FileStream(sourcePath, FileMode.Open, FileAccess.Read);
            using FileStream writer = File.OpenWrite(destinationPath);

            long length = reader.Length;
            int buffer;
            int counter = 0;
            while (length-- != 0)
            {
                buffer = reader.ReadByte();
                if (buffer != -1)
                {
                    writer.WriteByte((byte)buffer);
                    counter++;
                }
            }

            return counter;
        }

        // TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using StreamReader reader = new StreamReader(sourcePath, Encoding.UTF8);
            string readedText = reader.ReadToEnd();
            byte[] sourceBuffer = Encoding.UTF8.GetBytes(readedText);
            MemoryStream source = new MemoryStream();
            foreach (var item in sourceBuffer)
            {
                source.WriteByte(item);
            }

            source.Seek(0, SeekOrigin.Begin);
            byte[] destinationBuffer = new byte[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                destinationBuffer[i] = (byte)source.ReadByte();
            }

            string result = Encoding.UTF8.GetString(destinationBuffer);
            using StreamWriter writer = new StreamWriter(destinationPath, false, Encoding.UTF8);
            writer.Write(result);
            return destinationBuffer.Length;
        }

        // TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var reader = File.OpenRead(sourcePath);
            using var writer = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);
            int bufferSize = 512;
            byte[] buffer = new byte[bufferSize];
            int bytesCountForRead = bufferSize;
            int reminder = (int)reader.Length;
            while (reminder != 0)
            {
                if (reminder < bytesCountForRead)
                {
                    bytesCountForRead = reminder;
                }
                reminder -= reader.Read(buffer, 0, bytesCountForRead);
                writer.Write(buffer, 0, bytesCountForRead);
            }

            return (int)writer.Length;
        }

        // TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using StreamReader reader = new StreamReader(sourcePath, Encoding.UTF8);
            string readedText = reader.ReadToEnd();

            byte[] sourceBuffer = Encoding.UTF8.GetBytes(readedText);
            int bufferSize = 512;
            byte[] buffer = new byte[bufferSize];
            using MemoryStream source = new MemoryStream();
            var builder = new StringBuilder();
            int bytesCountForRead = bufferSize;
            int reminder = (int)sourceBuffer.Length;
            int offset = 0;

            while (reminder != 0)
            {
                if (reminder < bytesCountForRead)
                {
                    bytesCountForRead = reminder;
                }

                source.Write(sourceBuffer, offset, bytesCountForRead);
                source.Position = 0;
                source.Read(buffer, 0, bytesCountForRead);
                builder.Append(Encoding.UTF8.GetChars(buffer, 0, bytesCountForRead));
                reminder -= bytesCountForRead;
                offset += bytesCountForRead;
                source.Position = 0;
            }

            string result = builder.ToString();
            using StreamWriter writer = new StreamWriter(destinationPath, false, Encoding.UTF8);
            writer.Write(result);
            return offset;
        }

        // TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            int bufferSize = 512;
            using var reader = File.OpenRead(sourcePath);
            using BufferedStream bufferedReader = new BufferedStream(reader, bufferSize);
            using var writer = File.OpenWrite(destinationPath);
            using BufferedStream bufferedWriter = new BufferedStream(writer, bufferSize);

            byte[] buffer = new byte[bufferSize];
            int bytesReadedCount = 0;
            int totalBytesCount = 0;
            do
            {
                bytesReadedCount = bufferedReader.Read(buffer, 0, bufferSize);
                bufferedWriter.Write(buffer, 0, bytesReadedCount);
                totalBytesCount += bytesReadedCount;
            } while (bytesReadedCount == buffer.Length);

            return totalBytesCount;
        }

        // TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var reader = new StreamReader(sourcePath, Encoding.UTF8);
            using var writer = new StreamWriter(destinationPath, false, Encoding.UTF8);
            int counter = 0;
            string result;
            writer.NewLine = "\u000A";//КОСТЫЛЬ!!!!

            do
            {
                result = reader.ReadLine();
                if (!reader.EndOfStream)
                {
                    writer.WriteLine(result);
                    counter++;
                }
                else
                {
                    writer.Write(result);
                    counter++;
                }
            }
            while (!reader.EndOfStream);

            return counter;
        }

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty", nameof(sourcePath));
            }

            if (string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} cannot be null or empty",
                    nameof(destinationPath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException(
                    $"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }
        }

    }
}