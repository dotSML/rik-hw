import { useNavigate } from 'react-router-dom';
import { EventModel } from '../../../domain/models/event.model';
import { Button } from '../button.component';
import { EventOverview } from './children/event-overview.component';

export const EventOverviewSection = ({
  upcomingEvents,
  pastEvents,
  setUpcomingEvents,
  setPastEvents,
}: {
  setUpcomingEvents: (data: EventModel[]) => void;
  setPastEvents: (data: EventModel[]) => void;
  upcomingEvents: EventModel[];
  pastEvents: EventModel[];
}) => {
  const navigate = useNavigate();

  return (
    <div className="flex max-w-full w-full h-[20rem] my-4">
      <EventOverview
        heading="Tulevased üritused"
        handleSetData={setUpcomingEvents}
        data={upcomingEvents}
        className="basis-[50%] mr-4 shrink-0"
        actions={
          <Button
            size="xs"
            className="px-0 py-0"
            variant="text"
            title="LISA ÜRITUS"
            onClick={() => navigate('/events/add')}
          />
        }
      />
      <EventOverview
        heading="Toimunud üritused"
        handleSetData={setPastEvents}
        data={pastEvents}
        className="basis-[50%]"
      />
    </div>
  );
};
