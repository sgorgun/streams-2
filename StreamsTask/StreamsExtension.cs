using System;
using System.IO;

namespace AutocodeStreams
{
    // C# 8.0 in a Nutshell. Joseph Albahari, Eric Johannsen, Ben Albahari (previous editions). O'Reilly Media; April 2020
    // Chapter 15: Streams and I/O
    // http://www.albahari.com/nutshell/E8-CH15.aspx
    // C# 8.0 in a Nutshell. Joseph Albahari, Eric Johannsen, Ben Albahari (previous editions). O'Reilly Media; April 2020
    // Chapter 8: Framework Fundamentals - Text Encodings and Unicode. 
    // https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.1
    // https://docs.microsoft.com/en-us/dotnet/api/system.io?view=netcore-3.1

    public static class StreamsExtension
    {
        #region Public members
        
        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream.
        
        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.
        
        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            // TODO: step 1. Use StreamReader to read entire file in string
        
            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
        
            // TODO: step 3. Use MemoryStream instance to read from byte array (from step 2)
        
            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
        
            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
        
            // TODO: step 6. Use StreamWriter here to write char array content in new file
        
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region TODO: Implement by block copy logic using FileStream buffer.
        
        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            // TODO: Use Fil method's approach
            
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region TODO: Implement by block copy logic using MemoryStream.
        
        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            // TODO: Use InMemoryByByteCopy method's approach
            
            // TODO: step 1. Use StreamReader to read entire file in string
            
            // TODO: step 2. Create byte array on base string content - use  System.Text.Encoding class
            
            // TODO: step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            
            // TODO: step 5. Use Encoding class instance (from step 2) to create char array on byte array content
            
            // TODO: step 6. Use StreamWriter here to write char array content in new file
        
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region TODO: Implement by block copy logic using class-decorator BufferedStream.
        
        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            throw new NotImplementedException();
        }
        
        #endregion
        
        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter
        
        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
        
            throw new NotImplementedException();
        }
        
        #endregion
        
        #endregion

        #region Private members

        #region TODO: Implement validation logic

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

        #endregion

        #endregion
    }
}