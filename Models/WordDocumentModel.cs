using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;

namespace IAS.Models
{
    [Table("WordDocuments")]
    [Index(nameof(WordId))]
    [Index(nameof(WordId), nameof(DocumentId), IsUnique = true)]
    public class WordDocumentModel
	{
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("wordid")]
        [ForeignKey(nameof(Word))]
        public int WordId { get; set; }

        [Column("documentid")]
        [ForeignKey(nameof(Document))]
        public int DocumentId { get; set; }

        public virtual DocumentModel Document { get; set; }

        public virtual WordsModel Word { get; set; }
    }
}

