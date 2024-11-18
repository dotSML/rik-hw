export class EventModel {
  public eventId: string;
  public name: string;
  public date: string;
  public location: string;
  constructor({
    id,
    name,
    date,
    location,
  }: {
    id: string;
    name: string;
    date: string;
    location: string;
  }) {
    this.eventId = id;
    this.name = name;
    this.date = date;
    this.location = location;
  }
}
