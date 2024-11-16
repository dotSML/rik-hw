import { Routes, Route } from "react-router-dom";
import { HomeRoute } from "../routes/home.route";
import { AttendeesRoute } from "../routes/attendees.route";
import { AddEventRoute } from "../routes/add-event.route";
import { AttendeeDetailsRoute } from "../routes/attendee-details.route";

export function AppRouter() {
    return (
        <Routes>
            <Route path="/" element={<HomeRoute />} />
            <Route path="/events/:eventId/attendees" element={<AttendeesRoute />} />
            <Route path="/events/add" element={<AddEventRoute />} />
            <Route path="/attendees/:attendeeId" element={<AttendeeDetailsRoute />} />
        </Routes>
    );
}
