function EventAttribute({ label, value, customValue }: { label: string, value?: string, customValue?: ReactNode }) {
    return <div className="flex items-center justify-start gap-8">
        <p className="font-textPrimary text-md font-bold basis-[50%]">{label}:{" "}</p>{customValue ? customValue : < p > {value}</p>}
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

export function EventDetails() {




    return <div>
        <div className="flex flex-col gap-4">
            <EventAttribute label="Ürituse nimi" value="Test event" />
            <EventAttribute label="Toimumisaeg" value="11.11.2024" />
            <EventAttribute label="Koht" value="Viljandi" />
            <EventAttribute label="Osavõtjad" customValue={<div>Custom list </div> } />
        </div>
    </div>
}