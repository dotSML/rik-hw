import { EventModel } from '../../domain/models/event.model';
import { fetchEvent } from '../../infrastructure/api/event.api';

export const getEvent = async (eventId: string) => {
  const eventData = await fetchEvent(eventId);
  return new EventModel(eventData);
};
