using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Entities.Concrete
{
    public class Author : IEntity
    {
        public int ID { get; set; }
        //[Required]
        public string Name { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        public DateTime RecordDate { get; set; }
        public Author()
        {
            RecordDate = DateTime.Now;
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]

        


        public List<Book> Book { get; set; }
    }
}
