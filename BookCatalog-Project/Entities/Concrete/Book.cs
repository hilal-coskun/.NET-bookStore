using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {

        public int ID { get; set; }
        //[Required]
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        //[Required]
        public int PaperTypeID { get; set; }
        public PaperType PaperType { get; set; }
        //[Required]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
        //[Required]
        public int BookPublisherID { get; set; }
        public BookPublisher BookPublisher { get; set; }
        //[Required]
        public int BookTypeID { get; set; }
        public BookType BookType { get; set; }
        //[Required]
        public int BookCategoryID { get; set; }
        public BookCategory BookCategory { get; set; }
        //[Required]
        public int TranslatorID { get; set; }
        public Translator Translator { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public decimal Price { get; set; }
        //[Required]
        public string PagesOfNumber { get; set; }
        //[Required]
        public string Blurb { get; set; }
        //[Required]
        public int ISBN { get; set; }
        //[Required]
        public int AmountOfStock { get; set; }
        //[Required]
        public string Size { get; set; }

        public DateTime RecordDate { get; set; }
        public Book()
        {
            RecordDate = DateTime.Now;
        }

        public string Picture { get; set; }
        [NotMapped]
        public IFormFile PictureFile { get; set; }

        public List<Order> Order { get; set; }

    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
}
}
