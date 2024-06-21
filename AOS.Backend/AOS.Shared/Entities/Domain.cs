using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.Shared.Entities;
public class Domain : BaseEntity
{
    public int Id { get; set; }
    public required string Name { get; set; } 
    public string? Description { get; set; }
    public bool Deleted { get; set; }
    public bool Draft { get; set; }
}
