import { EventModel } from "../../../domain/models/event.model"
import { EventOverview } from "./children/event-overview.component"

export const EventOverviewSection = ({ upcomingEvents, pastEvents, setUpcomingEvents, setPastEvents }: { setUpcomingEvents: () => void, setPastEvents: () => void, upcomingEvents: EventModel[], pastEvents: EventModel[] }) => {
    return <div className="flex max-w-full w-full h-[20rem] my-4">
        <EventOverview heading="Tulevased üritused" handleSetData={setUpcomingEvents} data={upcomingEvents} className="basis-[50%] mr-4 shrink-0" actions={<button className="font-bold text-xs text-textPrimary">LISA ÜRITUS</button>} />
        <EventOverview heading="Toimunud üritused" handleSetData={setPastEvents} data={pastEvents} className="basis-[50%]" />
    </div>
}



