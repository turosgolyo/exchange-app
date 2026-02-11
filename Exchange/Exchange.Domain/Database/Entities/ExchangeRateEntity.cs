using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Exchange.Domain.Database.Entities;

[Table("ExchangeRate")]
public class ExchangeRateEntity
{
    public int Id { get; set; }

    public DateTime ExchangeDate { get; set; }

    public double USDtoHUF { get; set; }

    public double GBPtoHUF { get; set; }

    public double CHFtoHUF { get; set; }

    public virtual ICollection<TransactionEntity> Transactions { get; set; }
}

