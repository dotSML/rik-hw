import { BrowserRouter } from "react-router-dom";
import { Footer } from "./presentation/components/footer/footer.component";
import { Navbar } from "./presentation/components/navbar.component";
import { AppRouter } from "./router";

function App() {
    return (
        <BrowserRouter>
            <div className="min-h-screen flex flex-col bg-primaryGrey">
                <header>
                    <Navbar />
                </header>

                <main className="flex-grow">
                    <AppRouter />
                </main>

                    <Footer />
            </div>
        </BrowserRouter>
    );
}

export default App;
