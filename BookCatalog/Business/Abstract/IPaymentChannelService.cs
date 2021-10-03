using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPaymentChannelService
    {
        List<PaymentChannel> GetAll();
        List<PaymentChannel> GetList();
        PaymentChannel GetById(int paymentChannelId);
        List<PaymentChannel> GetListCategory(int paymentChannelId);
        void Add(PaymentChannel paymentChannel);
        void Delete(PaymentChannel paymentChannel);
        void Update(PaymentChannel paymentChannel);
    }
}
