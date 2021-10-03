using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class PasswordCode : IEntity
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        [StringLength(6)]
        public string Code { get; set; }
    }
}
