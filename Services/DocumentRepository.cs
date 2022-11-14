using System;
using System.Reflection.Metadata;
using IAS.DB.Context;
using IAS.Models;
using IAS.Services.Interfaces;

namespace IAS.Services
{
	public class DocumentRepository : IDocumentRepository
    {
        #region Services

        private readonly DbDocsContext _context;

        #endregion


        #region Constructors
        public DocumentRepository()
        {
        }

        public DocumentRepository(DbDocsContext context)
        {
            _context = context;
        }

        #endregion


        #region IDocumentRepository Implementation

        public void LoadDocuments()
        {
            using (var streamReader = new StreamReader(AppContext.BaseDirectory + "data.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    var doc = streamReader.ReadLine().Split('\t');

                    if (doc.Length > 1 && int.TryParse(doc[0], out int id))
                    {
                        _context.Documents.Add(new DocumentModel
                        {
                            Id = id,
                            Content = doc[1]
                        });

                        _context.SaveChanges();
                    }
                }
            }
        }

        #endregion
    }
}

