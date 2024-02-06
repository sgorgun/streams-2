using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Streams
{
    /// <summary>
    /// Class for training streams and operations with it.
    /// </summary>
    public static class StreamsExtension
    {
        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using class FileStream as a backing store stream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = File.OpenRead(sourcePath!);
            using var destinationStream = File.Create(destinationPath!);
            sourceStream.CopyTo(destinationStream);
            return (int)sourceStream.Length;
        }

        /// <summary>
        /// Implements the logic of byte copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int ByteCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] sourceData = File.ReadAllBytes(sourcePath!);
            File.WriteAllBytes(destinationPath!, sourceData);
            return sourceData.Length;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream buffer.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithFileStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = new FileStream(sourcePath!, FileMode.Open, FileAccess.Read);
            using var destinationStream = new FileStream(destinationPath!, FileMode.Create, FileAccess.Write);
            sourceStream.CopyTo(destinationStream, 8192);
            return (int)sourceStream.Length;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithMemoryStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = new FileStream(sourcePath!, FileMode.Open, FileAccess.Read);
            using var destinationStream = new FileStream(destinationPath!, FileMode.Create, FileAccess.Write);
            sourceStream.CopyTo(destinationStream);
            return (int)sourceStream.Length;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForFileStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = File.OpenRead(sourcePath);
            using var destinationStream = File.Create(destinationPath);
            using var bufferedSourceStream = new BufferedStream(sourceStream);
            using var bufferedDestinationStream = new BufferedStream(destinationStream);
            bufferedSourceStream.CopyTo(bufferedDestinationStream);
            bufferedDestinationStream.Flush();
            return (int)sourceStream.Length;
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using MemoryStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStreamForMemoryStream(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = new BufferedStream(File.OpenRead(sourcePath));
            using var destinationStream = new BufferedStream(File.Create(destinationPath));
            sourceStream.CopyTo(destinationStream);
            return (int)sourceStream.Length;
        }

        /// <summary>
        /// Implements the logic of line-by-line copying of the contents of the source text file
        /// using FileStream and classes-adapters  StreamReader/StreamWriter.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded lines.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file are null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int LineCopy(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            using var sourceStream = new FileStream(sourcePath!, FileMode.Open);
            using var destinationStream = new FileStream(destinationPath!, FileMode.Open);
            using var source = new StreamReader(sourceStream);
            using var destination = new StreamWriter(destinationStream, Encoding.UTF8);
            int count = 0;
            string? line;
            while ((line = source.ReadLine()) != null)
            {
                if (source.EndOfStream)
                {
                    break;
                }

                destination.WriteLine(line);
                count++;
            }

            return count;
        }

        /// <summary>
        /// Reads file content encoded with non Unicode encoding.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="encoding">Encoding name.</param>
        /// <returns>Uncoding file content.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or encoding string is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static string ReadEncodedText(string? sourcePath, string? encoding)
        {
            InputValidation(sourcePath, encoding);
            return File.ReadAllText(sourcePath!, Encoding.GetEncoding(encoding!));
        }

        /// <summary>
        /// Returns decompressed stream from file.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="method">Method used for compression (none, deflate, gzip).</param>
        /// <returns>Output stream.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static Stream DecompressStream(string? sourcePath, DecompressionMethods? method)
        {
            InputValidation(sourcePath);
            var sourceStream = File.OpenRead(sourcePath!);
            return method switch
            {
                DecompressionMethods.Deflate => new DeflateStream(sourceStream, CompressionMode.Decompress),
                DecompressionMethods.GZip => new GZipStream(sourceStream, CompressionMode.Decompress),
                DecompressionMethods.Brotli => new BrotliStream(sourceStream, CompressionMode.Decompress),
                _ => sourceStream,
            };
        }

        /// <summary>
        /// Calculates hash of stream using specified algorithm.
        /// </summary>
        /// <param name="stream">Source stream.</param>
        /// <param name="hashAlgorithmName">
        ///     Hash algorithm ("MD5","SHA1","SHA256" and other supported by .NET).
        /// </param>
        /// <returns>Hash.</returns>
        public static string CalculateHash(this Stream? stream, string? hashAlgorithmName)
        {
            if (stream == null || string.IsNullOrWhiteSpace(hashAlgorithmName))
            {
                throw new ArgumentException("Stream and hash algorithm name cannot be null or empty.");
            }

            using var algorithm = HashAlgorithm.Create(hashAlgorithmName)
                                 ?? throw new ArgumentException($"Unsupported hash algorithm: {hashAlgorithmName}.");

            var hashBytes = algorithm.ComputeHash(stream);
            return BitConverter.ToString(hashBytes).Replace("-", string.Empty, StringComparison.Ordinal);
        }

        private static void InputValidation(string? sourcePath, string? destinationPath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }

            if (string.IsNullOrWhiteSpace(destinationPath))
            {
                throw new ArgumentException($"{nameof(destinationPath)} cannot be null or empty or whitespace", nameof(destinationPath));
            }
        }

        private static void InputValidation(string? sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} cannot be null or empty or whitespace.", nameof(sourcePath));
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"File '{sourcePath}' not found. Parameter name: {nameof(sourcePath)}.");
            }
        }
    }
}
