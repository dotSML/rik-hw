import jumboImg from '../../assets/pilt.jpg';


export function HomeSection() {
    return <div className='flex w-full h-[20rem]'>
        <div className="flex w-full basis-[50%] bg-primaryBlue justify-center items-center px-12 py-16 xl:px-12 py-20">
            <p className="text-2xl text-white">Sed nec elit vestibulum, <span className="font-bold">tincidunt orci</span> et, sagittis ex. Vestibulum rutrum <span className="font-bold">neque suscipit</span> ante mattis maximus. Nulla non sapien <span className="font-bold">viverra, lobortis lorem non</span>, accumsan metus.</p>
        </div>
        <div className="flex w-full basis-[50%]">
        <img src={jumboImg} alt="jumbo" className="object-cover w-full h-full" />
        </div>
    </div>
}