export function EventOverview({ heading, className }: { heading: string, className?: string }) {
    return <div className={`flex flex-col items-center w-full bg-red h-full border-solid border-2 border-sky-500 ${className}`}>
        <div className="flex w-full h-20 justify-center items-center bg-primaryBlue">
            <p className="text-xl text-white">{heading}</p>
        </div>
    </div>
}