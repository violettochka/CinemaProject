﻿using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCinema.Entities
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }
        [Required]
        public Decimal TotalPrice { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public BookingStatus BookingStatus { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public int UserId { get; set; }
        [ForeignKey("PeymentId")]
        public Payment Payment { get; set; }
        [Required]
        public int PaymentId { get; set; }
        [ForeignKey("PromocodeId")]
        public Promocode Promocode { get; set; }
        [Required]
        public int PromocodeId { get; set; }
        public ICollection<Ticket>? Tickets { get; set; }
    }
}
