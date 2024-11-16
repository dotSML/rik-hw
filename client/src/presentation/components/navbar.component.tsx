import { NavLink } from 'react-router-dom';
import logo from '../../assets/logo.svg';
import symbol from '../../assets/symbol.svg';

function NavbarLink({ to, children }: { to: string, children: string }) {
    return <NavLink to={to} className={({isActive}) => (`flex items-center justify-center h-full p-4 font-semibold ${isActive ? 'text-white bg-primaryBlue' : 'text-black'}`)}>
        {children}
    </NavLink>
}

export function Navbar() {
    return <div className='flex w-full shadow-md mb-4'>
        <div className="flex basis-[40%] py-4 px-10">
            <img src={logo} alt="logo" />

        </div>


        <div className="flex whitespace-nowrap">
            <NavbarLink to="/">AVALEHT</NavbarLink>
            <NavbarLink to="/events/add">ÜRITUSE LISAMINE</NavbarLink>
        </div>

        <div className="flex justify-end w-full py-4 px-10">
            <img src={symbol} alt="symbol" />
        </div>
    </div>
}