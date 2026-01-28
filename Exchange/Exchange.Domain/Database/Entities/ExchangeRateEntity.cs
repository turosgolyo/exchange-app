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

    public string USDtoHUF { get; set; }

    public string GBPtoHUF { get; set; }

    public string CHFtoHUF { get; set; }

    public virtual ICollection<TransactionEntity> Transactions { get; set; }
}

