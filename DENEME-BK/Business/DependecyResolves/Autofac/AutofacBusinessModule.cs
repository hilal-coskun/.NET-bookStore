using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependecyResolves.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookCategoryManager>().As<IBookCategoryService>();
            builder.RegisterType<EfBookCategoryDal>().As<IBookCategoryDal>();

            builder.RegisterType<BookManager>().As<IBookService>();
            builder.RegisterType<EfBookDal>().As<IBookDal>();

            builder.RegisterType<BookTypeManager>().As<IBookTypeService>();
            builder.RegisterType<EfBookTypeDal>().As<IBookTypeDal>();

            builder.RegisterType<AuthorManager>().As<IAuthorService>();
            builder.RegisterType<EfAuthorDal>().As<IAuthorDal>();

            builder.RegisterType<ContactManager>().As<IContactService>();
            builder.RegisterType<EfContactDal>().As<IContactDal>();

            builder.RegisterType<BookPublisherManager>().As<IBookPublisherService>();
            builder.RegisterType<EfBookPublisherDal>().As<IBookPublisherDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<TranslatorManager>().As<ITranslatorService>();
            builder.RegisterType<EfTranslatorDal>().As<ITranslatorDal>();

        }
    }
}
