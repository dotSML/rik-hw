import { AttendeeModel } from "../../domain/models/attendee.model"
import { EventModel } from "../../domain/models/event.model"

function EventAttribute({ label, value, customValue }: { label: string, value?: string, customValue?: ReactNode }) {
    return <div className="grid grid-cols-2 gap-8">
        <p className="font-textPrimary text-md font-bold ">{label}:{" "}</p>{customValue ? customValue : < p > {value}</p>}
    </div>
}

function AttendeeItem({ name, code }) {
    return <div className="flex">
        <p>{name}</p>
        <p>{code}</p>
        <div className='flex'>
            <button>VAATA</button>
            <button>KUSTUTA</button>

        </div>
    </div>
}

export function EventDetails({ eventData, attendees }: { eventData: EventModel, attendees: AttendeeModel[] }) {


    console.log("ATTENDEEX - ", attendees)

    return <div>
        <div className="flex flex-col gap-4">
            <EventAttribute label="Ürituse nimi" value={eventData.name} />
            <EventAttribute label="Toimumisaeg" value={new Date(eventData.date).toLocaleDateString()} />
            <EventAttribute label="Koht" value={eventData.location} />
            <EventAttribute label="Osavõtjad" customValue={
                attendees.length
                    ? attendees.map((a) => (
                        <AttendeeItem key={a.personalCode} name={`${a.firstName} ${a.lastName}`} code={a.personalCode} />
                    ))
                    : <p>No attendees available</p>
            } />
        </div>
    </div>
}