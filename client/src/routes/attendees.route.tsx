import { useParams } from "react-router-dom";
import { EventDetails } from "../presentation/components/event.component";
import { PageWrapper } from "../presentation/components/page-wrapper.component";
import { useState, useEffect } from "react";
import { getEvent } from "../application/use-cases/fetch-event.use-case";
import { EventModel } from "../domain/models/event.model";
import { AttendeeModel } from "../domain/models/attendee.model";
import { fetchEventAttendees } from "../infrastructure/api/attendee.api";

export function AttendeesRoute() {
    const { eventId } = useParams();
    const [eventDetails, setEventDetails] = useState<EventModel>();
    const [attendees, setAttendees] = useState<AttendeeModel[]>([]);
    useEffect(() => {
        const fetchEventDetailsData = async () => {
            if (eventId) {
                const eventDetailsData = await getEvent(eventId);
                setEventDetails(eventDetailsData);

            }
        };

        const fetchAttendees = async () => {
            if (eventId) {
                const attendeesData = await fetchEventAttendees(eventId);
                setAttendees(attendeesData);

            }
        };


        fetchEventDetailsData();
        fetchAttendees();
            
    }, [eventId]);


    useEffect(() => {
        console.log(
            eventDetails
        );
        console.log(attendees);
    }, [eventDetails, attendees])

    return <PageWrapper title="Osavõtjad">
        <div className="flex flex-col">
        <h3 className="text-primaryBlue text-2xl mb-8">Osavõtjad</h3>

        <EventDetails />
        </div>
    </PageWrapper>
}