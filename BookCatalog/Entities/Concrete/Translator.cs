using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Translator : IEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }

        [NotMapped]
        public IFormFile LogoFile { get; set; }

        public DateTime RecordDate { get; set; }
        public Translator()
        {
            RecordDate = DateTime.Now;
        }

        public List<Book> Book { get; set; }
    }
}
