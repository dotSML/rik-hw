import { AttendeeModel } from '../../domain/models/attendee.model';
import { patchAttendee } from '../../infrastructure/api/attendee.api';

export const updateAttendee = async (
  id: string,
  data: Partial<AttendeeModel>
) => {
  const response = await patchAttendee(id, data);
  return new AttendeeModel(response);
};
