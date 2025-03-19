﻿using ProjectCinema.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectCinema.BLL.DTO.Payment
{
    public class PaymentDTO
    {
        public int PaymentId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Decimal AmountPaid { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }
}
