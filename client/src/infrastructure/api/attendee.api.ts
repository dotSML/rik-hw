import axios from "axios";

export const fetchEventAttendees = async (eventId: string) => {
    try {
        const response = await axios.get(`http://localhost:5220/api/attendees/event/${eventId}`);
        return response.data;
    } catch (error) {
        throw new Error('Error fetching event attendees');
    }
};