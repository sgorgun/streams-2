using System.IO;
using System.Text;
using NUnit.Framework;

namespace Streams.Tests
{
    [TestFixture]
    public class StreamsExtensionTests
    {
        private const string sourcePath = @"SourceText.txt";
        private const string destinationPath = @"DestinationText.txt";
        
        [Test]
        public void ByByteCopyTests()
        {
            StreamsExtension.ByByteCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }

        [Test]
        public void InMemoryByByteCopyTests()
        {
            StreamsExtension.InMemoryByByteCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }
        
        [Test]
        public void ByBlockCopyTests()
        {
            StreamsExtension.ByBlockCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }

        [Test]
        public void InMemoryByBlockCopyTests()
        {
            StreamsExtension.InMemoryByBlockCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }
        
        [Test]
        public void BufferedCopyTests()
        {
            StreamsExtension.BufferedCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }
        
        [Test]
        public void ByLineCopyTests()
        {
            StreamsExtension.ByLineCopy(sourcePath, destinationPath);

            Assert.IsTrue(AreEqualByLength(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByContent(sourcePath, destinationPath));
            Assert.IsTrue(AreEqualByBytes(sourcePath,destinationPath));

            CheckFileIsClosed(sourcePath);
            CheckFileIsClosed(destinationPath);
        }
        
        private bool AreEqualByLength(string sourcePath, string destinationPath)
        {
            FileInfo sourceFileInfo = new FileInfo(sourcePath);
            FileInfo destinationFileInfo = new FileInfo(destinationPath);

            return sourceFileInfo.Length.Equals(destinationFileInfo.Length);
        }
        private bool AreEqualByContent(string sourceFile, string destinationFile)
        {
            using TextReader sourceReader = new StreamReader(sourceFile, Encoding.UTF8);
            string source = sourceReader.ReadToEnd();
            
            using TextReader destinationReader = new StreamReader(destinationFile, Encoding.UTF8);
            string destination = destinationReader.ReadToEnd();

            return source.Equals(destination);
        }
        private bool AreEqualByBytes(string sourcePath, string destinationPath)
        {
            using FileStream firstStream = new FileStream(sourcePath, FileMode.Open);
            using FileStream secondStream = new FileStream(destinationPath, FileMode.Open);
            
            int nextByte;

            while ((nextByte = firstStream.ReadByte()) > -1)
            {
                if (nextByte != secondStream.ReadByte())
                {
                    return false;
                }
            }

            return secondStream.ReadByte() == -1;
        }
        private void CheckFileIsClosed(string fileName)
        {
            try
            {
                using var stream = File.Open(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                Assert.Fail("Source stream is not closed! Please use 'using' statement.");
            }
        }
    }
}