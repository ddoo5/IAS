using System;
using System.Diagnostics.Metrics;
using IAS.DB.Context;
using IAS.Models;

namespace IAS.Services
{
	public class Indexing
	{
        private readonly DbDocsContext _context;
        private readonly Selector _lexer = new();


        public Indexing(DbDocsContext context = null)
        {
            _context = context;
        }


        public void BuildIndex()
        {
            foreach (var document in _context.Documents.ToArray())
            {
                foreach (var token in _lexer.GetTokens(document.Content))
                {
                    var word = _context.Words.FirstOrDefault(w => w.Text == token);
                    int wordId = 0;
                    if (word == null)
                    {
                        var wordObj = new WordsModel
                        {
                            Text = token
                        };
                        _context.Words.Add(wordObj);
                        _context.SaveChanges();
                        wordId = wordObj.Id;
                    }
                    else
                        wordId = word.Id;

                    var wordDocument = _context.WordDocuments.FirstOrDefault(wd => wd.WordId == wordId && wd.DocumentId == document.Id);
                    if (wordDocument == null)
                    {
                        _context.WordDocuments.Add(new WordDocumentModel
                        {
                            DocumentId = document.Id,
                            WordId = wordId
                        });

                        if (wordId % 1000 == Math.Truncate(Convert.ToDouble(wordId % 1000)))
                            UI.UI.MessageAboutIndexing(wordId);

                        _context.SaveChanges();
                    }
                }
            }
        }
    }
}

