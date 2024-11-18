import { EventModel } from '../../domain/models/event.model';
import { postEvent } from '../../infrastructure/api/event.api';

export const createEvent = async (data: EventModel) => {
  const createdEvent = await postEvent(data);
  return new EventModel(createdEvent);
};
