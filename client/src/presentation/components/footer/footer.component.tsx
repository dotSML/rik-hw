import { FooterColumn } from "./children/footer-column.component";

function MenuItem({ href, label }: { href: string, label: string }) {
    return <a href={href}>{label}</a>
}
export function Footer() {
    const columns = [
        {
            heading: "Curabitur", renderContent: () => <>
                <MenuItem href="#" label="Emauris" />
                <MenuItem href="#" label="Kfringilla" />
                <MenuItem href="#" label="Oin magna sem" />
                <MenuItem href="#" label="Kelementum" />
            </>
        },
        {
            heading: 'Fusce', renderContent: () => <>
                <MenuItem href="#" label="Econsectetur" />
                <MenuItem href="#" label="Ksollicitudin" />
                <MenuItem href="#" label="Omvulputate" />
                <MenuItem href="#" label="Nunc fringilla tellu" />
            </>
        },
        {
            heading: "Kontakt", renderContent: () => <>
                <p>Peakontor Tallinnas</p>

            </>
        },
    ]

    return <footer className="bg-darkGrey grid gap-4 grid-cols-3 px-10 py-16">
        {columns.map(column => <FooterColumn heading={column.heading}>{column.renderContent()}</FooterColumn>)}
    </footer>
}