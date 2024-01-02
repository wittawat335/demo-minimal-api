using System;
using System.Collections.Generic;

namespace minimalApi.Entities;

public partial class Agent
{
    public string AgentCode { get; set; } = null!;

    public string? AgentName { get; set; }

    public string? WorkingArea { get; set; }

    public decimal? Commission { get; set; }

    public string? PhoneNo { get; set; }

    public string? Country { get; set; }
}
