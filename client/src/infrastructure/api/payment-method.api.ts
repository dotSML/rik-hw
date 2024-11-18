import axios from "axios";

const apiUrl = import.meta.env.VITE_API_URL;

export const fetchPaymentMethods = async () => {
    const response = await axios.get(`${apiUrl}/payment-methods`)
    return response.data;
}