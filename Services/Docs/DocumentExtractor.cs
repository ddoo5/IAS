using System;
using IAS.Services.Interfaces;

namespace IAS.Services
{
	public class DocumentExtractor
    {
        public static IEnumerable<string> DocumentsSet(string path)
        {
            return ReadDocuments(path);
        }


        private static IEnumerable<string> ReadDocuments(string fileName)
        {
            using (var streamReader = new StreamReader(fileName))
                while (!streamReader.EndOfStream)
                {
                    var doc = streamReader.ReadLine()?.Split('\t');
                    yield return doc[1];
                }
        }
    }
}

