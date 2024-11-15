import axios from "axios";
import { AttendeeModel } from "../../domain/models/attendee.model";

export const fetchEventAttendees = async (eventId: string) => {
    try {
        const response = await axios.get(`http://localhost:5220/api/attendees/event/${eventId}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw new Error('Error fetching event attendees');
    }
};

export const fetchAttendeById = async (id: string) => {
    try {
        const response = await axios.get(`http://localhost:5220/api/attendees/${id}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}

export const postAttendee = async (data: AttendeeModel) => {
    try {
        const response = await axios.post(`http://localhost:5220/api/attendees`, data);
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}

export const patchAttendee = async (id: string, data: Partial<AttendeeModel>) => {
    try {
        const response = await axios.patch(`http://locahost:5220/api/attendees/${id}`, data);
        return response.data;
    } catch (e) {
        console.error(e)
        throw e;
    }
}