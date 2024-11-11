import logo from '../../assets/logo.svg';
import symbol from '../../assets/symbol.svg';

export function Navbar() {

    return <div className='flex w-full py-4 px-10'>
        <div className="flex basis-[40%]">
            <img src={logo} alt="logo" />

        </div>


        <div className="flex whitespace-nowrap">
            <div className="flex items-center justify-center h-full p-4">
            AVALEHT
            </div>
            <div className="flex items-center justify-center h-full p-4">
              URITUSE LISAMINE
            </div> 
        </div>

        <div className="flex justify-end w-full">
            <img src={symbol} alt="symbol" />
        </div>
    </div>
}