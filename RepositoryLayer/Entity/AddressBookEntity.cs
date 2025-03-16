using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entity
{
    public class AddressBookEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, Phone, MaxLength(15)]
        public string PhoneNumber { get; set; }

        [EmailAddress, MaxLength(255)]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required]
        [ForeignKey("User")] 
        public int UserId { get; set; }

        // Navigation property
        public UserEntity User { get; set; }
    }
}
