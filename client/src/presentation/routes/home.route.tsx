import { EventOverviewSection } from "../components/event-overview/event-overview-section.component";
import { HomeSection } from "../components/home-section.component";

export function HomeRoute() {
    return (
        <div>
            <HomeSection />
        <EventOverviewSection />
        </div>
    );
}