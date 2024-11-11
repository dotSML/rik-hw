import { EventOverview } from "./children/event-overview.component"

export const EventOverviewSection = () => {
    return <div className="flex max-w-full w-full h-[20rem] my-4">
        <EventOverview heading="Tulevased uritused" className="basis-[50%] mr-4 shrink-0" />
        <EventOverview heading="Toimunud uritused" className="basis-[50%]" />
    </div>
}