import { useNavigate } from "react-router-dom"
import { AttendeeType } from "../../application/types/attendee-type"
import { AttendeeModel } from "../../domain/models/attendee.model"
import { EventModel } from "../../domain/models/event.model"
import { Button } from "./button.component"

function EventAttribute({ label, value, customValue }: { label: string, value?: string, customValue?: ReactNode }) {
    return <div className="grid grid-cols-2 gap-8">
        <p className="font-textPrimary text-md font-bold ">{label}:{" "}</p>{customValue ? customValue : < p > {value}</p>}
    </div>
}

function AttendeeItem({ data, index }: { data: AttendeeModel, index: number }) {
    const navigate = useNavigate();

    return <div className="flex justify-between items-center w-full whitespace-nowrap gap-4">

        <p>{index}.{data.type === AttendeeType.NaturalPerson ? `${data.firstName} ${data.lastName}` : data.legalName}</p>
        <p>{data.type === AttendeeType.NaturalPerson ? data.personalIdCode : data.companyRegistrationCode}</p>
        <div className='flex'>
            <Button variant="text" onClick={() => navigate(`/attendees/${data.id}`)} title="VAATA" />
            <Button variant="text" onClick={() => { }} title="KUSTUTA" />

        </div>
    </div>
}

export function EventDetails({ eventData, attendees }: { eventData: EventModel, attendees: AttendeeModel[] }) {
    return <div>
        <div className="flex flex-col gap-4">
            <EventAttribute label="Ürituse nimi" value={eventData.name} />
            <EventAttribute label="Toimumisaeg" value={new Date(eventData.date).toLocaleDateString()} />
            <EventAttribute label="Koht" value={eventData.location} />
            <EventAttribute label="Osavõtjad" />
            
        </div>
        <div className="flex w-full">

            <div className="ml-8 mt-6">
                {attendees.length
                    ? attendees.map((a, idx) => (
                        <AttendeeItem index={idx + 1} key={a.personalIdCode + idx} data={a} />
                    ))
                    : <p>Osavõtjad puuduvad</p>}              </div>
        </div>
    </div>
}