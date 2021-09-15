using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Contact : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string IsCorporation { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
    }
}
