using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAS.Models
{
    [Table("Documents")]
    public class DocumentModel
	{
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Column("content")]
        [StringLength(int.MaxValue)]
        public string Content { get; set; }
    }
}

