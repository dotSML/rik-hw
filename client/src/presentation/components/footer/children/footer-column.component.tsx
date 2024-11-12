import { ReactNode } from "react"




export function FooterColumn({ heading, children, className }: { heading?: string, children: ReactNode, className: string }) {
    return <div className={`flex text-gray-200 flex-col ${className}`}>
        {heading ? <h3 className="text-3xl mb-2">{heading}</h3> : ""}
        {children}
    </div>
}