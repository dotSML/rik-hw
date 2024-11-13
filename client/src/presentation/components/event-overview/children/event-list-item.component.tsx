import { X } from "lucide-react";

interface EventListItemProps {
    data: {
        id: string,
        name: string,
        date: string,
        location?: string

    },
    index: number,
    handleRemove: (id: string) => void,

}

export function EventListItem({ data,index, handleRemove }: EventListItemProps) {
    return <div className="flex w-full">
        <p className="basis-[60%]">{index + 1}.{data.name}</p>
        <div className="flex gap-2">
        <p>{new Date(data.date).toLocaleDateString()}</p>
            <div className="flex items-center">
                <a className="uppercase text-xs font-bold text-textPrimary" href="#">osavõtjad</a>
                <X className="cursor-pointer" onClick={() => handleRemove(data.id)} />
            </div>
        </div>
        
        
    </div>
}