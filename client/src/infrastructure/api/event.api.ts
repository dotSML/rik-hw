import axios from 'axios';

const apiUrl = import.meta.env.VITE_API_URL;

export const fetchEvents = async (params: URLSearchParams) => {
    try {
        const response = await axios.get(`${apiUrl}/events`, {
            params: Object.fromEntries(params),
        });
        return response.data;
    } catch (error) {
        console.error(error);
        throw new Error('Error fetching events');
    }
};


export const fetchEvent = async (eventId: string) => {
    try {
        const response = await axios.get(`${apiUrl}/events/${eventId}`);
        return response.data;
    } catch (error) {
        console.error(error)
        throw new Error('Error fetching events');
    }
}

export const postEvent = async (data: any) => {
    try {
        const response = await axios.post(`${apiUrl}/events`, data);
        return response.data;
    } catch (e) {
        console.error(e);
        throw new Error('Error creating event')
    }
}

export const deleteEvent = async (id: string) => {
    try {
        const response = await axios.delete(`h${apiUrl}/events/${id}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw new Error('Error deleting event');
    }
}

