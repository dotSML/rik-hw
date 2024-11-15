import { AttendeeModel } from "../../domain/models/attendee.model";
import { fetchAttendeById } from "../../infrastructure/api/attendee.api"

export const getAttendeeById = async (id: string) => {
    const data = await fetchAttendeById(id);
    return new AttendeeModel(data);
}