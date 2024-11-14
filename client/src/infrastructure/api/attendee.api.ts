import axios from "axios";
import { AttendeeModel } from "../../domain/models/attendee.model";

export const fetchEventAttendees = async (eventId: string) => {
    try {
        const response = await axios.get(`http://localhost:5220/api/attendees/event/${eventId}`);
        return response.data;
    } catch (error) {
        throw new Error('Error fetching event attendees');
    }
};

export const postAttendee = async (data: AttendeeModel) => {
    try {
        const response = await axios.post(`http://localhost:5220/api/attendees`, data);
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}