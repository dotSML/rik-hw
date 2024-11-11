import { Footer } from "./presentation/components/footer/footer.component"
import { Navbar } from "./presentation/components/navbar.component"
import { AppRouter } from "./router"

function App() {

    return (
        <div className="bg-primaryGrey">
            <Navbar />
            <AppRouter />
            <Footer />
        </div>
    )
}

export default App
