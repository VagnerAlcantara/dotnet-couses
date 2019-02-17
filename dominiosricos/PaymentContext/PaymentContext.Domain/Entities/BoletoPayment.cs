using System;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode,
            string boletoNumber,
            DateTime paidDate,
             DateTime expireDate,
              decimal total,
               decimal totalPaid,
                string payer,
                Address address,
                 string owner,
                  Document document,
                   Email email)
        : base(paidDate, expireDate, total, totalPaid, payer, address, owner, document, email)
        {
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }
        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
