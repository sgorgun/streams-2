using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using static Streams.StreamsExtension;

namespace Streams.Tests
{
    [TestFixture]
    public class StreamsExtensionTests
    {
        private FilesInfo filesInfo;

        [OneTimeSetUp]
        public void SetUp()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            this.filesInfo = new FilesInfo();
            configuration.GetSection(nameof(FilesInfo)).Bind(this.filesInfo);
        }

        [Test]
        public void ByteCopyWithFileStreamTests()
        {
            ByteCopyWithFileStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.DestinationPath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void ByteCopyWithMemoryStreamTests()
        {
            ByteCopyWithMemoryStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.DestinationPath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void BlockCopyWithFileStreamTests()
        {
            BlockCopyWithFileStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.DestinationPath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void BlockCopyWithMemoryStreamTests()
        {
            BlockCopyWithMemoryStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.SourcePath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void BlockCopyWithBufferedStreamForFileStreamTests()
        {
            BlockCopyWithBufferedStreamForFileStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.DestinationPath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void BlockCopyWithBufferedStreamForMemoryStreamTests()
        {
            BlockCopyWithBufferedStreamForMemoryStream(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.SourcePath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void LineCopyTests()
        {
            LineCopy(this.filesInfo.SourcePath, this.filesInfo.DestinationPath);

            CheckFileIsClosed(this.filesInfo.SourcePath);
            CheckFileIsClosed(this.filesInfo.DestinationPath);

            Assert.IsTrue(AreEqualByLength(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByContent(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
            Assert.IsTrue(AreEqualByBytes(this.filesInfo.SourcePath, this.filesInfo.DestinationPath));
        }

        [Test]
        public void ReadEncodedText_ConvertTextUsingSpecifiedEncoding()
        {
            var expected =
                "Deutschland ist ein Bundesstaat in Mitteleuropa. Gemäß seiner Verfassung ist Deutschland eine föderal organisierte Republik, die aus den 16 deutschen Ländern gebildet wird. " +
                "Die Bundesrepublik Deutschland ist ein freiheitlich-demokratischer und sozialer Rechtsstaat und stellt die jüngste Ausprägung des deutschen Nationalstaates dar. Bundeshauptstadt ist Berlin." +
                "Neun europäische Nachbarstaaten grenzen an die Bundesrepublik, naturräumlich zudem im Norden die Gewässer der Nord- und Ostsee und im Süden das Bergland der Alpen. " +
                "Sie liegt in der gemäßigten Klimazone und zählt mit rund 82 Millionen Einwohnern zu den dicht besiedelten Flächenländern." +
                "Deutschland ist Gründungsmitglied der Europäischen Union sowie deren bevölkerungsreichstes Land und bildet mit 16 anderen EU-Mitgliedstaaten eine Währungsunion, die Eurozone. " +
                "Es ist Mitglied der Vereinten Nationen, der OECD, der NATO, der G8 und der G20." +
                "Gemessen am nominalen Bruttoinlandsprodukt ist Deutschland die größte Volkswirtschaft Europas und viertgrößte der Welt. " +
                "Im Jahr 2011 war es die drittgrößte Export- und Importnation.[10] Der Index für menschliche Entwicklung zählt Deutschland zu den sehr hoch entwickelten Staaten";

            var actual = ReadEncodedText(this.filesInfo.EncodedFileName, "ISO-8859-1");

            CheckFileIsClosed(this.filesInfo.EncodedFileName);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DecompressStream_ExtractDataCorrectly()
        {
            var testData = new Dictionary<string, DecompressionMethods>
            {
                { this.filesInfo.FileName, DecompressionMethods.None },
                { $"{this.filesInfo.FileName}.deflate", DecompressionMethods.Deflate },
                { $"{this.filesInfo.FileName}.gzip", DecompressionMethods.GZip },
                { $"{this.filesInfo.FileName}.brotli", DecompressionMethods.Brotli }
            };

            var expected = File.ReadAllBytes(this.filesInfo.FileName);

            foreach (var data in testData)
            {
                using (var stream = DecompressStream(data.Key, data.Value))
                {
                    using var memStream = new MemoryStream();
                    stream.CopyTo(memStream);
                    Assert.IsTrue(expected.SequenceEqual(memStream.ToArray()), $"DecompressStream failed for {data.Value}");
                }

                CheckFileIsClosed(data.Key);
            }
        }

        [Test]
        public void CalculateHash_ReturnValidHashValue()
        {
            var testData = new Dictionary<string, string>
            {
                { "MD5", "82E3C45273D90BC76489F194D1FA5CE1" },
                { "System.Security.Cryptography.MD5", "82E3C45273D90BC76489F194D1FA5CE1" },

                { "SHA", "30535A22D7995613F8613DA379ED0C89F8D7A280" },
                { "SHA1", "30535A22D7995613F8613DA379ED0C89F8D7A280" },
                { "System.Security.Cryptography.SHA1", "30535A22D7995613F8613DA379ED0C89F8D7A280" },

                { "SHA256", "62974B0251BA38179EE7D692A874694C67999B29EDC5CA068DA86626D160135F" },
                { "SHA-256", "62974B0251BA38179EE7D692A874694C67999B29EDC5CA068DA86626D160135F" },
                { "System.Security.Cryptography.SHA256", "62974B0251BA38179EE7D692A874694C67999B29EDC5CA068DA86626D160135F"
                },

                { "SHA384", "43ED7BCA7751DD7FFFF6D1BF528F917E75580A9CB0669A43AA01B943A30F2C36CAF672D8F42FD2EC7BD622FBE72F4D67" },
                { "SHA-384", "43ED7BCA7751DD7FFFF6D1BF528F917E75580A9CB0669A43AA01B943A30F2C36CAF672D8F42FD2EC7BD622FBE72F4D67" },
                { "System.Security.Cryptography.SHA384", "43ED7BCA7751DD7FFFF6D1BF528F917E75580A9CB0669A43AA01B943A30F2C36CAF672D8F42FD2EC7BD622FBE72F4D67"
                },

                { "SHA512", "6670401F8BE30A3EA179042C8F17773339EA0E0B7FAE671799D5460A6AE4BCC9A824C08317268B0A92A2A4846FD9D3D858297EAB63F549DE8154DE7A1557E8B2" },
                { "SHA-512", "6670401F8BE30A3EA179042C8F17773339EA0E0B7FAE671799D5460A6AE4BCC9A824C08317268B0A92A2A4846FD9D3D858297EAB63F549DE8154DE7A1557E8B2" },
                { "System.Security.Cryptography.SHA512", "6670401F8BE30A3EA179042C8F17773339EA0E0B7FAE671799D5460A6AE4BCC9A824C08317268B0A92A2A4846FD9D3D858297EAB63F549DE8154DE7A1557E8B2" }
            };

            using var stream = File.OpenRead(this.filesInfo.FileName);

            foreach (var data in testData)
            {
                stream.Position = 0;
                var actual = stream.CalculateHash(data.Key);
                var expected = data.Value;
                Assert.AreEqual(expected, actual, $"Error calculation hash {data.Key}");
            }
        }

        [Test]
        public void CalculateHash_AlgorithmIsNotSupported_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => Stream.Null.CalculateHash("Unrecognized!"));
        }

        private static bool AreEqualByLength(string source, string destination)
        {
            var sourceFileInfo = new FileInfo(source);
            var destinationFileInfo = new FileInfo(destination);
            return sourceFileInfo.Length.Equals(destinationFileInfo.Length);
        }

        private static bool AreEqualByContent(string sourceFile, string destinationFile)
        {
            using var sourceReader = new StreamReader(sourceFile, Encoding.UTF8);
            string source = sourceReader.ReadToEnd();

            using var destinationReader = new StreamReader(destinationFile, Encoding.UTF8);
            string destination = destinationReader.ReadToEnd();

            return source.Equals(destination, StringComparison.Ordinal);
        }

        private static bool AreEqualByBytes(string source, string destination)
        {
            using var firstStream = new FileStream(source, FileMode.Open);
            using var secondStream = new FileStream(destination, FileMode.Open);

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

        private static void CheckFileIsClosed(string fileName)
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
