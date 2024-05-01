using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2_NEW.Models;

public partial class Customer
{
    [Display]
    [Required(ErrorMessage = "Đây là trường bắt buộc!!!")]
    public string CustomerId { get; set; } = null!;

    public string? CustomerRealName { get; set; }

    public DateTime? CustomerDob { get; set; }

    public string? CustomerEmail { get; set; }

    [Display]
    [Required(ErrorMessage = "Đây là trường bắt buộc!!!")]
    public string CustomerPassword { get; set; } = null!;
}
