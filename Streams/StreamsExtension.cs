using System;
using System.IO;
using System.Net;

namespace Streams
{
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

            throw new NotImplementedException();
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

            throw new NotImplementedException();
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

            // TODO: step 1. Use StreamReader to read entire file in string

            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class

            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)

            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array

            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content

            // TODO: step 6. Use StreamWriter here to write char array content in new file

            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements the logic of block copying the contents of the source text file using FileStream and class-decorator BufferedStream.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded bytes.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int BlockCopyWithBufferedStream(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            throw new NotImplementedException();
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

            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements the logic of line-by-line copying of the contents of the source text file
        /// using FileStream and classes-adapters  StreamReader/StreamWriter
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>The number of recorded lines.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or path to destination file are null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static int LineCopy(string? sourcePath, string? destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            throw new NotImplementedException();
        }

        /// <summary>
        /// Implements the logic of block copying from provided link.
        /// </summary>
        /// <param name="link">URI specified as string from which to copy.</param>
        /// <param name="destinationPath">Path to destination file.</param>
        /// <returns>Number of copied bytes.</returns>
        public static int DownloadByBlock(string? link, string? destinationPath)
        {
            //TODO: Use WebClient class

            throw new NotImplementedException();
        }

        /// <summary>
        /// Reads file content encoded with non Unicode encoding.
        /// </summary>
        /// <param name="sourcePath">Path to source file.</param>
        /// <param name="encoding">Encoding name.</param>
        /// <returns>Unicoded file content.</returns>
        /// <exception cref="ArgumentException">Throw if path to source file or encoding string is null or empty.</exception>
        /// <exception cref="FileNotFoundException">Throw if source file doesn't exist.</exception>
        public static string ReadEncodedText(string? sourcePath, string? encoding)
        {
            InputValidation(sourcePath);

            throw new NotImplementedException();
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

            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
