using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Exchange.Domain.Database.Entities;

[Table("Role")]
public class RoleEntity : IdentityRole<Guid>
{
}
