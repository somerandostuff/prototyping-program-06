using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Assignment_2_NEW.Models;

public partial class Admin
{
    [Display]
    [Required(ErrorMessage = "Đây là trường bắt buộc!!!")]
    public string AdminId { get; set; } = null!;

    public string? AdminRealName { get; set; }

    public DateTime? AdminDob { get; set; }

    public string? AdminEmail { get; set; }

    [Display]
    [Required(ErrorMessage = "Đây là trường bắt buộc!!!")]
    public string AdminPassword { get; set; } = null!;
}
