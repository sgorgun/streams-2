# Task Description

- Add implementations to static methods of the class [StreamsExtension](https://gitlab.com/AnzhelikaKravchuk/streams/-/blob/master/Streams/StreamsExtension.cs). 
    - ByteCopyWithFileStream
    - BlockCopyWithFileStream
    - BlockCopyWithBufferedStream
    - LineCopy   
    - ReadEncodedText
    - DecompressStream
    - CalculateHash    
The task detail definitions are given in the XML-comments for the methods.
- Build a solution in Visual Studio. Make sure there are no compiler errors and warnings, fix these issues and rebuild the solution.
- Run all unit tests with Visual Studio and make sure there are no failed unit tests. Fix your code to make all tests GREEN.
- Review all your changes in the codebase before staging the changes and creating a commit.
- Stage your changes, create a commit and publish your changes to the remote repository.

## See also
- C# Guide. Microsoft Documentation
    - [using statement](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/using-statement)
- .NET API. Microsoft Documentation
    - [FileStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=netcore-3.1)
    - [MemoryStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.memorystream?view=netcore-3.1)
    - [BufferedStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.bufferedstream?view=netcore-3.1)
    - [StreamReader Clas](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-3.1)
    - [StreamWriter](https://docs.microsoft.com/en-us/dotnet/api/system.io.streamwriter?view=netcore-3.1)
    - [Encoding Class](https://docs.microsoft.com/en-us/dotnet/api/system.text.encoding?view=netcore-3.1)
    - [DeflateStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.compression.deflatestream?view=netcore-3.1)
    - [GZipStream Class](https://docs.microsoft.com/en-us/dotnet/api/system.io.compression.gzipstream?view=netcore-3.1)
    - [HashAlgorithm Class](https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.hashalgorithm?view=netcore-3.1)