import { PaymentMethodModel } from '../../domain/models/payment-method.model';

export const mapPaymentMethodOptions = (
  paymentMethods: PaymentMethodModel[]
) => {
  return paymentMethods.map((pm) => ({
    label: pm.method === 'CASH' ? 'Sularaha' : 'Pangaülekanne',
    value: pm.id,
  }));
};
