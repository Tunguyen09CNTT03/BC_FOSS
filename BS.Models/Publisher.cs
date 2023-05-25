namespace BS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Publisher")]
    public class Publisher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PubId { get; set; }

        [StringLength(50)]
        [DisplayName("Tên nhà xuất bản")]
        public string Name { get; set; }


        [StringLength(200)]
        [DisplayName("Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}