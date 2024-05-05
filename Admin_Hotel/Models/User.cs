using System;
using System.Collections.Generic;

namespace Admin_Hotel.Models;

public partial class User
{
    public string UserName { get; set; } = null!;

    public string? Password { get; set; }

    public string? Avatar { get; set; }

    public string? Thumb { get; set; }

    public string? FullName { get; set; }

    public bool? IsAdmin { get; set; }
}
