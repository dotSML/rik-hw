import { deleteAttendee } from '../../infrastructure/api/attendee.api';

export const removeAttendee = async (id: string): boolean => {
  const res = await deleteAttendee(id);
  return res;
};
