using System;
using System.Collections.Generic;

namespace minimalApi.Entities;

public partial class Order
{
    public decimal OrdNum { get; set; }

    public decimal OrdAmount { get; set; }

    public decimal AdvanceAmount { get; set; }

    public DateOnly OrdDate { get; set; }

    public string CustCode { get; set; } = null!;

    public string AgentCode { get; set; } = null!;

    public string OrdDescription { get; set; } = null!;
}
