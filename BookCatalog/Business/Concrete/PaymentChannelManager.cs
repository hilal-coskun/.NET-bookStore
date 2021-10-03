using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentChannelManager :IPaymentChannelService
    {
        private IPaymentChannelDal _paymentChannelDal;

        public PaymentChannelManager(IPaymentChannelDal paymentChannelDal)
        {
            _paymentChannelDal = paymentChannelDal;
        }


        public PaymentChannel GetById(int paymentChannelId)
        {
            return _paymentChannelDal.Get(p => p.ID == paymentChannelId);
        }

        public PaymentChannel GetByID(int? paymentChannelId)
        {
            return _paymentChannelDal.Get(p => p.ID == paymentChannelId);
        }

        public List<PaymentChannel> GetAll()
        {
            return _paymentChannelDal.GetList().ToList();
        }

        public PaymentChannel GetByID(int paymentChannelId)
        {
            return _paymentChannelDal.Get(p => p.ID == paymentChannelId);
        }

        public List<PaymentChannel> GetList()
        {
            return _paymentChannelDal.GetList().ToList();
        }

        public List<PaymentChannel> GetListCategory(int paymentChannelId)
        {
            return _paymentChannelDal.GetList(b => b.ID == paymentChannelId).ToList();
        }

        public void Add(PaymentChannel paymentChannel)
        {
            //business code
            _paymentChannelDal.Add(paymentChannel);
        }

        public void Delete(PaymentChannel paymentChannel)
        {
            _paymentChannelDal.Delete(paymentChannel);
        }

        public void Update(PaymentChannel paymentChannel)
        {
            _paymentChannelDal.Update(paymentChannel);
        }
    }
}
