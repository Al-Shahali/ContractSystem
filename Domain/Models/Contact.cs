using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Contact
{
    /// <summary>
    /// Contact Code
    /// </summary>
    public int Concod { get; set; }

    /// <summary>
    /// Contact Name
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Contact Phone
    /// </summary>
    public string Phone { get; set; } = null!;

    /// <summary>
    /// Contact Address
    /// </summary>
    public string Address { get; set; } = null!;

    /// <summary>
    /// Contact Note
    /// </summary>
    public string? Note { get; set; }
}
