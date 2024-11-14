import { fetchPaymentMethods } from "../../infrastructure/api/payment-method.api";

export const getPaymentMethods = async () => {
    const data = await fetchPaymentMethods();

    return data;
}