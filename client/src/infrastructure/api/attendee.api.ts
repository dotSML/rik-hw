import axios from "axios";
import { AttendeeModel } from "../../domain/models/attendee.model"

const apiUrl = import.meta.env.VITE_API_URL;

export const fetchEventAttendees = async (eventId: string) => {
    try {
        const response = await axios.get(`${apiUrl}/attendees/event/${eventId}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw new Error('Error fetching event attendees');
    }
};

export const fetchAttendeById = async (id: string) => {
    try {
        const response = await axios.get(`${apiUrl}/attendees/${id}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}

export const postAttendee = async (data: AttendeeModel) => {
    try {
        const response = await axios.post(`${apiUrl}/attendees`, AttendeeModel.toPlain(data));
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}

export const patchAttendee = async (id: string, data: Partial<AttendeeModel>) => {
    try {
        const response = await axios.patch(`${apiUrl}/attendees/${id}`, data);
        return response.data;
    } catch (e) {
        console.error(e)
        throw e;
    }
}

export const deleteAttendee = async (id: string) => {
    try {
        const response = await axios.delete(`${apiUrl}/attendees/${id}`);
        return response.data;
    } catch (e) {
        console.error(e);
        throw e;
    }
}