using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IAS.Models
{
    [Table("Words")]
    [Index(nameof(Text), IsUnique = true)]
    public class WordsModel
	{
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("text")]
        [StringLength(200)]
        public string Text { get; set; }
    }
}

