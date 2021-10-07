using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class BookPublisher : IEntity
    {
        //[Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int ContactID { get; set; }
        public Contact Contact { get; set; }
        public string About { get; set; }
       
        public DateTime RecordDate { get; set; }
        public BookPublisher()
        {
            RecordDate = DateTime.Now;
        }
        public List<Book> Book { get; set; }
    }
}
