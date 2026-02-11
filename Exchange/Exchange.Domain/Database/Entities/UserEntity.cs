using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Exchange.Domain.Database.Entities;

[Table("User")]
public class UserEntity : IdentityUser<Guid>
{
    public string FullName { get; set; }

    public DateTime RegisteredAtUtc { get; init; } = DateTime.UtcNow;

    public virtual ICollection<TransactionEntity> Transactions { get; set; }

}

