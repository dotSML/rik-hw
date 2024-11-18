import libled from '../../assets/libled.jpg';
export function PageHeader({ title }) {
  return (
    <div className="flex w-full max-h-20 overflow-hidden shrink-0">
      <div className="flex bg-primaryBlue text-white basis-[25%] font-thin items-center pl-8 pt-8 pb-8 pr-32">
        <h2 className="text-4xl whitespace-nowrap">{title}</h2>
      </div>
      <img className="object-cover w-full" src={libled} />
    </div>
  );
}
