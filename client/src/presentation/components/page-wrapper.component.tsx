import { PageHeader } from "./page-header.component";
export function PageWrapper({ title, children }) {
    return <div className="flex flex-col flex-1">
        <PageHeader title={title} />
        <div className="flex">
            <div className="basis-[25%]" />

            {children}

        </div>
    </div>
}