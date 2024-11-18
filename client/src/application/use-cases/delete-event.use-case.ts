import { deleteEvent } from '../../infrastructure/api/event.api';

export const removeEvent = async (id: string): Promise<boolean> => {
  const res = await deleteEvent(id);
  return res;
};
