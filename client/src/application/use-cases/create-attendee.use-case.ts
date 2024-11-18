import { AttendeeModel } from '../../domain/models/attendee.model';
import { postAttendee } from '../../infrastructure/api/attendee.api';

export const createAttendee = async (data: AttendeeModel) => {
  const res = await postAttendee(data);

  return res;
};
