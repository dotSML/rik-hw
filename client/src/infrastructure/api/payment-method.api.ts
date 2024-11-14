import axios from "axios";

export const fetchPaymentMethods = async () => {
    const response = await axios.get(`http://localhost:5220/api/payment-methods`)
    return response.data;
}