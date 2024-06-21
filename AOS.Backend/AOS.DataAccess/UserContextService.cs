using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOS.DataAccess;
public interface IUserContextService
{
    string UserId { get; set; }
    bool IsAuthenticated { get; set; }
}

public class UserContextService : IUserContextService
{
    public string UserId { get; set; } = "system";
    public bool IsAuthenticated { get; set; } = false;
}