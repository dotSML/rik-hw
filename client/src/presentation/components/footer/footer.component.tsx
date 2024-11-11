import { FooterColumn } from "./children/footer-column.component";

function MenuItem({ href, label }: { href: string, label: string }) {
    return <a href={href}>{label}</a>
}
export function Footer() {
    const columns = [
        {heading: "Curabitur", menuItems: [{href: "google.com", label: "testika"}]},}
    ]

    return <footer className="h-[12rem] bg-darkGrey grid gap-4 grid-cols-4 px-10 py-16">
        <FooterColumn heading="Curabitur" menuItems={[{ href: "google.com", label: "testika" }]}><div className="flex flex-col">
            {menuItems.map(({ label, href }, index) => <MenuItem key={`${heading}-menu-item-${index}`} label={label} href={href} />)}
        </div></FooterColumn>
        <FooterColumn heading="Fusce" menuItems={[{ href: "google.com", label: "testika" }]} />
        <FooterColumn heading="Kontakt" menuItems={[{ href: "google.com", label: "testika" }]} />
        <FooterColumn heading="" menuItems={[{ href: "google.com", label: "testika" }]} />

    </footer>
}