export class PaymentMethodModel {
  public id: string;
  public method: string;

  constructor({ id, method }: { id: string; method: string }) {
    this.id = id;
    this.method = method;
  }
}
