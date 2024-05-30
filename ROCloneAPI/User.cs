using System;
using System.Collections.Generic;

namespace ROCloneAPI;

public partial class User
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Lname { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Pw { get; set; } = null!;

    public DateOnly? Dob { get; set; }
}
