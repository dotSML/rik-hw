import { ReactNode } from "react"
import { EventModel } from "../../../../domain/models/event.model"
import { EventListItem } from "./event-list-item.component"
import { removeEvent } from "../../../../application/use-cases/delete-event.use-case"

export function EventOverview({ heading, className, data, actions, handleSetData }: { handleSetData: (data: any[]) => void, heading: string, className?: string, data: EventModel[], actions?: ReactNode }) {
    const handleRemove = async (id: string) => {
        await removeEvent(id);
        handleSetData([...data.filter((item) => item.eventId !== id)]);
    }
    return <div className={`flex flex-col items-center w-full bg-red h-full shadow-md ${className}`}>
        <div className="flex w-full h-20 justify-center items-center bg-primaryBlue">
            <p className="text-xl text-white">{heading}</p>
        </div>
        <div className="flex flex-col p-4 h-full w-full">
        <div className="flex flex-col w-full h-full">
        {data?.map((item, idx) => {
            return (<EventListItem key={`heading-${idx}`} index={idx} handleRemove={(eventId: string) => handleRemove(eventId) } data={item} />)
            
        })}
        </div>
        <div className="flex self-start">
            {actions}

            </div>
        </div>
    </div>
}