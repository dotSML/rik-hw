import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { HomeRoute } from '../presentation/routes/home.route';

const router = createBrowserRouter([
    {
        path: '/',
        element: <HomeRoute />,
    },
]);

export function AppRouter() {
    return <RouterProvider router={ router } />;
}
