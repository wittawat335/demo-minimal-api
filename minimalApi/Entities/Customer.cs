using System;
using System.Collections.Generic;

namespace minimalApi.Entities;

public partial class Customer
{
    public string CustCode { get; set; } = null!;

    public string CustName { get; set; } = null!;

    public string? CustCity { get; set; }

    public string WorkingArea { get; set; } = null!;

    public string CustCountry { get; set; } = null!;

    public int? Grade { get; set; }

    public decimal OpeningAmt { get; set; }

    public decimal ReceiveAmt { get; set; }

    public decimal PaymentAmt { get; set; }

    public decimal OutstandingAmt { get; set; }

    public string PhoneNo { get; set; } = null!;

    public string AgentCode { get; set; } = null!;
}
