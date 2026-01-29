using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Exchange.Domain.Database.Entities;

public class TransactionEntity
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string FromCurrency { get; set; }

    public string ToCurrency { get; set; }

    public double Amount { get; set; }

    public string IDType { get; set; }

    public string IDNumber { get; set; }

    [ForeignKey("User")]
    public Guid UserId { get; set; }

    public virtual UserEntity User { get; set; }

    [ForeignKey("ExchangeRate")]
    public int ExchangeRateId { get; set; }

    public virtual ExchangeRateEntity ExchangeRate { get; set; }
}

