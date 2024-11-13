import { EventListItem } from "./event-list-item.component"

interface EventListProps {
    data: any[]
}

export function EventList({ data }: EventListProps) {
    return <div className="flex flex-col items-center w-full bg-red h-full border-solid border-2 border-sky-500">
        {data.map((item) => <EventListItem data={item} handleRemove={() => { }} />)}
    </div>
}