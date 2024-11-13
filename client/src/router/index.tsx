import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { HomeRoute } from '../routes/home.route';
import { AttendeesRoute } from '../routes/attendees.route';
import { AddEventRoute } from '../routes/add-event.route';

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
    }
]);

export function AppRouter() {
    return <RouterProvider router={ router } />;
}
