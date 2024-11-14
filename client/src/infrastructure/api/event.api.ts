import axios from 'axios';

export const fetchEvents = async (params: URLSearchParams) => {
    try {
        const response = await axios.get('http://localhost:5220/api/events', {
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
        const response = await axios.get(`http://localhost:5220/api/events/${eventId}`);
        return response.data;
    } catch (error) {
        console.error(error)
        throw new Error('Error fetching events');
    }
}

export const postEvent = async (data: any) => {
    try {
        const response = await axios.post(`http://localhost:5220/api/events`, data);
        return response.data;
    } catch (e) {
        console.error(e);
        throw new Error('Error creating event')
    }
}

