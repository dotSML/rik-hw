import { useEffect, useState } from "react";
import { getPastEvents, getUpcomingEvents } from "../application/use-cases/fetch-events.use-case";
import { EventOverviewSection } from "../presentation/components/event-overview/event-overview-section.component";
import { HomeSection } from "../presentation/components/home-section.component";

export function HomeRoute() {
    const [upcomingEvents, setUpcomingEvents] = useState([]);
    const [pastEvents, setPastEvents] = useState([]);

    useEffect(() => {
        const loadEvents = async () => {
            try {
                const upcomingEvents = await getUpcomingEvents();
                setUpcomingEvents(upcomingEvents);
                const pastEvents = await getPastEvents();
                setPastEvents(pastEvents);
            } catch (error) {
                console.error(error);
            }
        };

        loadEvents();
    }, []);

    return (
        <div>
            <HomeSection />
            <EventOverviewSection setUpcomingEvents={setUpcomingEvents} setPastEvents={setPastEvents} upcomingEvents={upcomingEvents} pastEvents={pastEvents} />
        </div>
    );
}