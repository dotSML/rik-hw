import { EventListItem } from "./event-list-item.component"

export function EventOverview({ heading, className, data, actions }: { heading: string, className?: string, data: any, actions?: ReactNode }) {
    return <div className={`flex flex-col items-center w-full bg-red h-full shadow-md ${className}`}>
        <div className="flex w-full h-20 justify-center items-center bg-primaryBlue">
            <p className="text-xl text-white">{heading}</p>
        </div>
        <div className="flex flex-col p-4 h-full w-full">
        <div className="flex flex-col w-full h-full">
        {data?.map((item, idx) => {
            return (<EventListItem key={`heading-${idx}`} index={idx} handleRemove={(id: string) => { console.log(id) }} data={item} />)
            
        })}
        </div>
        <div className="flex self-start">
            {actions}

            </div>
        </div>
    </div>
}