using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Domain.Common.Interfaces
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
