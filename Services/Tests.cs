using System;
using BenchmarkDotNet.Attributes;
using IAS.Services;

namespace IAS.Tests
{
    /// <summary>
    /// Benchmark test class
    /// </summary>
    [MemoryDiagnoser]
    [WarmupCount(5)]
    [IterationCount(20)]
    [StatisticalTestColumn]
    [LongRunJob]
    [MinColumn, MaxColumn]
    [KeepBenchmarkFiles]
    [AsciiDocExporter]
    public class Tests
	{
        private readonly IndexedSearcher _index;
        private readonly string[] _documentsSet;

        /// <summary>
        /// Params for enter words, you can change it
        /// </summary>
        [Params("word", "country", "test", "query", "param", "some", "to", "a")]
        public string Query { get; set; }



        /// <summary>
        /// Constructor needed for load dictionary and create index
        /// </summary>
        public Tests()
        {
            _documentsSet = DocumentExtractor.DocumentsSet("/Users/mac/desktop/data.txt").Take(10000).ToArray();
            _index = new();
            foreach (var item in _documentsSet)
                _index.AddStringToIndex(item);

        }



        /// <summary>
        /// Test with deafault searcher
        /// </summary>
        [Benchmark(Baseline = true)]
        public void SimpleSearch()
        {
            new Searcher().Search(Query, _documentsSet);
        }


        /// <summary>
        /// Test with indexed searcher
        /// </summary>
        [Benchmark]
        public void FullTextIndexSearch()
        {
            _index.Search(Query).ToArray();
        }
    }
}

