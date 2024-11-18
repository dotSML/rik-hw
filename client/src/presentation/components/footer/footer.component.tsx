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
            heading: "Kontakt", containerClass: "ml-20 col-span-2", renderContent: () => <div className="flex gap-4">
                <div className="flex flex-col"><div className="flex"><p className="font-bold">Peakontor:&nbsp;</p><p className="font-bold">Tallinnas</p></div>
                <p>
                Väike-Ameerika 11415 Tallinn
                </p>
                <div className="flex"><p>Telefon:</p><p>605 4450</p></div>
                <div className="flex">
                    <p>Faks:</p><p>605 3186</p>
                    </div>
                </div>
                <div className="flex flex-col">
                    <div className="flex"><p className="font-bold">Harukontor:&nbsp;</p><p className="font-bold">Võrus</p></div>
                    <p>
                        Oja tn 7 (külastusaadress)
                    </p>
                    <div className="flex"><p>Telefon:</p><p>605 4450</p></div>
                    <div className="flex">
                        <p>Faks:</p><p>605 3155</p>
                    </div>
                </div>

               
            </div>
        },
        
    ]

    return <footer className="bg-darkGrey grid gap-4 grid-cols-4 p-16 py-12">
        {columns.map((column, index) => (
            <FooterColumn
                key={index}
                heading={column.heading}
                className={column.containerClass || ""}
            >
                {column.renderContent()}
            </FooterColumn>
        ))}
    </footer>

}