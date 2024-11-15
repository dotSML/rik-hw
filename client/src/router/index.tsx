import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { HomeRoute } from '../routes/home.route';
import { AttendeesRoute } from '../routes/attendees.route';
import { AddEventRoute } from '../routes/add-event.route';
import { AttendeeDetailsRoute } from '../routes/attendee-details.route';

const router = createBrowserRouter([
    {
        path: '/',
        element: <HomeRoute />,
    },
    {
        path: '/events/:eventId/attendees',
        element: <AttendeesRoute />,
    },
    {
        path: '/events/add',
        element: <AddEventRoute />
    },
{
    path: "/attendees/:attendeeId",
    element: <AttendeeDetailsRoute />
}
]);

export function AppRouter() {
    return <RouterProvider router={ router } />;
}
