import { ReactNode } from "react"




export function FooterColumn({ heading, children }: { heading: string, children: ReactNode }) {
    return <div className="flex text-gray-200 flex-col">
        <h3 className="text-3xl">{heading}</h3>
        {children}
    </div>
}