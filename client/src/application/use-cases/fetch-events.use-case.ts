import { EventModel } from '../../domain/models/event.model';
import { fetchEvents } from '../../infrastructure/api/event.api';

export const getUpcomingEvents = async () => {
  const searchParams = new URLSearchParams();
  searchParams.append('status', 'upcoming');
  const eventsData = await fetchEvents(searchParams);
  return eventsData.map((e) => new EventModel(e));
};

export const getPastEvents = async () => {
  const searchParams = new URLSearchParams();
  searchParams.append('status', 'past');
  const eventsData = await fetchEvents(searchParams);
  return eventsData.map((e) => new EventModel(e));
};
