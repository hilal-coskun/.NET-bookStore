using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Book : IEntity
    {

        public int ID { get; set; }
        //[Required]
        public int LanguageID { get; set; }
        //[Required]
        public int PaperTypeID { get; set; }
        //[Required]
        public int WriterID { get; set; }
        //[Required]
        public int BookPublisherID { get; set; }
        //[Required]
        public int BookTypeID { get; set; }
        //[Required]
        public int BookCategoryID { get; set; }
        //[Required]
        public int TranslatorID { get; set; }
        //[Required]
        public string Name { get; set; }
        //[Required]
        public decimal Price { get; set; }
        //[Required]
        public int PagesOfNumber { get; set; }
        //[Required]
        public string Blurb { get; set; }
        //[Required]
        public string ISBN { get; set; }
        //[Required]
        public int AmountOfStock { get; set; }
        //[Required]
        public string Size { get; set; }
        public System.DateTime RecordDate { get; set; }
    }
}
