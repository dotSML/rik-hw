import { AttendeeModel } from '../../domain/models/attendee.model';
import { fetchEventAttendees } from '../../infrastructure/api/attendee.api';

export const getEventAttendees = async (eventId: string) => {
  const attendeeData = await fetchEventAttendees(eventId);
  return attendeeData.map((data) => new AttendeeModel(data));
};
